using System;
using System.Collections.Generic;

namespace Cephei.Cell
{
    /// <summary>
    /// Session state is used to record the lifecycle of a session
    /// </summary>
    public enum SessionState : int
    {


        /// <summary>
        /// The session has been created and is open to accept values with delayed event
        /// fire
        /// </summary>
        Open = 0,
        /// <summary>
        /// The session has been disposed (the use context has finished), the session will
        /// continue to be available while referenced by cells undertaking calculation (or
        /// notifying Session Observers.
        /// </summary>
        Calculating = 1,
        /// <summary>
        /// The session has completed and is available for Garbage Collection
        /// </summary>
        Complete = 2


    }

    /// <summary>
    /// Notification that a session has completed 
    /// </summary>
    /// <param name="session"></param>
    public delegate void SessionComplete(ISession session);

    /// <summary>
    /// ISession is a common interface for Data Sessions and for "Null Session".  It is
    /// an interface because ThreadLocal store always requires a value even when
    /// there
    /// is no active session.
    /// 
    /// ISession provides a mechanism to
    /// <ul>
    /// 	<li>delay publication of change events while related values are changed (e.g.
    /// spot-rate changes will cascade perturbations along a yield curve</li>
    /// </ul>
    /// <ul>
    /// 	<li>provide a bubbling mechanism that does not force real-time price chang to
    /// wait for the completion of complex calculations to avoid corruption</li>
    /// </ul>
    /// </summary>
    public interface ISession : IDisposable, IEnumerable<ICell>
    {
        /// <summary>
        /// Reference to the state vector, used the trigger change events when  the state
        /// changes
        /// </summary>
        SessionState State { get; }
        /// <summary>
        /// Mnemonic provides a name to allow subscribers to correlate results with the
        /// source of data
        /// </summary>
        string Mnemonic { get; }
        /// <summary>
        /// timestamp to prevent older sessions whose calculations may have been scheduled
        /// later to update a more recent spot value
        /// </summary>
        DateTime Epoch { get; }
        /// <summary>
        /// Join is triggered by the JoinSession event, and includes all the Cells that are
        /// impacted by a change to a value associated with the session
        /// </summary>
        /// <param name="cell"></param>
        void Join(ICell cell);
        /// <summary>
        /// Leave is called once a calculation is complete for a Cell that had joined the
        /// </summary>
        /// <param name="cell"></param>
        void Leave(ICell cell);
        bool HasJoined(ICell cell);
        /// <summary>
        /// Get a value from the session.  Session values are written by pool-calculations,
        /// 
        /// and a referenced from values in the session.  A Cell responding to streamed
        /// updates may have a different current-value to the value calculated for the
        /// session
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="value"></param>
        bool GetValue<T>(ICell cell, ref T value);
        /// <summary>
        /// Set the value for this cell in the session cache, and ensure that all
        /// dependant
        /// calculations for this session use this value
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="value"></param>
        void SetValue<T>(ICell cell, T value);

        /// <summary>
        /// Size of the session is the number of cells that are referenced by the session
        /// </summary>
        int Size { get; }
        
        /// <summary>
        /// PercentComplete is the ratio of the number of values to the number of cells within the session
        /// </summary>
        double PercentComplete { get; }


        /// <summary>
        /// Notification that the calculation has completed
        /// </summary>
        event SessionComplete Complete;
    }
}
