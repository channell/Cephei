
namespace Cephei.Models

open QLNet
open Cephei.QL
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System
open System.Collections

type GlobalsModel 
    ( settlementDate : ICell<QLNet.Date>
    ) as this =
    inherit Model<Date> ()

(* functions *)
    let _calendar = Fun.TARGET()
    let _settlementDays = (value (Convert.ToInt32(3)))
    let _fixingDays = (value (Convert.ToInt32(3)))
    let _fixingDaysNeg = (value (Convert.ToInt32(-3)))
    let _zcBondsDayCounter = Fun.Actual365Fixed()
    let _USgovi = Fun.UnitedStates (value UnitedStates.Market.GovernmentBond)
    let _Semiannual = Fun.Period2 (value Frequency.Semiannual)
    let _ActualActualBond = Fun.ActualActual1 (value ActualActual.Convention.Bond) (value (null :> QLNet.Schedule))
    let _depositDayCounter = Fun.Actual360 (value false)
    let _loglinier = Fun.LogLinear ()
    let _discount = Fun.Discount ()
    let _termStructureDayCounter = Fun.ActualActual1 (value ActualActual.Convention.ISDA) (value (null :> QLNet.Schedule))
    let _actual360 = Fun.Actual360 (value false)
    let _settlementDate = settlementDate
    let _Quarterly = Fun.Period2 (value Frequency.Quarterly)
    let _Adjusted = _calendar.Adjust _settlementDate (value BusinessDayConvention.Following)
    let _Actual365Fixed = Fun.Actual365Fixed()
    let _todaysDate = _calendar.Advance1 _settlementDate _fixingDaysNeg (value TimeUnit.Days) (value BusinessDayConvention.Following) (value false)
    let _forwardStart = Fun.Period (value (Convert.ToInt32(1))) (value TimeUnit.Days)
    let _swFloatingLegIndex = Fun.Euribor6M1()
    let _swFixedLegDayCounter = Fun.Thirty360 (value Thirty360.Thirty360Convention.European)

    do this.Bind (_settlementDate)

(* Externally visible/bindable properties *)
    member this.calendar = _calendar
    member this.settlementDays = _settlementDays
    member this.fixingDays = _fixingDays
    member this.fixingDaysNeg = _fixingDaysNeg
    member this.zcBondsDayCounter = _zcBondsDayCounter
    member this.USgovi = _USgovi
    member this.Semiannual = _Semiannual
    member this.ActualActualBond = _ActualActualBond
    member this.depositDayCounter = _depositDayCounter
    member this.loglinier = _loglinier
    member this.discount = _discount
    member this.termStructureDayCounter = _termStructureDayCounter
    member this.actual360 = _actual360
    member this.settlementDate = _settlementDate
    member this.Quarterly = _Quarterly
    member this.Adjusted = _Adjusted
    member this.Actual365Fixed = _Actual365Fixed
    member this.todaysDate = _todaysDate
    member this.forwardStart = _forwardStart
    member this.swFloatingLegIndex = _swFloatingLegIndex
    member this.swFixedLegDayCounter = _swFixedLegDayCounter


#if EXCEL

open ExcelDna.Integration
open Cephei.XL
open Cephei.XL.Helper

