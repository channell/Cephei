/*
 * Copyright Cepheis Ltd 2020 
 * All rights reserves
 */
using Cephei.Cell.Generic;
using ILGPU.Frontend;
using ILGPU.Frontend.DebugInformation;
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace Cephei.Cell
{
    /// <summary>
    /// Notification that a cell has changed
    /// </summary>
    /// <param name="eventType">type of event passed</param>
    /// <param name="sender">the cell that triggered this change</param>
    /// <param name="epoch">the time epoch of the original source change.. used for throttling</param>
    /// <param name="transaction">optionaly the transaction that is completing</param>
    public delegate void CellChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session);

    /// <summary>
    /// Cells and observers that handle change events
    /// </summary>
    public interface ICellEvent : IDisposable
    {
        /// <summary>
        /// OnChange is the event sink that receives notification of changes to dependant
        /// cells
        /// </summary>
        /// <param name="eventType">The event be raised</param>
        /// <param name="root">The cell that sent this event,</param>
        /// <param name="epoch">timestamp of the change.  This is used to ensure that
        /// latest values are not overwirtten by calculations dispatched out of
        /// order</param>
        /// <param name="session">reference to the session that the eventi was originally
        /// source in</param>
        void OnChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session);

        /// <summary>
        /// Reference to the parent of this cell - usually the model the cell is defined in.
        /// 
        /// Parents get notifications for all changes to their childen
        /// </summary>
        ICell Parent { get; set; }
    }

    /// <summary>
    /// ICell provides a base interface with the common behavior of all Cells
    /// </summary>
    public interface ICell : ICellEvent
    {
        /// <summary>
        /// Enumerated list of the Target vale of all event delegates.
        /// This is used to ensure that multiple references do not result in events being
        /// fired multiple times <i>x = f (y,y) </i>has a single dependancy
        /// </summary>
        IEnumerable<ICellEvent> Dependants { get; }
        /// <summary>
        /// refeence Mnemonic that provides context for multiple subscriptions and model
        /// references
        /// </summary>
        string Mnemonic { get; set; }
        /// <summary>
        /// Event handle that a dependant cell uses to subscribe to changes.
        /// e.g. if <i>x = f (y)</i> then <i>x</i> will attach its OnChange to <i>y</i>
        /// Event to subscribe to changes<i> </i>
        /// </summary>
        event CellChange Change;

        /// <summary>
        /// Does the cell havee a function that can be subscribed to 
        /// </summary>
        bool HasFunction { get; }

        /// <summary>
        /// Clone the dependencies of another cell
        /// </summary>
        /// <param name="source"></param>
        void Merge(ICell source, Model model);

        /// <summary>
        /// Add notifcation 
        /// </summary>
        /// <param name="listener">cell aquiring the notification</param>
        void Notify(ICell listener);

        /// <summary>
        /// Drop notifciation
        /// </summary>
        /// <param name="listener">cell aquiring the notification</param>
        void UnNotify(ICell listener);

        /// <summary>
        /// Does the cell havee a function that can be subscribed to 
        /// </summary>
        bool HasValue { get; }

        /// <summary>
        /// Support assignement from boxed values
        /// </summary>
        object Box { get; set; }

        /// <summary>
        /// enable passthrough profiling of trivial funtions
        /// </summary>
        /// <returns>_func</returns>
        object GetFunction();

        /// <summary>
        /// Can this cell be cast to to the Base class
        /// </summary>
        /// <typeparam name="Base"></typeparam>
        /// <returns></returns>
        bool ValueIs<Base>();

        /// <summary>
        /// Get the status of the cell
        /// </summary>
        CellState State { get; }

        /// <summary>
        /// Last Error object form async calcualtion
        /// </summary>
        Exception Error { get; }

        /// <summary>
        /// Reference to a parent cell whose dependants need to lock because the algorith is not thread safe
        /// </summary>
        /// <remarks>
        /// Needs to be a ICell for code generation
        /// </remarks>
        ICell Mutex { get; set; }
    }

    /// <summary>
    /// Trivial Cells are executed inline with their calling function
    /// </summary>
    public interface ITrivial
    {
        /// <summary>
        /// Allow Trivial Cells to be upgraded to tracking Cells
        /// </summary>
        /// <returns></returns>
        ICell ToCell();
    }

    /// <summary>
    /// Fast Cells do not need to have dependancie migrated
    /// </summary>
    public interface IFast
    {
    }

    /// <summary>
    /// Model that wrapps a subject cell
    /// </summary>
    public interface ICellModel 
    {
        ICell Subject { get; }

        /// <summary>
        /// When a cell that is the subject of a model is moved to another model, continue to capture the events
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="root"></param>
        /// <param name="sender"></param>
        /// <param name="epoch"></param>
        /// <param name="session"></param>
        void MigratedParentOnChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session);
    }


    /// <summary>
    /// Cell provides a  module functions of the Cell framework and a thread static
    /// stack of cells being evaluated.
    /// </summary>
    public static class Cell
    {
        /// <summary>
        /// flag to indicate whether parallel calculation should be used to evaluate the
        /// cells
        /// </summary>
        public static bool Parellel = true;

        /// <summary>
        /// flag to whether cells to evaluate on creation or wait for reference 
        /// cells
        /// </summary>
        public static bool Lazy = true;

        /// <summary>
        /// Are IO operations used, causing lock cancellatrion to be disabled
        /// </summary>
        public static bool IO = false;

        /// <summary>
        /// The current stack of cell being profiled. normally this stack will be empty.
        /// including a null item for safe peek
        /// </summary>
        public static System.Threading.ThreadLocal<Stack<ICell>> Current = new System.Threading.ThreadLocal<Stack<ICell>>(() => { var s = new Stack<ICell>(); s.Push(null); return s; });

        /// <summary>
        /// Crreate a cell with an F# function like
        /// let cell = Cell.Create (fun i -> other_cell.Value.NPV(tenor.Value)
        /// </summary>
        /// <param name="func"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Generic.ICell<T> Create<T>(FSharpFunc<Unit, T> func)
        {
            return new Cell<T>(func);
        }
        /// <summary>
        /// Crreate a cell with an F# function and name like
        /// let cell = Cell.Create (fun i -> other_cell.Value.NPV(tenor.Value) "other_cell
        /// NPV"
        /// </summary>
        /// <param name="func"></param>
        /// <param name="mutex"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Generic.ICell<T> Create<T>(FSharpFunc<Unit, T> func, ICell mutex)
        {
            return new Cell<T>(func, mutex);
        }
        /// <summary>
        /// Crreate a trivial cell with an F# function and name like
        /// let cell = Cell.CreateTrivial (fun i -> other_cell :> expected) "other_cell
        /// NPV"
        /// </summary>
        /// <param name="func"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Generic.ICell<T> CreateTrivial<T>(FSharpFunc<Unit, T> func)
        {
            return new CellTrivial<T>(func);
        }

        /// <summary>
        /// Crreate a trivial cell with an F# function and name like
        /// let cell = Cell.CreateTrivial (fun i -> other_cell :> expected) "other_cell
        /// NPV"
        /// </summary>
        /// <param name="func"></param>
        /// <param name="mutex"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Generic.ICell<T> CreateTrivial<T>(FSharpFunc<Unit, T> func, ICell mutex)
        {
            return new CellTrivial<T>(func, mutex);
        }

        /// <summary>
        /// Create a cell with a mutable value
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Cell<T> CreateValue<T>(T value)
        {
            return new Cell<T>(value);
        }
        /// <summary>
        /// Create a cell with a function, taking advantage of the fact the funcion passed
        /// should be a closure that captures the value used in the calculation.an
        /// For functions like let x = Cell.CreateFast (fun x -> NPV y.["z"]) will result
        /// in a normal cell being created because the closure does not resolve to
        /// ICell<'t> because <i>y</i> is captured rather then the result of the expression.
        /// 
        /// coding it as closure builder allows the cell to be profiled at creation
        /// let x =
        ///  let build z =
        ///    Cell.Fast (fun x -> NPV z)
        ///  build y.["z"]
        /// </summary>
        /// <param name="func"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Generic.ICell<T> CreateFast<T>(FSharpFunc<Unit, T> func)
        {
            return new CellFast<T>(func);
        }
        /// <summary>
        /// Create a fast cell with a mnemonic
        /// </summary>
        /// <param name="func"></param>
        /// <param name="mutex"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Generic.ICell<T> CreateFast<T>(FSharpFunc<Unit, T> func, ICell mutex)
        {
            return new CellFast<T>(func, mutex);
        }
        /// <summary>
        /// Create a cell value where it is known at define-time that all the dependants
        /// will use fast cells for evaluation.
        /// This creates a cell that does not check for dependants needing profiling
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Generic.ICell<T> CreateFastValue<T>(T value)
        {
            return new CellFast<T>(value);
        }
        /// <summary>
        /// Create a Fast Cell that does not participate in sessions.  All calls to Value
        /// will use the latest spot value of the cell
        /// </summary>
        /// <param name="func"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Generic.ICell<T> CreateSpot<T>(FSharpFunc<Unit, T> func)
        {
            var p = Profile(func);
            if (p.Length > 0)
                return new CellSpot<T>(func, p);
            else
                return new Cell<T>(func);
        }
        /// <summary>
        /// Create a Fast Cell with an mnemonic that does not participate in sessions.  All
        /// calls to Value will use the latest spot value of the cell
        /// </summary>
        /// <param name="func"></param>
        /// <param name="mutex"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Generic.ICell<T> CreateSpot<T>(FSharpFunc<Unit, T> func, ICell mutex)
        {
            return new CellSpot<T>(func, mutex);
        }
        /// <summary>
        /// Create a cell value where it is known at define-time that all the dependants
        /// will use fast cells for evaluation and will not participate in sessions
        /// This creates a cell that does not check for dependants needing profiling or
        /// current sessions
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Generic.ICell<T> CreateSpotValue<T>(T value)
        {
            return new CellSpot<T>(value);
        }

        /// <summary>
        /// Create a Fast Cell that does not participate in sessions.  All calls to Value
        /// will use the latest spot value of the cell
        /// </summary>
        /// <param name="func"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Generic.ICell<T> CreateLazy<T>(FSharpFunc<Unit, T> func)
        {
            return new CellLazy<T>(func);
        }
        /// <summary>
        /// Create a Fast Cell with an mnemonic that does not participate in sessions.  All
        /// calls to Value will use the latest spot value of the cell
        /// </summary>
        /// <param name="func"></param>
        /// <param name="mutex"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Generic.ICell<T> CreateLazy<T>(FSharpFunc<Unit, T> func, ICell mutex)
        {
            return new CellLazy<T>(func, mutex);
        }

        /// <summary>
        /// profile the closure to extract a list of the cells referenced
        /// </summary>
        /// <param name="func"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ICell[] Profile<T>(FSharpFunc<Unit, T> func)
        {
            return ProfileObject(func);
        }

        /// <summary>
        /// profile the kernel bootstrap closure to extract a list of the cells referenced
        /// </summary>
        /// <param name="func"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ICell[] Profile<T>(FSharpFunc<Unit, FSharpFunc<Unit, T>> func)
        {
            return ProfileObject(func);
        }

        /// <summary>
        /// profile the closure to extract a list of the cells referenced
        /// </summary>
        /// <param name="func"></param>
        private static ICell[] ProfileObject(object func)
        {
            var l = new LinkedList<ICell>();
            var fields = func.GetType().GetFields();
            var fd = new Dictionary<string, object>();

            foreach (var f in fields)
            {
                var o = f.GetValue(func);
                fd.Add(f.Name, o);
                /*
                if (o is ICell c)
                {
                    l.AddLast(c);
                }
                */
            }

            var method = func.GetType().GetMethod("Invoke");
            var disasembler = new Disassembler(method, SequencePointEnumerator.Empty);
            var code = disasembler.Disassemble();
            object lastLoad = null;
            Lazy<Dictionary<string, FieldInfo>> lastFields = null;

            foreach (var il in code.Instructions)
            {
                if (il.InstructionType == ILInstructionType.Ldfld)
                {
                    var fi = il.Argument as FieldInfo;
                    if (fd.ContainsKey(fi.Name))
                    {
                        lastLoad = fd[fi.Name];
                    }
                    else
                    {
                        if (lastFields.Value.ContainsKey(fi.Name))
                        {
                            var fi2 = lastFields.Value[fi.Name];
                            var o = fi2.GetValue(lastLoad);
                            lastLoad = o;
                        }
                    }

                    lastFields = new Lazy<Dictionary<string, FieldInfo>>(() => lastLoad.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic| BindingFlags.Instance).ToDictionary(af => af.Name));
                    if (lastLoad is ICell c)
                    {
                        if (c is ITrivial)
                        {
                            foreach (var x in ProfileObject(c.GetFunction()))
                                l.AddLast(x);
                        }
                        else 
                            l.AddLast(c);
                    }
                }
            }
            return l.Distinct().ToArray();
        }
    
        /// <summary>
        /// Relink the formula of a cell to use current value
        /// </summary>
        /// <param name="func">function within cell</param>
        /// <param name="model">model that the functions cell is within </param>
        /// <param name="recursive">should this be a recursive relink </param>
        public static bool Relink(object func, Model model, ICellEvent target)
        {
            var changed = false;
            var fields = func.GetType().GetFields();

            foreach (var f in fields)
            {
                var o = f.GetValue(func);
                if (o is ICell c)
                {
                    ICell n;
                    if (c.Mnemonic != null && target is ICell tar && c.Mnemonic == tar.Mnemonic && model.TryGetValue(c.Mnemonic, out n))
                    {
                        /*
                        if (!(f.Name == "this" || f.Name == "@this") && n is ICellModel m)
                        {
                            n = m.Cell;
                        }*/
                        if (n != null && n != c && c.GetType().IsAssignableFrom(n.GetType()))
                        {
                            changed = true;
                            f.SetValue(func, n);
                        }
                    }
                }
            }
            return changed;
        }

        public static void Dispatch (Action a)
        {
            if (Parellel)
                System.Threading.Tasks.Task.Run(a);
            else
                a();
        }
    }
}
