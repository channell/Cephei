namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections
open System
open QLNet
open Cephei.XL.Helper

module BondFunctions = 
    (*
        Object creation functions    
    *)
    [<ExcelFunction(Name="_Bond", Description="Create a Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_Bond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="")>]
         settlementDays : obj)
        ([<ExcelArgument(Name="")>]
         calendar : obj)
        ([<ExcelArgument(Name="")>]
         faceAmmount : obj)
        ([<ExcelArgument(Name="")>]
         maturityDate : obj)
        ([<ExcelArgument(Name="")>]
         issueDate : obj)
        ([<ExcelArgument(Name="")>]
         cashflows : obj)
        ([<ExcelArgument(Name="")>]
         pricingEngine : obj)
        ([<ExcelArgument(Name="")>]
         evaludationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" true
                let _calendar = Helper.toCell<Calendar> calendar "calendar" true
                let _faceAmount = Helper.toCell<double> faceAmmount "faceAmmount" true
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" true
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" true
                let _cashflows = Helper.toCell<Generic.List<CashFlow>> cashflows "cashflows" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true
                let _evaluationDate = Helper.toCell<Date> evaludationDate "evaludationDate" true

                let builder () = withMnemonic mnemonic (Fun.Bond 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _faceAmount.cell 
                                                            _maturityDate.cell 
                                                            _issueDate.cell 
                                                            _cashflows.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Bond>) l

                let source = Helper.sourceFold "Fun.Bond" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _faceAmount.source
                                               ;  _maturityDate.source
                                               ;  _issueDate.source
                                               ;  _cashflows.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]

                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;   _calendar.cell
                                ;  _faceAmount.cell
                                ;  _maturityDate.cell
                                ;  _issueDate.cell
                                ;  _cashflows.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        Functions of obj
    *)
    [<ExcelFunction(Name="_Bond_cleanPrice", Description="",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the Bondue")>] 
         bond : string)
        = 

        if not (Model.IsInFunctionWizard()) then
                                                        
            try
    
                let _Bond = Helper.toCell<Bond> bond "bond" true

                let builder () = withMnemonic mnemonic ((_Bond.cell :?> BondModel).CleanPrice 
                                                       ):> ICell
                let format (i:double) (l:string) = i :> obj
         
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = _Bond.source + ".CleanPrice"
                    ; hash = _Bond.cell.Mnemonic.GetHashCode()
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    [<ExcelFunction(Name="_Bond_AccruedAmount", Description="",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_AccruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         bond : string)
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         settlement : obj)
        = 

        if not (Model.IsInFunctionWizard()) then

            try

                let _Bond = Helper.toCell<Bond> bond "bond" true
                let _settlement = Helper.toCell<Date> settlement "settlement" true


                let builder () = withMnemonic mnemonic ((_Bond.cell :?> BondModel).AccruedAmount 
                                                            _settlement.cell
                                                       ) :> ICell
                let format (i:double) (l:string) = i :> obj

                let source = Helper.sourceFold (_Bond.source + ".AccruedAmount") 
                                               [|_settlement.source
                                               |] 
         
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = Helper.sourceFold (_Bond.source + ".AccruedAmount") [|_settlement.source|] 
                    ; hash = Helper.hashFold [|_Bond.cell; _settlement.cell|] 
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        Range Function
    *)

    [<ExcelFunction(Name="_Bond_Range", Description="Create a range of Bond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the value")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Bond> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Bond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Bond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Bond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

