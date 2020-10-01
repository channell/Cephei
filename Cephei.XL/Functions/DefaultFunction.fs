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
Integration policies
  </summary> *)
[<AutoSerializable(true)>]
module DefaultFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Default_integrate", Description="Create a Default",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Default_integrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Default",Description = "Reference to Default")>] 
         defaulT : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="I",Description = "Reference to I")>] 
         I : obj)
        ([<ExcelArgument(Name="N",Description = "Reference to N")>] 
         N : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Default = Helper.toCell<Default> defaulT "Default"  
                let _f = Helper.toCell<Func<double,double>> f "f" 
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let _I = Helper.toCell<double> I "I" 
                let _N = Helper.toCell<int> N "N" 
                let builder () = withMnemonic mnemonic ((_Default.cell :?> DefaultModel).Integrate
                                                            _f.cell 
                                                            _a.cell 
                                                            _b.cell 
                                                            _I.cell 
                                                            _N.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Default.source + ".Integrate") 
                                               [| _Default.source
                                               ;  _f.source
                                               ;  _a.source
                                               ;  _b.source
                                               ;  _I.source
                                               ;  _N.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Default.cell
                                ;  _f.cell
                                ;  _a.cell
                                ;  _b.cell
                                ;  _I.cell
                                ;  _N.cell
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
    [<ExcelFunction(Name="_Default_nbEvalutions", Description="Create a Default",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Default_nbEvalutions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Default",Description = "Reference to Default")>] 
         defaulT : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Default = Helper.toCell<Default> defaulT "Default"  
                let builder () = withMnemonic mnemonic ((_Default.cell :?> DefaultModel).NbEvalutions
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Default.source + ".NbEvalutions") 
                                               [| _Default.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Default.cell
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
    [<ExcelFunction(Name="_Default_Range", Description="Create a range of Default",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Default_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Default")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Default> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Default>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Default>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Default>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
