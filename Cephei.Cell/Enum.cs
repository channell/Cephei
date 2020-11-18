/*
 * Copyright Cepheis Ltd 2020 
 * All rights reserves
 */
using System;

namespace Cephei.Cell
{
	/// <summary>
	/// Events sent from mutating cells to their dependants OnChange event handlers
	/// </summary>
	public enum CellEvent : int
	{


		/// <summary>
		/// default is that it was simply created
		/// </summary>
		Create = 0,
		/// <summary>
		/// Invalidate message is sent by threaded calculations to invalidate objects
		/// without causing a cascade of blocked threads.  Invalidate results in the cell
		/// becoming <i>Dirty</i>
		/// </summary>
		Invalidate = 2,
		/// <summary>
		/// do the calculation if needed. Recipients of this message send invalidate
		/// messages to their listeners
		/// </summary>
		Calculate = 4,
		/// <summary>
		/// an error occurred in the calculation.. all dependant changes should be
		/// abandoned
		/// </summary>
		Error = 8,
		/// <summary>
		/// when the value of a cell changes in the model, force Calculators to switch
		/// references
		/// </summary>
		Link = 16,
		/// <summary>
		/// The item has been removed from a model, and any casual observes should unlink.
		/// This will only happen for dynamic models that allow the calculations to be
		/// changed at runtime
		/// </summary>
		Delete = 32,
		/// <summary>
		/// Join a calculation session.  This event is passed to all dependant cells so
		/// they can determine whether a session value should be used instead of the spot
		/// value
		/// </summary>
		JoinSession = 64,

		/// <summary>
		/// Check for cyclic dependancy
		/// </summary>
		CyclicCheck = 128
	}

	/// <summary>
	/// The State vector of the cell
	/// </summary>
	public enum CellState : int
	{


		/// <summary>
		/// Clean state is set whenever a value is assigned to the Cell, or a Calculation
		/// has completed
		/// </summary>
		Clean = 0,
		/// <summary>
		/// Error state is entered whenever a calculation fails.
		/// An Error event is raised to dependants
		/// </summary>
		Error = 1,
		/// <summary>
		/// Dirty is the state
		/// <ul>
		/// 	<li>On creation with a function
		/// Calculate is called on a Task thread</li>
		/// 	<li>Whenever an Invalidate Event is fired</li>
		/// </ul>
		/// </summary>
		Dirty = 2,
		/// <summary>
		/// Calculating state is set when a thread starts calculating a value, either
		/// triggered by Calculate Event or a value is require but the enqued task has not
		/// yet been dispatched
		/// </summary>
		Calculating = 4 + 2,
		/// <summary>
		/// Blocking State is entered whenever a value is required, but another thread is
		/// already in the process of calculating a value or a task needs to calculate a
		/// value for a session
		/// </summary>
		Blocking = 8 + 4 + 2


	}

	public class CyclicDependencyException : Exception
	{
		public CyclicDependencyException() : base() { }
	}
}