module GlobalsModelFunction =

    [<ExcelFunction(Name="__Globals", Description="Create a GlobalsModel",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="__settlementDate",Description = "reference to QLNet.Date")>]
        settlementDate : obj)

        = 
        if not (Model.IsInFunctionWizard()) then

            try
                let _settlementDate = Helper.toCell<QLNet.Date> settlementDate "settlementDate"

                let builder (current : ICell) = withMnemonic mnemonic (new GlobalsModel
                                                                        ( _settlementDate.cell )

                                                                      ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> GlobalsModel) l
                let source () = Helper.sourceFold "new GlobalsModel"
                                               [| _settlementDate.source
                                               |]

                let hash = Helper.hashFold
                                [| _settlementDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GlobalsModel> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
                        with
                        | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    [<ExcelFunction(Name="__Globals_calendar", Description="Create a QLNet.TARGET",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).calendar :> ICell
            let format (o : QLNet.TARGET) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".calendar")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_settlementDays", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).settlementDays :> ICell
            let format (o : System.Int32) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".settlementDays")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_fixingDays", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).fixingDays :> ICell
            let format (o : System.Int32) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".fixingDays")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_fixingDaysNeg", Description="Create a System.Int32",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_fixingDaysNeg
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).fixingDaysNeg :> ICell
            let format (o : System.Int32) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".fixingDaysNeg")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_zcBondsDayCounter", Description="Create a QLNet.Actual365Fixed",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_zcBondsDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).zcBondsDayCounter :> ICell
            let format (o : QLNet.Actual365Fixed) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".zcBondsDayCounter")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_USgovi", Description="Create a QLNet.UnitedStates",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_USgovi
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).USgovi :> ICell
            let format (o : QLNet.UnitedStates) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".USgovi")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_Semiannual", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_Semiannual
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).Semiannual :> ICell
            let format (o : QLNet.Period) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".Semiannual")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_ActualActualBond", Description="Create a QLNet.ActualActual",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_ActualActualBond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).ActualActualBond :> ICell
            let format (o : QLNet.ActualActual) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".ActualActualBond")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_depositDayCounter", Description="Create a QLNet.Actual360",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_depositDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).depositDayCounter :> ICell
            let format (o : QLNet.Actual360) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".depositDayCounter")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_loglinier", Description="Create a QLNet.LogLinear",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_loglinier
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).loglinier :> ICell
            let format (o : QLNet.LogLinear) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".loglinier")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_discount", Description="Create a QLNet.Discount",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).discount :> ICell
            let format (o : QLNet.Discount) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".discount")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_termStructureDayCounter", Description="Create a QLNet.ActualActual",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_termStructureDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).termStructureDayCounter :> ICell
            let format (o : QLNet.ActualActual) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".termStructureDayCounter")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_actual360", Description="Create a QLNet.Actual360",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_actual360
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).actual360 :> ICell
            let format (o : QLNet.Actual360) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".actual360")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_Quarterly", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_Quarterly
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).Quarterly :> ICell
            let format (o : QLNet.Period) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".Quarterly")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_Adjusted", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_Adjusted
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).Adjusted :> ICell
            let format (o : QLNet.Date) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".Adjusted")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_Actual365Fixed", Description="Create a QLNet.Actual365Fixed",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_Actual365Fixed
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).Actual365Fixed :> ICell
            let format (o : QLNet.Actual365Fixed) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".Actual365Fixed")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_todaysDate", Description="Create a QLNet.Date",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_todaysDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).todaysDate :> ICell
            let format (o : QLNet.Date) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".todaysDate")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_forwardStart", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_forwardStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).forwardStart :> ICell
            let format (o : QLNet.Period) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".forwardStart")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_swFloatingLegIndex", Description="Create a QLNet.Euribor6M",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_swFloatingLegIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).swFloatingLegIndex :> ICell
            let format (o : QLNet.Euribor6M) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".swFloatingLegIndex")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
                            
    [<ExcelFunction(Name="__Globals_swFixedLegDayCounter", Description="Create a QLNet.Thirty360",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GlobalsModel_swFixedLegDayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GlobalsModel",Description = "GlobalsModel")>] 
         GlobalsModel : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _GlobalsModel = Helper.toModel<GlobalsModel, Date> GlobalsModel "GlobalsModel"  
            let builder (current : ICell) = withMnemonic mnemonic (_GlobalsModel.cell :?> GlobalsModel).swFixedLegDayCounter :> ICell
            let format (o : QLNet.Thirty360) (l:string) = Model.genericFormat o
            let source () = (_GlobalsModel.source + ".swFixedLegDayCounter")
            let hash = Helper.hashFold [| _GlobalsModel.cell |]
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
