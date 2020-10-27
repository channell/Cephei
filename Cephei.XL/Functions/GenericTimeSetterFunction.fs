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
(*!!generic
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module GenericTimeSetterFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GenericTimeSetter", Description="Create a GenericTimeSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericTimeSetter_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="grid",Description = "Vector")>] 
         grid : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _grid = Helper.toCell<Vector> grid "grid" 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.GenericTimeSetter 
                                                            _grid.cell 
                                                            _Process.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GenericTimeSetter>) l

                let source () = Helper.sourceFold "Fun.GenericTimeSetter" 
                                               [| _grid.source
                                               ;  _Process.source
                                               |]
                let hash = Helper.hashFold 
                                [| _grid.cell
                                ;  _Process.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GenericTimeSetter> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_GenericTimeSetter_setTime", Description="Create a GenericTimeSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericTimeSetter_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericTimeSetter",Description = "GenericTimeSetter")>] 
         generictimesetter : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="L",Description = "IOperator")>] 
         L : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericTimeSetter = Helper.toCell<GenericTimeSetter> generictimesetter "GenericTimeSetter"  
                let _t = Helper.toCell<double> t "t" 
                let _L = Helper.toCell<IOperator> L "L" 
                let builder (current : ICell) = withMnemonic mnemonic ((GenericTimeSetterModel.Cast _GenericTimeSetter.cell).SetTime
                                                            _t.cell 
                                                            _L.cell 
                                                       ) :> ICell
                let format (o : GenericTimeSetter) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_GenericTimeSetter.source + ".SetTime") 

                                               [| _t.source
                                               ;  _L.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericTimeSetter.cell
                                ;  _t.cell
                                ;  _L.cell
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
    [<ExcelFunction(Name="_GenericTimeSetter_Range", Description="Create a range of GenericTimeSetter",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericTimeSetter_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GenericTimeSetter> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GenericTimeSetter>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<GenericTimeSetter>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<GenericTimeSetter>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
