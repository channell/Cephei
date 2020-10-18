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
module FdmMesherIntegralFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmMesherIntegral", Description="Create a FdmMesherIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmMesherIntegral_create
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmMesherIntegral")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="mesher",Description = "FdmMesherComposite")>] 
         mesher : obj)
        ([<ExcelArgument(Name="integrator1d",Description = "Vector,Vector,double")>] 
         integrator1d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _mesher = Helper.toCell<FdmMesherComposite> mesher "mesher" 
                let _integrator1d = Helper.toCell<Func<Vector,Vector,double>> integrator1d "integrator1d" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdmMesherIntegral 
                                                            _mesher.cell 
                                                            _integrator1d.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmMesherIntegral>) l

                let source () = Helper.sourceFold "Fun.FdmMesherIntegral" 
                                               [| _mesher.source
                                               ;  _integrator1d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _mesher.cell
                                ;  _integrator1d.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmMesherIntegral> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmMesherIntegral_integrate", Description="Create a FdmMesherIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmMesherIntegral_integrate
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmMesherIntegral",Description = "FdmMesherIntegral")>] 
         fdmmesherintegral : obj)
        ([<ExcelArgument(Name="f",Description = "Vector")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmMesherIntegral = Helper.toCell<FdmMesherIntegral> fdmmesherintegral "FdmMesherIntegral"  
                let _f = Helper.toCell<Vector> f "f" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmMesherIntegralModel.Cast _FdmMesherIntegral.cell).Integrate
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmMesherIntegral.source + ".Integrate") 
                                               [| _FdmMesherIntegral.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmMesherIntegral.cell
                                ;  _f.cell
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
    [<ExcelFunction(Name="_FdmMesherIntegral_Range", Description="Create a range of FdmMesherIntegral",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmMesherIntegral_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmMesherIntegral> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdmMesherIntegral>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdmMesherIntegral>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FdmMesherIntegral>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
