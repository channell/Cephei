using Cephei.Cell.Generic;
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;

namespace Cephei.Cell
{
    /// <summary>
    /// Notification that a cell has changed
    /// </summary>
    /// <param name="eventType">type of event passed</param>
    /// <param name="sender">the cell that triggered this change</param>
    /// <param name="epoch">the time epoch of the original source change.. used for throttling</param>
    /// <param name="transaction">optionaly the transaction that is completing</param>
    public delegate void CellChange(CellEvent eventType, ICell sender, DateTime epoch, ISession session);

    /// <summary>
    /// ICell provides a base interface with the common behavior of all Cells
    /// </summary>
    public interface ICell
    {
        /// <summary>
        /// Reference to the parent of this cell - usually the model the cell is defined in.
        /// 
        /// Parents get notifications for all changes to their childen
        /// </summary>
        ICell Parent { get; set; }
        /// <summary>
        /// Enumerated list of the Target vale of all event delegates.
        /// This is used to ensure that multiple references do not result in events being
        /// fired multiple times <i>x = f (y,y) </i>has a single dependancy
        /// </summary>
        IEnumerable<ICell> Dependants { get; }
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
        void OnChange(CellEvent eventType, ICell root, DateTime epoch, ISession session);
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
		/// The current stack of cell being profiled. normally this stack will be empty.
		/// </summary>
        public static System.Threading.ThreadLocal<Stack<ICell>> Current = new System.Threading.ThreadLocal<Stack<ICell>>(() => new Stack<ICell>());

		/// <summary>
		/// Crreate a cell with an F# function like
		/// let cell = Cell.Create (fun i -> other_cell.Value.NPV(tenor.Value)
		/// </summary>
		/// <param name="func"></param>
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
		/// <param name="mnemonic"></param>
        public static Generic.ICell<T> Create<T>(FSharpFunc<Unit, T> func, string mnemonic)
        {
            return new Cell<T>(func, mnemonic);
        }

		/// <summary>
		/// Create a cell with a mutable value
		/// </summary>
		/// <param name="value"></param>
        public static Cell<T> CreateValue<T>(T value)
        {
            return new Cell<T>(value);
        }
		/// <summary>
		/// Create a cell with a mutable value and mnemonic
		/// </summary>
		/// <param name="value"></param>
		/// <param name="mnemonic"></param>
        public static Cell<T> CreateValue<T>(T value, string mnemonic)
        {
            return new Cell<T>(value, mnemonic);
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
        public static Generic.ICell<T> CreateFast<T>(FSharpFunc<Unit, T> func)
        {
            var p = Profile(func);
            if (p.Length > 0)
                return new CellFast<T>(func, p);
            else
                return new Cell<T>(func);
        }
		/// <summary>
		/// Create a fast cell with a mnemonic
		/// </summary>
		/// <param name="func"></param>
		/// <param name="mnemonic"></param>
        public static Generic.ICell<T> CreateFast<T>(FSharpFunc<Unit, T> func, string mnemonic)
        {
            var profile = Profile(func);
            if (profile.Length > 0)
                return new CellFast<T>(func, profile, mnemonic);
            else
                return new Cell<T>(func, mnemonic);
        }
		/// <summary>
		/// Create a cell value where it is known at define-time that all the dependants
		/// will use fast cells for evaluation.
		/// This creates a cell that does not check for dependants needing profiling
		/// </summary>
		/// <param name="value"></param>
        public static Generic.ICell<T> CreateFastValue<T>(T value)
        {
            return new CellFast<T>(value);
        }
		/// <summary>
		/// Create a cell value with a mnemonic where it is known at define-time that all
		/// the dependants will use fast cells for evaluation.
		/// This creates a cell that does not check for dependants needing profiling
		/// </summary>
		/// <param name="value"></param>
		/// <param name="mnemonic"></param>
        public static Generic.ICell<T> CreateFastValue<T>(T value, string mnemonic)
        {
            return new CellFast<T>(value, mnemonic);
        }
		/// <summary>
		/// Create a Fast Cell that does not participate in sessions.  All calls to Value
		/// will use the latest spot value of the cell
		/// </summary>
		/// <param name="func"></param>
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
		/// <param name="mnemonic"></param>
        public static Generic.ICell<T> CreateSpot<T>(FSharpFunc<Unit, T> func, string mnemonic)
        {
            var profile = Profile(func);
            if (profile.Length > 0)
                return new CellSpot<T>(func, profile, mnemonic);
            else
                return new Cell<T>(func, mnemonic);
        }
		/// <summary>
		/// Create a cell value where it is known at define-time that all the dependants
		/// will use fast cells for evaluation and will not participate in sessions
		/// This creates a cell that does not check for dependants needing profiling or
		/// current sessions
		/// </summary>
		/// <param name="value"></param>
        public static Generic.ICell<T> CreateSpotValue<T>(T value)
        {
            return new CellSpot<T>(value);
        }
		/// <summary>
		/// Create a cell value with mnemonic where it is known at define-time that all the
		/// dependants will use fast cells for evaluation and will not participate in
		/// sessions
		/// This creates a cell that does not check for dependants needing profiling or
		/// current sessions
		/// </summary>
		/// <param name="value"></param>
		/// <param name="mnemonic"></param>
        public static Generic.ICell<T> CreateSpotValue<T>(T value, string mnemonic)
        {
            return new CellSpot<T>(value, mnemonic);
        }

		/// <summary>
		/// profile the closure to extract a list of the cells referenced
		/// </summary>
		/// <param name="func"></param>
        public static ICell[] Profile<T>(FSharpFunc<Unit, T> func)
        {
            var l = new LinkedList<ICell>();
            var fields = func.GetType().GetFields();
            int size = 0;

            foreach (var f in fields)
            {
                if (f.GetValue(func) is ICell c && !(c is Model))
                {
                    l.AddLast(c);
                    size++;
                }
            }
            var a = new ICell[size];
            l.CopyTo(a, 0);
            return a;
        }
    }
}
