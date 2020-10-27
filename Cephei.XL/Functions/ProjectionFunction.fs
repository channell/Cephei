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
module ProjectionFunction =

    (*
        ! returns whole set of parameters corresponding to the set of projected parameters
    *)
    [<ExcelFunction(Name="_Projection_include", Description="Create a Projection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Projection_include
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Projection",Description = "Projection")>] 
         projection : obj)
        ([<ExcelArgument(Name="projectedParameters",Description = "Vector")>] 
         projectedParameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Projection = Helper.toCell<Projection> projection "Projection"  
                let _projectedParameters = Helper.toCell<Vector> projectedParameters "projectedParameters" 
                let builder (current : ICell) = withMnemonic mnemonic ((ProjectionModel.Cast _Projection.cell).Include
                                                            _projectedParameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_Projection.source + ".INCLUDE") 

                                               [| _projectedParameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Projection.cell
                                ;  _projectedParameters.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Projection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns the subset of free parameters corresponding to set of parameters
    *)
    [<ExcelFunction(Name="_Projection_project", Description="Create a Projection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Projection_project
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Projection",Description = "Projection")>] 
         projection : obj)
        ([<ExcelArgument(Name="parameters",Description = "Vector")>] 
         parameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Projection = Helper.toCell<Projection> projection "Projection"  
                let _parameters = Helper.toCell<Vector> parameters "parameters" 
                let builder (current : ICell) = withMnemonic mnemonic ((ProjectionModel.Cast _Projection.cell).Project
                                                            _parameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_Projection.source + ".Project") 

                                               [| _parameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Projection.cell
                                ;  _parameters.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Projection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Projection", Description="Create a Projection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Projection_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Projection")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="parameterValues",Description = "Vector")>] 
         parameterValues : obj)
        ([<ExcelArgument(Name="fixParameters",Description = "Projection")>] 
         fixParameters : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _parameterValues = Helper.toCell<Vector> parameterValues "parameterValues" 
                let _fixParameters = Helper.toDefault<Generic.List<bool>> fixParameters "fixParameters" null
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Projection 
                                                            _parameterValues.cell 
                                                            _fixParameters.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Projection>) l

                let source () = Helper.sourceFold "Fun.Projection" 
                                               [| _parameterValues.source
                                               ;  _fixParameters.source
                                               |]
                let hash = Helper.hashFold 
                                [| _parameterValues.cell
                                ;  _fixParameters.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Projection> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_Projection_Range", Description="Create a range of Projection",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Projection_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Projection> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Projection>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<Projection>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Projection>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
