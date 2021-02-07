
namespace Cephei.Models

open QLNet
open Cephei.QL
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System
open System.Collections

type FixedRateBondModel 
    ( RefDate : ICell<QLNet.Date>
    , IssueDate : ICell<QLNet.Date>
    , SettlementDate : ICell<QLNet.Date>
    , Redemption : ICell<System.Double>
    , RateCoupon : ICell<Generic.List<System.Double>>
    , BondPricer : ICell<QLNet.IPricingEngine>
    ) as this =
    inherit Model<FixedRateBond> ()

(* functions *)
    let _RefDate = RefDate
    let _Globals = new GlobalsModel (_RefDate)
    let _calendar = _Globals.calendar
    let _IssueDate = IssueDate
    let _Adjusted = _Globals.Adjusted
    let _Semiannual = Fun.Period2 (value Frequency.Semiannual)
    let _SettlementDate = SettlementDate
    let _Redemption = Redemption
    let _fixedBondSchedule = Fun.Schedule _IssueDate _SettlementDate _Semiannual (triv null (fun () -> _calendar.Value :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value BusinessDayConvention.Unadjusted) (value DateGeneration.Rule.Backward) (value false) (value (null :> QLNet.Date)) (value (null :> QLNet.Date)) _Adjusted
    let _faceAmount = (value (Convert.ToDouble(100)))
    let _settlementDays = _Globals.settlementDays
    let _ActualActualBond = Fun.ActualActual1 (value ActualActual.Convention.Bond) (value (null :> QLNet.Schedule))
    let _RateCoupon = RateCoupon
    let _BondPricer = BondPricer
    let _bondEngine = _BondPricer
    let _FixedRateBond = Fun.FixedRateBond _settlementDays _faceAmount _fixedBondSchedule _RateCoupon (triv null (fun () -> _ActualActualBond.Value :> QLNet.DayCounter)) (value BusinessDayConvention.ModifiedFollowing) _Redemption _IssueDate (triv null (fun () -> _calendar.Value :> QLNet.Calendar)) (value (null :> QLNet.Period)) (value (null :> QLNet.Calendar)) (value BusinessDayConvention.Unadjusted) (value false) _bondEngine _RefDate
    let _actual360 = Fun.Actual360 (value false)
    let _NPV = _FixedRateBond.NPV
    let _Accruedcoupon = _FixedRateBond.AccruedAmount (value (null :> QLNet.Date))
    let _Yield = _FixedRateBond.Yield (triv null (fun () -> _actual360.Value :> QLNet.DayCounter)) (value Compounding.Compounded) (value Frequency.Annual) (value 1E-08) (value 100)
    let _Previouscoupon = _FixedRateBond.PreviousCouponRate (value (null :> QLNet.Date))
    let _Nextcoupon = _FixedRateBond.NextCouponRate (value (null :> QLNet.Date))
    let _DirtyPrice = _FixedRateBond.DirtyPrice
    let _CleanPrice = _FixedRateBond.CleanPrice

    do this.Bind (_FixedRateBond)

(* Externally visible/bindable properties *)
    member this.RefDate = _RefDate
    member this.IssueDate = _IssueDate
    member this.Semiannual = _Semiannual
    member this.SettlementDate = _SettlementDate
    member this.Redemption = _Redemption
    member this.faceAmount = _faceAmount
    member this.RateCoupon = _RateCoupon
    member this.FixedRateBond = _FixedRateBond
    member this.BondPricer = _BondPricer
    member this.NPV = _NPV
    member this.Accruedcoupon = _Accruedcoupon
    member this.Yield = _Yield
    member this.Previouscoupon = _Previouscoupon
    member this.Nextcoupon = _Nextcoupon
    member this.DirtyPrice = _DirtyPrice
    member this.CleanPrice = _CleanPrice


#if EXCEL

open ExcelDna.Integration
open Cephei.XL
open Cephei.XL.Helper

module FixedRateBondModelFunction =

    [<ExcelFunction(Name="__FixedRateBond", Description="Create a FixedRateBond",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="RefDate",Description = "reference to QLNet.Date")>]
        RefDate : obj)
        ([<ExcelArgument(Name="IssueDate",Description = "reference to QLNet.Date")>]
        IssueDate : obj)
        ([<ExcelArgument(Name="SettlementDate",Description = "reference to QLNet.Date")>]
        SettlementDate : obj)
        ([<ExcelArgument(Name="Redemption",Description = "reference to System.Double")>]
        Redemption : obj)
        ([<ExcelArgument(Name="RateCoupon",Description = "reference to System.Double")>]
        RateCoupon : obj)
        ([<ExcelArgument(Name="BondPricer",Description = "reference to QLNet.IPricingEngine")>]
        BondPricer : obj)

        = 
        if not (Model.IsInFunctionWizard()) then

            try
                let _RefDate = Helper.toCell<QLNet.Date> RefDate "RefDate"
                let _IssueDate = Helper.toCell<QLNet.Date> IssueDate "IssueDate"
                let _SettlementDate = Helper.toCell<QLNet.Date> SettlementDate "SettlementDate"
                let _Redemption = Helper.toCell<System.Double> Redemption "Redemption"
                let _RateCoupon = Helper.toCell<Generic.List<System.Double>> RateCoupon "RateCoupon"
                let _BondPricer = Helper.toCell<QLNet.IPricingEngine> BondPricer "BondPricer"

                let builder (current : ICell) = (new FixedRateBondModel
                                                                        ( _RefDate.cell
                                                                        , _IssueDate.cell
                                                                        , _SettlementDate.cell
                                                                        , _Redemption.cell
                                                                        , _RateCoupon.cell
                                                                        , _BondPricer.cell
                                                                        )
                                                                      ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> FixedRateBondModel) l
                let source () = Helper.sourceFold "new FixedRateBond"
                                               [| _RefDate.source
                                               ;  _IssueDate.source
                                               ;  _SettlementDate.source
                                               ;  _Redemption.source
                                               ;  _RateCoupon.source
                                               ;  _BondPricer.source
                                               |]

                let hash = Helper.hashFold
                                [| _RefDate.cell
                                ;  _IssueDate.cell
                                ;  _SettlementDate.cell
                                ;  _Redemption.cell
                                ;  _RateCoupon.cell
                                ;  _BondPricer.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FixedRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
                | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    [<ExcelFunction(Name="__FixedRateBond_Semiannual", Description="Create a QLNet.Period",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_Semiannual
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         FixedRateBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _FixedRateBond = Helper.toModel<FixedRateBondModel, FixedRateBond> FixedRateBond "FixedRateBond"  
            let builder (current : ICell) = (_FixedRateBond.cell :?> FixedRateBondModel).Semiannual :> ICell
            let format (o : QLNet.Period) (l:string) = Model.genericFormat o
            let source () = (_FixedRateBond.source + ".Semiannual")
            let hash = Helper.hashFold [| _FixedRateBond.cell |]
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
                            
    [<ExcelFunction(Name="__FixedRateBond_faceAmount", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_faceAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         FixedRateBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _FixedRateBond = Helper.toModel<FixedRateBondModel, FixedRateBond> FixedRateBond "FixedRateBond"  
            let builder (current : ICell) = (_FixedRateBond.cell :?> FixedRateBondModel).faceAmount :> ICell
            let format (o : System.Double) (l:string) = Model.genericFormat o
            let source () = (_FixedRateBond.source + ".faceAmount")
            let hash = Helper.hashFold [| _FixedRateBond.cell |]
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
                            
    [<ExcelFunction(Name="__FixedRateBond_FixedRateBond", Description="Create a QLNet.FixedRateBond",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_FixedRateBond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         FixedRateBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _FixedRateBond = Helper.toModel<FixedRateBondModel, FixedRateBond> FixedRateBond "FixedRateBond"  
            let builder (current : ICell) = (_FixedRateBond.cell :?> FixedRateBondModel).FixedRateBond :> ICell
            let format (o : QLNet.FixedRateBond) (l:string) = Model.genericFormat o
            let source () = (_FixedRateBond.source + ".FixedRateBond")
            let hash = Helper.hashFold [| _FixedRateBond.cell |]
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
                            
    [<ExcelFunction(Name="__FixedRateBond_NPV", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         FixedRateBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _FixedRateBond = Helper.toModel<FixedRateBondModel, FixedRateBond> FixedRateBond "FixedRateBond"  
            let builder (current : ICell) = (_FixedRateBond.cell :?> FixedRateBondModel).NPV :> ICell
            let format (o : System.Double) (l:string) = Model.genericFormat o
            let source () = (_FixedRateBond.source + ".NPV")
            let hash = Helper.hashFold [| _FixedRateBond.cell |]
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
                            
    [<ExcelFunction(Name="__FixedRateBond_Accruedcoupon", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_Accruedcoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         FixedRateBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _FixedRateBond = Helper.toModel<FixedRateBondModel, FixedRateBond> FixedRateBond "FixedRateBond"  
            let builder (current : ICell) = (_FixedRateBond.cell :?> FixedRateBondModel).Accruedcoupon :> ICell
            let format (o : System.Double) (l:string) = Model.genericFormat o
            let source () = (_FixedRateBond.source + ".Accruedcoupon")
            let hash = Helper.hashFold [| _FixedRateBond.cell |]
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
                            
    [<ExcelFunction(Name="__FixedRateBond_Yield", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_Yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         FixedRateBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toModel<FixedRateBondModel, FixedRateBond> FixedRateBond "FixedRateBond"  
                let builder (current : ICell) = (_FixedRateBond.cell :?> FixedRateBondModel).Yield :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_FixedRateBond.source + ".Yield")
                let hash = Helper.hashFold [| _FixedRateBond.cell |]
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
                            
    [<ExcelFunction(Name="__FixedRateBond_Previouscoupon", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_Previouscoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         FixedRateBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toModel<FixedRateBondModel, FixedRateBond> FixedRateBond "FixedRateBond"  
                let builder (current : ICell) = (_FixedRateBond.cell :?> FixedRateBondModel).Previouscoupon :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_FixedRateBond.source + ".Previouscoupon")
                let hash = Helper.hashFold [| _FixedRateBond.cell |]
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
                            
    [<ExcelFunction(Name="__FixedRateBond_Nextcoupon", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_Nextcoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         FixedRateBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toModel<FixedRateBondModel, FixedRateBond> FixedRateBond "FixedRateBond"  
                let builder (current : ICell) = (_FixedRateBond.cell :?> FixedRateBondModel).Nextcoupon :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_FixedRateBond.source + ".Nextcoupon")
                let hash = Helper.hashFold [| _FixedRateBond.cell |]
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
                            
    [<ExcelFunction(Name="__FixedRateBond_DirtyPrice", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_DirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         FixedRateBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toModel<FixedRateBondModel, FixedRateBond> FixedRateBond "FixedRateBond"  
                let builder (current : ICell) = (_FixedRateBond.cell :?> FixedRateBondModel).DirtyPrice :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_FixedRateBond.source + ".DirtyPrice")
                let hash = Helper.hashFold [| _FixedRateBond.cell |]
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
                            
    [<ExcelFunction(Name="__FixedRateBond_CleanPrice", Description="Create a System.Double",Category="Cephei Models", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FixedRateBond_CleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FixedRateBond",Description = "FixedRateBond")>] 
         FixedRateBond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FixedRateBond = Helper.toModel<FixedRateBondModel, FixedRateBond> FixedRateBond "FixedRateBond"  
                let builder (current : ICell) = (_FixedRateBond.cell :?> FixedRateBondModel).CleanPrice :> ICell
                let format (o : System.Double) (l:string) = Model.genericFormat o
                let source () = (_FixedRateBond.source + ".CleanPrice")
                let hash = Helper.hashFold [| _FixedRateBond.cell |]
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
