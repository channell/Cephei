
namespace Cephei.Models

open QLNet
open Cephei.QL
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System
open System.Collections

type StandardModel
    (    ) as this =
    inherit Model<obj> ()

(* functions *)
    let _calendar = Fun.TARGET()
    let _settlementDays = (value (Convert.ToInt32(3)))
    let _USgovi = Fun.UnitedStates (value UnitedStates.Market.GovernmentBond)
    let _Semiannual = Fun.Period2 (value Frequency.Semiannual)
    let _fixingDays = (value (Convert.ToInt32(3)))
    let _ActualActualBond = Fun.ActualActual1 (value ActualActual.Convention.Bond) (value (null :> QLNet.Schedule))
    let _depositDayCounter = Fun.Actual360 (value false)
    let _loglinier = Fun.LogLinear ()
    let _termStructureDayCounter = Fun.ActualActual1 (value ActualActual.Convention.ISDA) (value (null :> QLNet.Schedule))
    let _discount = Fun.Discount ()
    let _actual360 = Fun.Actual360 (value false)
    let _Quarterly = Fun.Period2 (value Frequency.Quarterly)
    let _Actual365Fixed = Fun.Actual365Fixed()
    let _fixingDaysNeg = (value (Convert.ToInt32(-3)))
    let _forwardStart = Fun.Period (value (Convert.ToInt32(1))) (value TimeUnit.Days)
    let _swFloatingLegIndex = Fun.Euribor6M1()
    let _swFixedLegDayCounter = Fun.Thirty360 (value Thirty360.Thirty360Convention.European)

    do this.Bind (null)

(* Externally visible/bindable properties *)
    member this.calendar = _calendar
    member this.settlementDays = _settlementDays
    member this.USgovi = _USgovi
    member this.Semiannual = _Semiannual
    member this.fixingDays = _fixingDays
    member this.ActualActualBond = _ActualActualBond
    member this.depositDayCounter = _depositDayCounter
    member this.loglinier = _loglinier
    member this.termStructureDayCounter = _termStructureDayCounter
    member this.discount = _discount
    member this.actual360 = _actual360
    member this.Quarterly = _Quarterly
    member this.Actual365Fixed = _Actual365Fixed
    member this.fixingDaysNeg = _fixingDaysNeg
    member this.forwardStart = _forwardStart
    member this.swFloatingLegIndex = _swFloatingLegIndex
    member this.swFixedLegDayCounter = _swFixedLegDayCounter


#if EXCEL

open ExcelDna.Integration
open Cephei.XL
open Cephei.XL.Helper

