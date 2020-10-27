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
(*!! generic 
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module TsiveriotisFernandesLatticeFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TsiveriotisFernandesLattice_partialRollback", Description="Create a TsiveriotisFernandesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TsiveriotisFernandesLattice_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "TsiveriotisFernandesLattice")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TsiveriotisFernandesLattice",Description = "TsiveriotisFernandesLattice")>] 
         tsiveriotisfernandeslattice : obj)
        ([<ExcelArgument(Name="asset",Description = "DiscretizedAsset")>] 
         asset : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TsiveriotisFernandesLattice = Helper.toCell<TsiveriotisFernandesLattice> tsiveriotisfernandeslattice "TsiveriotisFernandesLattice"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((TsiveriotisFernandesLatticeModel.Cast _TsiveriotisFernandesLattice.cell).PartialRollback
                                                            _asset.cell 
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : TsiveriotisFernandesLattice) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TsiveriotisFernandesLattice.source + ".PartialRollback") 

                                               [| _asset.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TsiveriotisFernandesLattice.cell
                                ;  _asset.cell
                                ;  _To.cell
                                |]
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
    (*
        
    *)
    [<ExcelFunction(Name="_TsiveriotisFernandesLattice_rollback", Description="Create a TsiveriotisFernandesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TsiveriotisFernandesLattice_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "TsiveriotisFernandesLattice")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TsiveriotisFernandesLattice",Description = "TsiveriotisFernandesLattice")>] 
         tsiveriotisfernandeslattice : obj)
        ([<ExcelArgument(Name="asset",Description = "DiscretizedAsset")>] 
         asset : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TsiveriotisFernandesLattice = Helper.toCell<TsiveriotisFernandesLattice> tsiveriotisfernandeslattice "TsiveriotisFernandesLattice"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((TsiveriotisFernandesLatticeModel.Cast _TsiveriotisFernandesLattice.cell).Rollback
                                                            _asset.cell 
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : TsiveriotisFernandesLattice) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TsiveriotisFernandesLattice.source + ".Rollback") 

                                               [| _asset.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TsiveriotisFernandesLattice.cell
                                ;  _asset.cell
                                ;  _To.cell
                                |]
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
    (*
        
    *)
    [<ExcelFunction(Name="_TsiveriotisFernandesLattice_stepback", Description="Create a TsiveriotisFernandesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TsiveriotisFernandesLattice_stepback
        ([<ExcelArgument(Name="Mnemonic",Description = "TsiveriotisFernandesLattice")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TsiveriotisFernandesLattice",Description = "TsiveriotisFernandesLattice")>] 
         tsiveriotisfernandeslattice : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="values",Description = "Vector")>] 
         values : obj)
        ([<ExcelArgument(Name="conversionProbability",Description = "Vector")>] 
         conversionProbability : obj)
        ([<ExcelArgument(Name="spreadAdjustedRate",Description = "Vector")>] 
         spreadAdjustedRate : obj)
        ([<ExcelArgument(Name="newValues",Description = "Vector")>] 
         newValues : obj)
        ([<ExcelArgument(Name="newConversionProbability",Description = "Vector")>] 
         newConversionProbability : obj)
        ([<ExcelArgument(Name="newSpreadAdjustedRate",Description = "Vector")>] 
         newSpreadAdjustedRate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TsiveriotisFernandesLattice = Helper.toCell<TsiveriotisFernandesLattice> tsiveriotisfernandeslattice "TsiveriotisFernandesLattice"  
                let _i = Helper.toCell<int> i "i" 
                let _values = Helper.toCell<Vector> values "values" 
                let _conversionProbability = Helper.toCell<Vector> conversionProbability "conversionProbability" 
                let _spreadAdjustedRate = Helper.toCell<Vector> spreadAdjustedRate "spreadAdjustedRate" 
                let _newValues = Helper.toCell<Vector> newValues "newValues" 
                let _newConversionProbability = Helper.toCell<Vector> newConversionProbability "newConversionProbability" 
                let _newSpreadAdjustedRate = Helper.toCell<Vector> newSpreadAdjustedRate "newSpreadAdjustedRate" 
                let builder (current : ICell) = withMnemonic mnemonic ((TsiveriotisFernandesLatticeModel.Cast _TsiveriotisFernandesLattice.cell).Stepback
                                                            _i.cell 
                                                            _values.cell 
                                                            _conversionProbability.cell 
                                                            _spreadAdjustedRate.cell 
                                                            _newValues.cell 
                                                            _newConversionProbability.cell 
                                                            _newSpreadAdjustedRate.cell 
                                                       ) :> ICell
                let format (o : TsiveriotisFernandesLattice) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TsiveriotisFernandesLattice.source + ".Stepback") 

                                               [| _i.source
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
    (*
        
    *)
    [<ExcelFunction(Name="_TsiveriotisFernandesLattice", Description="Create a TsiveriotisFernandesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TsiveriotisFernandesLattice_create
        ([<ExcelArgument(Name="Mnemonic",Description = "TsiveriotisFernandesLattice")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tree",Description = "'T")>] 
         tree : obj)
        ([<ExcelArgument(Name="riskFreeRate",Description = "double")>] 
         riskFreeRate : obj)
        ([<ExcelArgument(Name="End",Description = "double")>] 
         End : obj)
        ([<ExcelArgument(Name="steps",Description = "int")>] 
         steps : obj)
        ([<ExcelArgument(Name="creditSpread",Description = "double")>] 
         creditSpread : obj)
        ([<ExcelArgument(Name="sigma",Description = "double")>] 
         sigma : obj)
        ([<ExcelArgument(Name="divYield",Description = "double")>] 
         divYield : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tree = Helper.toCell<'T> tree "tree" 
                let _riskFreeRate = Helper.toCell<double> riskFreeRate "riskFreeRate" 
                let _End = Helper.toCell<double> End "End" 
                let _steps = Helper.toCell<int> steps "steps" 
                let _creditSpread = Helper.toCell<double> creditSpread "creditSpread" 
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let _divYield = Helper.toCell<double> divYield "divYield" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TsiveriotisFernandesLattice 
                                                            _tree.cell 
                                                            _riskFreeRate.cell 
                                                            _End.cell 
                                                            _steps.cell 
                                                            _creditSpread.cell 
                                                            _sigma.cell 
                                                            _divYield.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TsiveriotisFernandesLattice>) l

                let source () = Helper.sourceFold "Fun.TsiveriotisFernandesLattice" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TsiveriotisFernandesLattice> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_TsiveriotisFernandesLattice_Range", Description="Create a range of TsiveriotisFernandesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TsiveriotisFernandesLattice_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TsiveriotisFernandesLattice> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TsiveriotisFernandesLattice>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<TsiveriotisFernandesLattice>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<TsiveriotisFernandesLattice>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
