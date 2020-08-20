![Cell-Graph](https://github.com/channell/Cephei/blob/master/Cephei.Cell/Docs/Cell-graph.png)
This article introduces the [Cephei.Cell library](https://www.nuget.org/packages/Cephei.Cell/) released recently to the Nuget package manager with source in [GetHub](https://github.com/channell/Cephei) honouring an promise made to Don Syme many years ago.  It demonstrates the efficiency of development of mathematical models in F# 

 # Background
The “Cell Framework” started fifteen years ago as a mechanism to make Monte Carlo simulations execute fast for interactive calculation of Potential and Expected Exposure of derivative {swap, swaption, cap, floor} trades before execution to ensure they were profitable enough to balance the exposure with a CDS trade.  Monte Carlo simulation are compute intensive because thousands of alternate scenarios must be calculated for each time-point.  With a minor change to use Cells (with asynchronous calculation) for NPV calculation it was possible to halve the time taken to risk a trade.  At the time cells implemented a [future promise pattern](https://en.wikipedia.org/wiki/Futures_and_promises), but it was apparent the speed of overall calculation far outweighed the cost of constructing and scheduling tasks for reasonably expensive operations, and that re-using the cells for further time-points would allow for more operations to be performed in parallel.

The second version replaced the Mutex lock with a “Latch Lock” pattern (used internally by the Oracle RDBMS) where objects are only explicitly locked if there is contention between threads.  This version introduced event subscriptions to propagate changes to dependant Cells like a spreadsheet, and a profiling mechanism to identify dependencies without the time (or errors) of defining dependencies in code.  This was used for Early Warning of Liquidity risk, where any number of movements in the price of {equity, FX, futures} instruments could trigger action to tighten risk appetite.

The third version combines the Latch-lock with state transition to provide lockless concurrency; [eager-steal](https://en.wikipedia.org/wiki/Work_stealing) for waitless calculation on modern multi-core servers; moves history from within Cells to session to remove garbage collection contention; and initialisation-time profiling of [closures](https://en.wikipedia.org/wiki/Closure_(computer_programming)). 
`Cell` is significantly faster for large complex calculations, where a number of factors can change, are well-suited to streaming price calculation and real-time risk derivation.
# Framework or Kernel
The term “Cell Framework” is used because [Cephei.Cell](https://www.nuget.org/packages/Cephei.Cell/) is foundation for [Cephei.QL]( https://www.nuget.org/packages/Cephei.QL/) that is being updated for .NET 5 to remove Windows/Wine dependency. Cephei uses code generation to wrap underlying C++ quantitative finance functions into higher-level abstracts to allow an Excel addin to be used to define a financial model that can be saved as a functional program directly – Excel becomes an editor for functional code.

While the Cell Framework replicates the [promise pattern](https://en.wikipedia.org/wiki/Futures_and_promises) and the paradigm of spreadsheet cells, it is also a foundation for different way of thinking about software building blocks that extenuates functional relationships between values rather than linear paths of derivation.

While `Cell` provides a mechanism to automatically parallel calculate a number of functions, a `Model` provides a mechanism to encapsulate complexity, and only surface values that are input or output. `Model` can contain other Models to build high-level abstractions for {Asset-Class agnostic Trade, Portfolio, Book, Ledger, etc}.  Cells within a `Model` can be changed at runtime (like a spreadsheet)

`Session` provide a mechanism to group together changes to input values (e.g. market data feed) without duplicate calculations (same as the pattern of manual calculation in Excel), while `SessionStream` adds overlapping sessions for a continuous calculation of high-level values (like RWA) in near-real-time.
`Cell` and `Model` provide the `IObservable`/`IObserver` pattern for event linkage with a stream based calculation.
# Implementation
`Cell` uses lockless concurrency with thread synchronisation `ManualResetEvent` for contention (when a value is needed, but calculation has already commenced) using processor cache bypass[Compare & Swap](https://en.wikipedia.org/wiki/Compare-and-swap) for `SpinLock` and State pointer
 
## Cell<T>
`Cell<T>` is implemented as a [Finite State Machine]( https://en.wikipedia.org/wiki/Finite-state_machine) where Operations and Events cause atomic state-transitions to ensure that under no circumstance is a `Dirty` value read from `Cell`, with Operating System Events only used when threads are blocking for a value from calculation currently being performed.
![Cell-State](https://github.com/channell/Cephei/blob/master/Cephei.Cell/Docs/Cell-state.png)
 
There are three specialisations of `Cell<T>` that are instantiated either through the `Cell` module, or (in the case of `CellEmpty`) through a `Model` that includes forward-reference to Cells that have not been defined at that point in the `Model`
## CellFast
When it is know in advance that Cells and their references will not be redefined at runtime, and their references are not forward referenced, `CellFast<T>` can be used to bypass runtime profiling of cells.  In this scenario [closures]( https://en.wikipedia.org/wiki/Closure_(computer_programming)) are inspected at instantiation to extract the cells that this `cell` is dependent on.
```
let calculation_cell =
  let build (p : ICell<’t>) =
    Cell.CreateFast (fun () -> some_complex_calculation  p.Value)
  build referenced_cell 
```
In this example `referenced_cell` is captured by the closure rather than the wider model (`Cell.CreateFast` factory method should be used to avoid causing the calculation to re-evaluate whenever _any_ value in the `Model` changes – it will default to a `Cell<T>` object if there are no parameters for instantiation-time profiling.  `CellFast<T>` should only be used if you are comfortable with advanced concepts of Functional Programming.
## CellSpot
`CellSpot<T>` is a further specialisation of `CellFast<T>` where it is known in advance that the `Cell` will never be redefined, and the latest (spot) value should always be used (typically the FX rate for a portfolio)	
![cell-class](https://github.com/channell/Cephei/blob/master/Cephei.Cell/Docs/cell-class.png) 
## Cell
The static module `Cell` provides factory functions to create cells from F# using type-inference, plus a Thread Local stack of Cells currently being profiled.
> Any Cell that reads the content of another Cell while evaluating its function, is by definition dependant on it
For the Boolean conditional logic, the condition code needs to be in a separate cell in order for the expression to re-profile when the boolean value changes:
```
let dependant_cell = Cell.Create (fun () -> 
		if cond_cell.Value then 
			equity_trade.Value 
		else 
			credit_trade.Value)
```
## Model
 ![cell-model](https://github.com/channell/Cephei/blob/master/Cephei.Cell/Docs/cell-model.png)
`Model` provides a tree structured dictionary of cells in an overall model, but is different from a plain dictionary in a number of respects:

* It collects all events from each of the Cells (& Models) within it, enabling a single subscription for changes to any part of a model
* It provides the `model.As<T>`(“reference name”) for type coercion of the value being referenced from different parts of the model, which also enables forward reference of cells that have not been previously defined within a model
* Names passed to a model lookup use the `’|’` as a delimiter, so “equity|hsbc|lon|fair_value_price” would resolve to a reference to the `Cell` fair_value_price within the hierarchy of the model 
 
## Session
![cell-session](https://github.com/channell/Cephei/blob/master/Cephei.Cell/Docs/cell-session.png)
`Session` provides for consistency that derived cells are calculated with the same set of values that were set when the session was opened.  Generally changes to the spot value of a bond future, with trigger changes to the price of quoted IRS instruments and long-dated government bonds which appear to ripple along a yield curve, which could trigger multiple valuations of dependant instruments – unless relative value arbitrage is being sought, it is better to snap all price changes together and calculate one.

`Session` has a `Current` thread static reference that allows assignment to the value of a cell to be implicitly part of the session, with calculation delayed until the session is disposed – in this content `IDisposable.Dispose()` is not a euphemism for delete, because the session will be passed through the event-notification methods and kept alive until all Cells have left the session when it finally becomes eligible for garbage collection.  
Important values are 

* Scope - Cells that have joined the session in response to "JoinSession" event and Join call 
* Values -  Boxed value of the cells referenced in the session for consistent values 

The only guarantee that the value returned from `cell.Value` will be consistent with the session (later sessions might be scheduled first) is to read the value using a `SessionObserver` 
### SessionStream
`SessionStream` provides a proxy to an interlaced stream of sessions, that return `_current` for `GetValue` calls and `_next` for `SetValue` moving starting calculation of `_next` once the `_current` session has completed.

`SessionStream` allows an event-stream subscriber to hold a single session open, and allow consistent sets of calculations to be provided as quickly as calculation is completed.
This is designed for real-time-risk where high-level portfolio calculations take time to calculate and can not keep-up with fast-moving-markets.  An example would be a liquidity barometer decline in liquidity-coverage-ratio triggers an uptick in internal treasury cross-charging interest rates that have the effect of reducing the risk-appetite and quantity of trades executed.
# Usage
The example of a floating rate bond that provides NPV, CleanPrice and DirtyPrice from observations of deposit rates for one-week to one-year and swap rates from two to fifteen years allows the model to be used for 
* what-if analysis
* market quotes
* back-testing
* real-time-risk through a simulation model 
* liquidity risk
All without any changes to the quantitative model.  Changing the subscription used to provide deposit and swap rates and adding an onward subscriptions of the NPV, Clean and Dirty prices allows the model to be used for different scenarios

```
namespace SampleModels

open Cephei.Cell
open Cephei.QL

type FloatingBondModel () as this =
    inherit Model ()
(* ... implementation ... *)
    // Index model for collection access
    do this.Bind()

    // Externally visible properties 
    member this.NPV         = NPV
    member this.CleanPrice  = CleanPrice
    member this.DirtyPrice  = DirtyPrice
    member this.Deposit1W   = d1wQuote    
    member this.Deposit1M   = d1mQuote
    member this.Deposit3h   = d3mQuote
    member this.Deposit6M   = d6mQuote
    member this.Deposit9M   = d9mQuote
    member this.Deposit1Y   = d1yQuote
    member this.Swap2Y      = s2yQuote
    member this.Swap3Y      = s3yQuote
    member this.Swap5Y      = s5yQuote
    member this.Swap10Y     = s10yQuote
    member this.Swap15Y     = s15yQuote
```

The full implementation of the model using [Cephei.QL](https://www.nuget.org/packages/Cephei.QL) for [QuantLib](https://www.quantlib.org/) functions  demonstrates why F# has been selected as the model scripting language

```
namespace SampleModels

open Cephei.Cell
open Cephei.QL

type FloatingBondModel () as this =
    inherit Model ()

    let calendar            = Fun.Times.Calendars.TARGET.Create ()
    let settlementDate      = DateTime (2018, 9, 18)
    let fixingDays          = 3u
    let settlementDays      = 3u
    let todaysDate          = Cell.Create (fun ()-> calendar.Advance (settlementDate, -(int fixingDays), QL.Times.TimeUnitEnum.Days, None, None))
    let S                   = Cell.Create (fun () -> Fun.Swapessions.Create ( todaysDate))

    (*
        Rate helpers
    *)
    let zc3mQuote           = 0.0096
    let zc6mQuote           = 0.0145
    let zc1yQuote           = 0.0194

    let zc3mRate            = S.With Fun.Quotes.SwapimpleQuote.Create (Some zc3mQuote)
    let zc6mRate            = Fun.Quotes.SwapimpleQuote.Create (Some zc6mQuote)
    let zc1yRate            = Fun.Quotes.SwapimpleQuote.Create (Some zc1yQuote)

    let zcBondsDayCounter   = Fun.Times.Daycounters.Actual365Fixed.Create () 

    let months m            = Fun.Times.Period.Create (m, QL.Times.TimeUnitEnum.Months)
    let ModifiedFollowing   = QL.Times.BusinessDayConventionEnum.ModifiedFollowing
    let zc3m                = Fun.Termstructures.Yield.DepositRateHelper.Create (zc3mRate, (months 3), fixingDays, calendar, ModifiedFollowing, true, zcBondsDayCounter) :> QL.Termstructures.Yield.IRateHelper
    let zc6m                = Fun.Termstructures.Yield.DepositRateHelper.Create (zc6mRate, (months 6), fixingDays, calendar, ModifiedFollowing, true, zcBondsDayCounter) :> QL.Termstructures.Yield.IRateHelper
    let zc1y                = Fun.Termstructures.Yield.DepositRateHelper.Create (zc1yRate, (months 12), fixingDays, calendar, ModifiedFollowing, true, zcBondsDayCounter) :> QL.Termstructures.Yield.IRateHelper

    let termStrucDayCounter = Fun.Times.Daycounters.ActualActual.Create (Some QL.Times.Daycounters.ActualActual.ConventionEnum.ISDA)
    let tolerance           = 1.0e-15
    
    (*
        Bond Data
    *)
    let redemption          = 100.0

    let issueDates          = [ DateTime (2015, 3, 15)
                              ; DateTime (2015, 6, 15)
                              ; DateTime (2016, 6, 30)
                              ; DateTime (2012, 11, 15)
                              ; DateTime (1997, 5, 15)
                              ]

    let maturities          = [ DateTime (2020, 8, 31)
                              ; DateTime (2021, 8, 31)
                              ; DateTime (2023, 8, 31)
                              ; DateTime (2028, 8, 31)
                              ; DateTime (2048, 5, 15)
                              ]
 
    let couponRates         = [ 0.02375
                              ; 0.04625
                              ; 0.03125
                              ; 0.04000
                              ; 0.04500
                              ]

    let marketQuotes        = [ 100.390625
                              ; 106.21875
                              ; 100.59375
                              ; 101.6875
                              ; 102.140625
                              ]

    let two2one a b         = List.map2 (fun e y -> (e,y)) a b
    let combine             = two2one (two2one issueDates maturities) (two2one couponRates marketQuotes)

    let quote               = List.map (fun q -> Fun.Quotes.SwapimpleQuote.Create (Some q)) marketQuotes 
    let quoteRate r         = Fun.Quotes.SwapimpleQuote.Create (Some r)
    let usCalendar          = Fun.Times.Calendars.UnitedStates.Create (Some QL.Times.Calendars.UnitedStates.MarketEnum.GovernmentBond)
    let unadjusted          = QL.Times.BusinessDayConventionEnum.Unadjusted 
    let backward            = QL.Times.DateGeneration.RuleEnum.Backward
    let semiannual          = Fun.Times.Period.Create (QL.Times.FrequencyEnum.Swapemiannual)
    let schedule i m        = Fun.Times.Swapchedule.Create (i, m, semiannual, usCalendar, unadjusted, unadjusted, backward, false, None, None)
    let coupons q           = Fun.Doubles.CreateVector ([q])
    let actualActualBond    = Fun.Times.Daycounters.ActualActual.Create (Some QL.Times.Daycounters.ActualActual.ConventionEnum.Bond)
    let fixedHelper q s c i = Fun.Termstructures.Yield.FixedRateBondHelper.Create (q, settlementDays, redemption, s, c, actualActualBond, Some unadjusted, Some redemption, Some i) :> QL.Termstructures.Yield.IRateHelper
    let schedules           = List.map2 schedule issueDates maturities
    let rateHelpers         = List.map (fun ((i,m),(c,q))-> fixedHelper (quoteRate q) (schedule i m) (coupons c) i) combine

    let bondInstruments     = Fun.Vector ([zc3m;zc6m;zc1y] @ rateHelpers)
    let bondTermStructure   = Fun.Termstructures.Yield.PiecewiseYieldCurveDiscountLogLinear.Create (settlementDate, bondInstruments, termStrucDayCounter, tolerance)

    (*
        curve building
    *)

    // Building of the Libor forecasting curve
    // deposits
    let d1wQuote            = Cell.CreateValue 0.043375
    let d1mQuote            = Cell.CreateValue 0.031875
    let d3mQuote            = Cell.CreateValue 0.0320375
    let d6mQuote            = Cell.CreateValue 0.03385
    let d9mQuote            = Cell.CreateValue 0.0338125
    let d1yQuote            = Cell.CreateValue 0.0335125
    // swaps
    let s2yQuote            = Cell.CreateValue 0.0295
    let s3yQuote            = Cell.CreateValue 0.0323
    let s5yQuote            = Cell.CreateValue 0.0359
    let s10yQuote           = Cell.CreateValue 0.0412
    let s15yQuote           = Cell.CreateValue 0.0433

    // SimpleQuote stores a value which can be manually changed;
    // other Quote subclasses could read the value from a database
    // or some kind of data feed.

    // deposits

    let d1wRate             = Cell.Create (fun () -> Fun.Quotes.SwapimpleQuote.Create (Some d1wQuote.Value))
    let d1mRate             = Cell.Create (fun () -> Fun.Quotes.SwapimpleQuote.Create (Some d1mQuote.Value))
    let d3mRate             = Cell.Create (fun () -> Fun.Quotes.SwapimpleQuote.Create (Some d3mQuote.Value))
    let d6mRate             = Cell.Create (fun () -> Fun.Quotes.SwapimpleQuote.Create (Some d6mQuote.Value))
    let d9mRate             = Cell.Create (fun () -> Fun.Quotes.SwapimpleQuote.Create (Some d9mQuote.Value))
    let d1yRate             = Cell.Create (fun () -> Fun.Quotes.SwapimpleQuote.Create (Some d1yQuote.Value))
    // swaps
    let s2yRate             = Cell.Create (fun () -> Fun.Quotes.SwapimpleQuote.Create (Some s2yQuote.Value))
    let s3yRate             = Cell.Create (fun () -> Fun.Quotes.SwapimpleQuote.Create (Some s3yQuote.Value))
    let s5yRate             = Cell.Create (fun () -> Fun.Quotes.SwapimpleQuote.Create (Some s5yQuote.Value))
    let s10yRate            = Cell.Create (fun () -> Fun.Quotes.SwapimpleQuote.Create (Some s10yQuote.Value))
    let s15yRate            = Cell.Create (fun () -> Fun.Quotes.SwapimpleQuote.Create (Some s15yQuote.Value))

    let depositDayCounter   = Fun.Times.Daycounters.Actual360.Create ()

    let period n t          = match t with
                              | 'w' -> Fun.Times.Period.Create (n, QL.Times.TimeUnitEnum.Weeks)
                              | 'm' -> Fun.Times.Period.Create (n, QL.Times.TimeUnitEnum.Months)
                              | 'y' -> Fun.Times.Period.Create (n, QL.Times.TimeUnitEnum.Years) 
                              | 'd' -> Fun.Times.Period.Create (n, QL.Times.TimeUnitEnum.Days) 
                              | _   -> raise (new Exception ("invalid period type"))

    let d1w                 = Cell.Create (fun () -> Fun.Termstructures.Yield.DepositRateHelper.Create (d1wRate.Value, (period 1 'w'), fixingDays, calendar, ModifiedFollowing, true, depositDayCounter))
    let d1m                 = Cell.Create (fun () -> Fun.Termstructures.Yield.DepositRateHelper.Create (d1mRate.Value, (period 1 'm'), fixingDays, calendar, ModifiedFollowing, true, depositDayCounter))
    let d3m                 = Cell.Create (fun () -> Fun.Termstructures.Yield.DepositRateHelper.Create (d3mRate.Value, (period 3 'm'), fixingDays, calendar, ModifiedFollowing, true, depositDayCounter))
    let d6m                 = Cell.Create (fun () -> Fun.Termstructures.Yield.DepositRateHelper.Create (d1wRate.Value, (period 6 'm'), fixingDays, calendar, ModifiedFollowing, true, depositDayCounter))
    let d9m                 = Cell.Create (fun () -> Fun.Termstructures.Yield.DepositRateHelper.Create (d9mRate.Value, (period 9 'm'), fixingDays, calendar, ModifiedFollowing, true, depositDayCounter))
    let d1y                 = Cell.Create (fun () -> Fun.Termstructures.Yield.DepositRateHelper.Create (d1yRate.Value, (period 1 'y'), fixingDays, calendar, ModifiedFollowing, true, depositDayCounter))

    // setup swaps
    let annual              = Cell.Create (fun () -> QL.Times.FrequencyEnum.Annual))
    let thirty360European   = Cell.Create (fun () -> Fun.Times.Daycounters.Thirty360.Create (Some QL.Times.Daycounters.Thirty360.ConventionEnum.European))
    let forwardStart        = Cell.Create (fun () -> period 1 'd')
    let swFloatingLegIndex  = Cell.Create (fun () -> Fun.Indexes.Ibor.Euribor.Create (period 6 'm'))
    let s2y                 = Cell.Create (fun () -> Fun.Termstructures.Yield.SwapwapRateHelper.Create (s2yRate.Value, (period 2 'y'), calendar, annual, unadjusted, thirty360European, swFloatingLegIndex, None, Some forwardStart, None))
    let s3y                 = Cell.Create (fun () -> Fun.Termstructures.Yield.SwapwapRateHelper.Create (s3yRate.Value, (period 3 'y'), calendar, annual, unadjusted, thirty360European, swFloatingLegIndex, None, Some forwardStart, None))
    let s5y                 = Cell.Create (fun () -> Fun.Termstructures.Yield.SwapwapRateHelper.Create (s5yRate.Value, (period 5 'y'), calendar, annual, unadjusted, thirty360European, swFloatingLegIndex, None, Some forwardStart, None))
    let s10y                = Cell.Create (fun () -> Fun.Termstructures.Yield.SwapwapRateHelper.Create (s10yRate.Value, (period 10 'y'), calendar, annual, unadjusted, thirty360European, swFloatingLegIndex, None, Some forwardStart, None))
    let s15y                = Cell.Create (fun () -> Fun.Termstructures.Yield.SwapwapRateHelper.Create (s15yRate.Value, (period 15 'y'), calendar, annual, unadjusted, thirty360European, swFloatingLegIndex, None, Some forwardStart, None))

    (*
        Curve building
    *)
    let tr p : QL.Termstructures.Yield.IRateHelper = p :> QL.Termstructures.Yield.IRateHelper
    let depoSwapInstruments = Cell.Create (fun () -> Fun.Vector ([tr d1w.Value; tr d1m.Value;tr d3m.Value;tr d6m.Value;tr d9m.Value;tr d1y.Value;tr s2y.Value;tr s3y.Value;tr s5y.Value;tr s10y.Value;tr s15y.Value]))
    let depoSwapTermStructure = Cell.Create (fun () -> Fun.Termstructures.Yield.PiecewiseYieldCurveDiscountLogLinear.Create (settlementDate, depoSwapInstruments.Value, termStrucDayCounter, tolerance))

    (*
        Bonds to be priced
    *)
    let faceAmount          = 100.0
    let bondEngine          = Fun.Pricingengines.Bond.DiscountingBondEngine.Create(Some (bondTermStructure :> QL.Termstructures.IYieldTermStructure), None) 
    let following           = QL.Times.BusinessDayConventionEnum.Following 

    // Floating rate bond (3M USD Libor + 0.1%)
    // Should and will be priced on another curve later...

    let libor3m             = Cell.Create (fun () ->
                              let t = Fun.Indexes.Ibor.USDLibor.Create ((period 3 'm'), Some (depoSwapTermStructure.Value :> QL.Termstructures.IYieldTermStructure))
                              t.AddFixing (new DateTime(2028,07,17), 0.0278625, None) :?> QL.Indexes.IIborIndex)
    let quarterly           = Fun.Times.Period.Create (QL.Times.FrequencyEnum.Quarterly)
    let usNYSE              = Fun.Times.Calendars.UnitedStates.Create (Some QL.Times.Calendars.UnitedStates.MarketEnum.NYSE)
    let floatingBondSchedule = Fun.Times.Swapchedule.Create (DateTime(2015,10,21), DateTime(2020,10,21), quarterly, usNYSE, unadjusted, unadjusted, QL.Times.DateGeneration.RuleEnum.Backward, true, None, None)

    // Coupon pricers

    let pricer              = Fun.Cashflows.BlackIborCouponPricer.Create (None)
    let volatility          = 0.0
    let Actual365Fixed      = Fun.Times.Daycounters.Actual365Fixed.Create ();
    let vol                 = Fun.Termstructures.Volatility.Optionlet.ConstantOptionletVolatility.Create (settlementDate, calendar, ModifiedFollowing,volatility, Actual365Fixed)
    //use fluent interface to set capvol
    let capletPricer        = pricer.SwapetCapletVolatility (Some (vol :> QL.Termstructures.Volatility.Optionlet.IOptionletVolatilityStructure))

    let floatingRateBond    = Cell.Create (fun () -> Fun.Instruments.Bonds.FloatingRateBond.Create (capletPricer, settlementDays, faceAmount, floatingBondSchedule, libor3m.Value, depositDayCounter, Some ModifiedFollowing, Some 2u, Some (coupons 1.0), Some (coupons 0.001), None, None, Some true, Some faceAmount, Some (DateTime(2015, 10, 21)), bondEngine))

    let NPV                 = Cell.Create (fun () -> floatingRateBond.Value.NPV)
    let CleanPrice          = Cell.Create (fun () -> floatingRateBond.Value.CleanPrice())
    let DirtyPrice          = Cell.Create (fun () -> floatingRateBond.Value.DirtyPrice())

    // Index model for collection access
    do this.Bind()

    // Externally visible properties 
    member this.NPV         = NPV
    member this.CleanPrice  = CleanPrice
    member this.DirtyPrice  = DirtyPrice
    member this.Deposit1W   = d1wQuote    
    member this.Deposit1M   = d1mQuote
    member this.Deposit3h   = d3mQuote
    member this.Deposit6M   = d6mQuote
    member this.Deposit9M   = d9mQuote
    member this.Deposit1Y   = d1yQuote
    member this.Swap2Y      = s2yQuote
    member this.Swap3Y      = s3yQuote
    member this.Swap5Y      = s5yQuote
    member this.Swap10Y     = s10yQuote
    member this.Swap15Y     = s15yQuote
```