module StandardsFunction =

    [<ExcelFunction(Name="__Standards", Description="Create a Standards",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)

        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (new StandardModel ()

                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> StandardModel) l
                let source () = Helper.sourceFold "new StandardsModel "
                                               [|                                               |]

                let hash = Helper.hashFold
                                [|                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<StandardModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
                        with
                        | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    [<ExcelFunction(Name="__Standards_discount", Description="Create a QLNet.Discount",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Standards",Description = "Standards")>] 
         Standards : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Standards = Helper.toModel<StandardModel, obj> Standards "Standards"  
            let builder (current : ICell) = withMnemonic mnemonic (_Standards.cell :?> StandardModel).discount :> ICell
            let format (o : QLNet.Discount) (l:string) = Model.genericFormat o
            let source () = (_Standards.source + ".discount")
            let hash = Helper.hashFold [| _Standards.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__Standards_depositDayCounter", Description="Create a QLNet.Actual360",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_depositDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Standards",Description = "Standards")>] 
         Standards : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Standards = Helper.toModel<StandardModel, obj> Standards "Standards"  
            let builder (current : ICell) = withMnemonic mnemonic (_Standards.cell :?> StandardModel).depositDayCounter :> ICell
            let format (o : QLNet.Actual360) (l:string) = Model.genericFormat o
            let source () = (_Standards.source + ".depositDayCounter")
            let hash = Helper.hashFold [| _Standards.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__Standards_loglinier", Description="Create a QLNet.LogLinear",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_loglinier
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Standards",Description = "Standards")>] 
         Standards : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Standards = Helper.toModel<StandardModel, obj> Standards "Standards"  
            let builder (current : ICell) = withMnemonic mnemonic (_Standards.cell :?> StandardModel).loglinier :> ICell
            let format (o : QLNet.LogLinear) (l:string) = Model.genericFormat o
            let source () = (_Standards.source + ".loglinier")
            let hash = Helper.hashFold [| _Standards.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__Standards_swFloatingLegIndex", Description="Create a QLNet.Euribor6M",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_swFloatingLegIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Standards",Description = "Standards")>] 
         Standards : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Standards = Helper.toModel<StandardModel, obj> Standards "Standards"  
            let builder (current : ICell) = withMnemonic mnemonic (_Standards.cell :?> StandardModel).swFloatingLegIndex :> ICell
            let format (o : QLNet.Euribor6M) (l:string) = Model.genericFormat o
            let source () = (_Standards.source + ".swFloatingLegIndex")
            let hash = Helper.hashFold [| _Standards.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__Standards_USgovi", Description="Create a QLNet.UnitedStates",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_USgovi
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Standards",Description = "Standards")>] 
         Standards : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Standards = Helper.toModel<StandardModel, obj> Standards "Standards"  
            let builder (current : ICell) = withMnemonic mnemonic (_Standards.cell :?> StandardModel).USgovi :> ICell
            let format (o : QLNet.UnitedStates) (l:string) = Model.genericFormat o
            let source () = (_Standards.source + ".USgovi")
            let hash = Helper.hashFold [| _Standards.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__Standards_Semiannual", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_Semiannual
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Standards",Description = "Standards")>] 
         Standards : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Standards = Helper.toModel<StandardModel, obj> Standards "Standards"  
            let builder (current : ICell) = withMnemonic mnemonic (_Standards.cell :?> StandardModel).Semiannual :> ICell
            let format (o : QLNet.Period) (l:string) = Model.genericFormat o
            let source () = (_Standards.source + ".Semiannual")
            let hash = Helper.hashFold [| _Standards.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__Standards_Quarterly", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_Quarterly
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Standards",Description = "Standards")>] 
         Standards : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Standards = Helper.toModel<StandardModel, obj> Standards "Standards"  
            let builder (current : ICell) = withMnemonic mnemonic (_Standards.cell :?> StandardModel).Quarterly :> ICell
            let format (o : QLNet.Period) (l:string) = Model.genericFormat o
            let source () = (_Standards.source + ".Quarterly")
            let hash = Helper.hashFold [| _Standards.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__Standards_actual360", Description="Create a QLNet.Actual360",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_actual360
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Standards",Description = "Standards")>] 
         Standards : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Standards = Helper.toModel<StandardModel, obj> Standards "Standards"  
            let builder (current : ICell) = withMnemonic mnemonic (_Standards.cell :?> StandardModel).actual360 :> ICell
            let format (o : QLNet.Actual360) (l:string) = Model.genericFormat o
            let source () = (_Standards.source + ".actual360")
            let hash = Helper.hashFold [| _Standards.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__Standards_swFixedLegDayCounter", Description="Create a QLNet.Thirty360",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_swFixedLegDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Standards",Description = "Standards")>] 
         Standards : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Standards = Helper.toModel<StandardModel, obj> Standards "Standards"  
            let builder (current : ICell) = withMnemonic mnemonic (_Standards.cell :?> StandardModel).swFixedLegDayCounter :> ICell
            let format (o : QLNet.Thirty360) (l:string) = Model.genericFormat o
            let source () = (_Standards.source + ".swFixedLegDayCounter")
            let hash = Helper.hashFold [| _Standards.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__Standards_settlementDays", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Standards",Description = "Standards")>] 
         Standards : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Standards = Helper.toModel<StandardModel, obj> Standards "Standards"  
            let builder (current : ICell) = withMnemonic mnemonic (_Standards.cell :?> StandardModel).settlementDays :> ICell
            let format (o : System.Int32) (l:string) = Model.genericFormat o
            let source () = (_Standards.source + ".settlementDays")
            let hash = Helper.hashFold [| _Standards.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__Standards_fixingDays", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Standards",Description = "Standards")>] 
         Standards : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Standards = Helper.toModel<StandardModel, obj> Standards "Standards"  
            let builder (current : ICell) = withMnemonic mnemonic (_Standards.cell :?> StandardModel).fixingDays :> ICell
            let format (o : System.Int32) (l:string) = Model.genericFormat o
            let source () = (_Standards.source + ".fixingDays")
            let hash = Helper.hashFold [| _Standards.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__Standards_Actual365Fixed", Description="Create a QLNet.Actual365Fixed",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_Actual365Fixed
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Standards",Description = "Standards")>] 
         Standards : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Standards = Helper.toModel<StandardModel, obj> Standards "Standards"  
            let builder (current : ICell) = withMnemonic mnemonic (_Standards.cell :?> StandardModel).Actual365Fixed :> ICell
            let format (o : QLNet.Actual365Fixed) (l:string) = Model.genericFormat o
            let source () = (_Standards.source + ".Actual365Fixed")
            let hash = Helper.hashFold [| _Standards.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__Standards_ActualActualBond", Description="Create a QLNet.ActualActual",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_ActualActualBond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Standards",Description = "Standards")>] 
         Standards : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Standards = Helper.toModel<StandardModel, obj> Standards "Standards"  
            let builder (current : ICell) = withMnemonic mnemonic (_Standards.cell :?> StandardModel).ActualActualBond :> ICell
            let format (o : QLNet.ActualActual) (l:string) = Model.genericFormat o
            let source () = (_Standards.source + ".ActualActualBond")
            let hash = Helper.hashFold [| _Standards.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__Standards_forwardStart", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_forwardStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Standards",Description = "Standards")>] 
         Standards : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Standards = Helper.toModel<StandardModel, obj> Standards "Standards"  
            let builder (current : ICell) = withMnemonic mnemonic (_Standards.cell :?> StandardModel).forwardStart :> ICell
            let format (o : QLNet.Period) (l:string) = Model.genericFormat o
            let source () = (_Standards.source + ".forwardStart")
            let hash = Helper.hashFold [| _Standards.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__Standards_termStructureDayCounter", Description="Create a QLNet.ActualActual",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_termStructureDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Standards",Description = "Standards")>] 
         Standards : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Standards = Helper.toModel<StandardModel, obj> Standards "Standards"  
            let builder (current : ICell) = withMnemonic mnemonic (_Standards.cell :?> StandardModel).termStructureDayCounter :> ICell
            let format (o : QLNet.ActualActual) (l:string) = Model.genericFormat o
            let source () = (_Standards.source + ".termStructureDayCounter")
            let hash = Helper.hashFold [| _Standards.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__Standards_calendar", Description="Create a QLNet.TARGET",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Standards",Description = "Standards")>] 
         Standards : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Standards = Helper.toModel<StandardModel, obj> Standards "Standards"  
            let builder (current : ICell) = withMnemonic mnemonic (_Standards.cell :?> StandardModel).calendar :> ICell
            let format (o : QLNet.TARGET) (l:string) = Model.genericFormat o
            let source () = (_Standards.source + ".calendar")
            let hash = Helper.hashFold [| _Standards.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
    [<ExcelFunction(Name="__Standards_fixingDaysNeg", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Standards_fixingDaysNeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Standards",Description = "Standards")>] 
         Standards : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _Standards = Helper.toModel<StandardModel, obj> Standards "Standards"  
            let builder (current : ICell) = withMnemonic mnemonic (_Standards.cell :?> StandardModel).fixingDaysNeg :> ICell
            let format (o : System.Int32) (l:string) = Model.genericFormat o
            let source () = (_Standards.source + ".fixingDaysNeg")
            let hash = Helper.hashFold [| _Standards.cell |]
            Model.specify 
                { mnemonic = Model.formatMnemonic mnemonic
                ; creator = builder
                ; subscriber = Helper.subscriber format
                ; source = source 
                ; hash = hash
                } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
                            
#endif
