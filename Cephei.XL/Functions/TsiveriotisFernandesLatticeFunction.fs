(*
Copyright (C) 2020 Cepheis Ltd (steve.channell@cepheis.com)

This file is part of Cephei.QL Project https://github.com/channell/Cephei

Cephei.QL is open source software based on QLNet  you can redistribute it and/or modify it
under the terms of the Cephei.QL license.  You should have received a
copy of the license along with this program; if not, license is
available at <https://github.com/channell/Cephei/LICENSE>.

QLNet is a based on QuantLib, a free-software/open-source library
for financial quantitative analysts and developers - http://quantlib.org/
The QuantLib license is available online at http://quantlib.org/license.shtml.

This program is distributed in the hope that it will be useful, but WITHOUT
ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
FOR A PARTICULAR PURPOSE.  See the license for more details.
*)
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections
open System
open System.Linq
open QLNet
open Cephei.XL.Helper

(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module TsiveriotisFernandesLatticeFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TsiveriotisFernandesLattice_partialRollback", Description="Create a TsiveriotisFernandesLattice",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TsiveriotisFernandesLattice_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TsiveriotisFernandesLattice",Description = "Reference to TsiveriotisFernandesLattice")>] 
         tsiveriotisfernandeslattice : obj)
        ([<ExcelArgument(Name="asset",Description = "Reference to asset")>] 
         asset : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TsiveriotisFernandesLattice = Helper.toCell<TsiveriotisFernandesLattice> tsiveriotisfernandeslattice "TsiveriotisFernandesLattice" true 
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" true
                let _To = Helper.toCell<double> To "To" true
                let builder () = withMnemonic mnemonic ((_TsiveriotisFernandesLattice.cell :?> TsiveriotisFernandesLatticeModel).PartialRollback
                                                            _asset.cell 
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : TsiveriotisFernandesLattice) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TsiveriotisFernandesLattice.source + ".PartialRollback") 
                                               [| _TsiveriotisFernandesLattice.source
                                               ;  _asset.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TsiveriotisFernandesLattice.cell
                                ;  _asset.cell
                                ;  _To.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TsiveriotisFernandesLattice_rollback", Description="Create a TsiveriotisFernandesLattice",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TsiveriotisFernandesLattice_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TsiveriotisFernandesLattice",Description = "Reference to TsiveriotisFernandesLattice")>] 
         tsiveriotisfernandeslattice : obj)
        ([<ExcelArgument(Name="asset",Description = "Reference to asset")>] 
         asset : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TsiveriotisFernandesLattice = Helper.toCell<TsiveriotisFernandesLattice> tsiveriotisfernandeslattice "TsiveriotisFernandesLattice" true 
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" true
                let _To = Helper.toCell<double> To "To" true
                let builder () = withMnemonic mnemonic ((_TsiveriotisFernandesLattice.cell :?> TsiveriotisFernandesLatticeModel).Rollback
                                                            _asset.cell 
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : TsiveriotisFernandesLattice) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TsiveriotisFernandesLattice.source + ".Rollback") 
                                               [| _TsiveriotisFernandesLattice.source
                                               ;  _asset.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TsiveriotisFernandesLattice.cell
                                ;  _asset.cell
                                ;  _To.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TsiveriotisFernandesLattice_stepback", Description="Create a TsiveriotisFernandesLattice",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TsiveriotisFernandesLattice_stepback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TsiveriotisFernandesLattice",Description = "Reference to TsiveriotisFernandesLattice")>] 
         tsiveriotisfernandeslattice : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="values",Description = "Reference to values")>] 
         values : obj)
        ([<ExcelArgument(Name="conversionProbability",Description = "Reference to conversionProbability")>] 
         conversionProbability : obj)
        ([<ExcelArgument(Name="spreadAdjustedRate",Description = "Reference to spreadAdjustedRate")>] 
         spreadAdjustedRate : obj)
        ([<ExcelArgument(Name="newValues",Description = "Reference to newValues")>] 
         newValues : obj)
        ([<ExcelArgument(Name="newConversionProbability",Description = "Reference to newConversionProbability")>] 
         newConversionProbability : obj)
        ([<ExcelArgument(Name="newSpreadAdjustedRate",Description = "Reference to newSpreadAdjustedRate")>] 
         newSpreadAdjustedRate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TsiveriotisFernandesLattice = Helper.toCell<TsiveriotisFernandesLattice> tsiveriotisfernandeslattice "TsiveriotisFernandesLattice" true 
                let _i = Helper.toCell<int> i "i" true
                let _values = Helper.toCell<Vector> values "values" true
                let _conversionProbability = Helper.toCell<Vector> conversionProbability "conversionProbability" true
                let _spreadAdjustedRate = Helper.toCell<Vector> spreadAdjustedRate "spreadAdjustedRate" true
                let _newValues = Helper.toCell<Vector> newValues "newValues" true
                let _newConversionProbability = Helper.toCell<Vector> newConversionProbability "newConversionProbability" true
                let _newSpreadAdjustedRate = Helper.toCell<Vector> newSpreadAdjustedRate "newSpreadAdjustedRate" true
                let builder () = withMnemonic mnemonic ((_TsiveriotisFernandesLattice.cell :?> TsiveriotisFernandesLatticeModel).Stepback
                                                            _i.cell 
                                                            _values.cell 
                                                            _conversionProbability.cell 
                                                            _spreadAdjustedRate.cell 
                                                            _newValues.cell 
                                                            _newConversionProbability.cell 
                                                            _newSpreadAdjustedRate.cell 
                                                       ) :> ICell
                let format (o : TsiveriotisFernandesLattice) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TsiveriotisFernandesLattice.source + ".Stepback") 
                                               [| _TsiveriotisFernandesLattice.source
                                               ;  _i.source
                                               ;  _values.source
                                               ;  _conversionProbability.source
                                               ;  _spreadAdjustedRate.source
                                               ;  _newValues.source
                                               ;  _newConversionProbability.source
                                               ;  _newSpreadAdjustedRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TsiveriotisFernandesLattice.cell
                                ;  _i.cell
                                ;  _values.cell
                                ;  _conversionProbability.cell
                                ;  _spreadAdjustedRate.cell
                                ;  _newValues.cell
                                ;  _newConversionProbability.cell
                                ;  _newSpreadAdjustedRate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TsiveriotisFernandesLattice", Description="Create a TsiveriotisFernandesLattice",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TsiveriotisFernandesLattice_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tree",Description = "Reference to tree")>] 
         tree : obj)
        ([<ExcelArgument(Name="riskFreeRate",Description = "Reference to riskFreeRate")>] 
         riskFreeRate : obj)
        ([<ExcelArgument(Name="End",Description = "Reference to End")>] 
         End : obj)
        ([<ExcelArgument(Name="steps",Description = "Reference to steps")>] 
         steps : obj)
        ([<ExcelArgument(Name="creditSpread",Description = "Reference to creditSpread")>] 
         creditSpread : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        ([<ExcelArgument(Name="divYield",Description = "Reference to divYield")>] 
         divYield : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tree = Helper.toCell<'T> tree "tree" true
                let _riskFreeRate = Helper.toCell<double> riskFreeRate "riskFreeRate" true
                let _End = Helper.toCell<double> End "End" true
                let _steps = Helper.toCell<int> steps "steps" true
                let _creditSpread = Helper.toCell<double> creditSpread "creditSpread" true
                let _sigma = Helper.toCell<double> sigma "sigma" true
                let _divYield = Helper.toCell<double> divYield "divYield" true
                let builder () = withMnemonic mnemonic (Fun.TsiveriotisFernandesLattice 
                                                            _tree.cell 
                                                            _riskFreeRate.cell 
                                                            _End.cell 
                                                            _steps.cell 
                                                            _creditSpread.cell 
                                                            _sigma.cell 
                                                            _divYield.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TsiveriotisFernandesLattice>) l

                let source = Helper.sourceFold "Fun.TsiveriotisFernandesLattice" 
                                               [| _tree.source
                                               ;  _riskFreeRate.source
                                               ;  _End.source
                                               ;  _steps.source
                                               ;  _creditSpread.source
                                               ;  _sigma.source
                                               ;  _divYield.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tree.cell
                                ;  _riskFreeRate.cell
                                ;  _End.cell
                                ;  _steps.cell
                                ;  _creditSpread.cell
                                ;  _sigma.cell
                                ;  _divYield.cell
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
    [<ExcelFunction(Name="_TsiveriotisFernandesLattice_Range", Description="Create a range of TsiveriotisFernandesLattice",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TsiveriotisFernandesLattice_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the TsiveriotisFernandesLattice")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TsiveriotisFernandesLattice> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TsiveriotisFernandesLattice>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<TsiveriotisFernandesLattice>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<TsiveriotisFernandesLattice>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
