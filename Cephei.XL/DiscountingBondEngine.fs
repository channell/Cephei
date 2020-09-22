namespace Cephei.XL

open ExcelDna.Integration
open ExcelDna.Integration.Rtd
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open Cephei.QL.Util
open System.Collections
open System
open QLNet
open Cephei.XL.Helper


module DiscountingBondEngine = 

    [<ExcelFunction(Name="_DiscountingBondEngine", Description="",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DiscountingBondEngine_Create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         discountCurve : string)
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         includeSettlementDateFlows : string)
        = 

        let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
        let _includeSettlementDateFlows = Helper.toNullable<bool> includeSettlementDateFlows "includeSettlementDateFlows"

        let builder () = (withMnemonic mnemonic (Fun.DiscountingBondEngine _discountCurve.cell _includeSettlementDateFlows.cell)) :> ICell
        let format (i:DiscountingBondEngineModel) (l:string) = i :> obj

        Model.specify 
            { mnemonic = mnemonic
            ; creator = builder
            ; subscriber = Helper.subscriber format
            ; source = Helper.sourceFold  "Fun.DiscountingBondEngine" [|_discountCurve.source; _includeSettlementDateFlows.source|]
            ; hash = Helper.hashFold [|_discountCurve.cell; _includeSettlementDateFlows.cell|]
            } :?> string

    [<ExcelFunction(Name="_BusinessDayConvention", Description="",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BusinessDayConvention_Creeate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         value: string)
        =

        let _BusinessDayConvention : BusinessDayConvention =  Enum.Parse(typeof<BusinessDayConvention>, value) :?> BusinessDayConvention

        let builder () = Util.value _BusinessDayConvention :> ICell
        let format (i : BusinessDayConvention) (l:string) = i.ToString() :> obj

        Model.specify 
            { mnemonic = mnemonic
            ; creator = builder
            ; subscriber = Helper.subscriber format
            ; source = "value " + _BusinessDayConvention.ToString()
            ; hash = _BusinessDayConvention.GetHashCode()
            } :?> string
