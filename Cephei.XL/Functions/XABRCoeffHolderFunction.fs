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
module XABRCoeffHolderFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_XABRCoeffHolder_addParams_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRCoeffHolder_addParams_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder"  
                let builder (current : ICell) = withMnemonic mnemonic ((XABRCoeffHolderModel.Cast _XABRCoeffHolder.cell).AddParams_
                                                       ) :> ICell
                let format (i : Generic.List<Nullable<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_XABRCoeffHolder.source + ".AddParams_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Interpolation results
    *)
    [<ExcelFunction(Name="_XABRCoeffHolder_error_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRCoeffHolder_error_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder"  
                let builder (current : ICell) = withMnemonic mnemonic ((XABRCoeffHolderModel.Cast _XABRCoeffHolder.cell).Error_
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_XABRCoeffHolder.source + ".Error_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
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
    [<ExcelFunction(Name="_XABRCoeffHolder_forward_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRCoeffHolder_forward_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder"  
                let builder (current : ICell) = withMnemonic mnemonic ((XABRCoeffHolderModel.Cast _XABRCoeffHolder.cell).Forward_
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_XABRCoeffHolder.source + ".Forward_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
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
    [<ExcelFunction(Name="_XABRCoeffHolder_maxError_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRCoeffHolder_maxError_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder"  
                let builder (current : ICell) = withMnemonic mnemonic ((XABRCoeffHolderModel.Cast _XABRCoeffHolder.cell).MaxError_
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_XABRCoeffHolder.source + ".MaxError_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
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
    [<ExcelFunction(Name="_XABRCoeffHolder_model_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRCoeffHolder_model_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder"  
                let builder (current : ICell) = withMnemonic mnemonic ((XABRCoeffHolderModel.Cast _XABRCoeffHolder.cell).Model_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IModel>) l

                let source () = Helper.sourceFold (_XABRCoeffHolder.source + ".Model_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<XABRCoeffHolder> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Model instance (if required)
    *)
    [<ExcelFunction(Name="_XABRCoeffHolder_modelInstance_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRCoeffHolder_modelInstance_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder"  
                let builder (current : ICell) = withMnemonic mnemonic ((XABRCoeffHolderModel.Cast _XABRCoeffHolder.cell).ModelInstance_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IWrapper>) l

                let source () = Helper.sourceFold (_XABRCoeffHolder.source + ".ModelInstance_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<XABRCoeffHolder> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_XABRCoeffHolder_paramIsFixed_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRCoeffHolder_paramIsFixed_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder"  
                let builder (current : ICell) = withMnemonic mnemonic ((XABRCoeffHolderModel.Cast _XABRCoeffHolder.cell).ParamIsFixed_
                                                       ) :> ICell
                let format (i : Generic.List<bool>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_XABRCoeffHolder.source + ".ParamIsFixed_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Parameters
    *)
    [<ExcelFunction(Name="_XABRCoeffHolder_params_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRCoeffHolder_params_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder"  
                let builder (current : ICell) = withMnemonic mnemonic ((XABRCoeffHolderModel.Cast _XABRCoeffHolder.cell).Params_
                                                       ) :> ICell
                let format (i : Generic.List<Nullable<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_XABRCoeffHolder.source + ".Params_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Expiry, Forward
    *)
    [<ExcelFunction(Name="_XABRCoeffHolder_t_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRCoeffHolder_t_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder"  
                let builder (current : ICell) = withMnemonic mnemonic ((XABRCoeffHolderModel.Cast _XABRCoeffHolder.cell).T_
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_XABRCoeffHolder.source + ".T_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
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
    [<ExcelFunction(Name="_XABRCoeffHolder_updateModelInstance", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRCoeffHolder_updateModelInstance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder"  
                let builder (current : ICell) = withMnemonic mnemonic ((XABRCoeffHolderModel.Cast _XABRCoeffHolder.cell).UpdateModelInstance
                                                       ) :> ICell
                let format (o : XABRCoeffHolder) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_XABRCoeffHolder.source + ".UpdateModelInstance") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
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
    [<ExcelFunction(Name="_XABRCoeffHolder_weights_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRCoeffHolder_weights_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder"  
                let builder (current : ICell) = withMnemonic mnemonic ((XABRCoeffHolderModel.Cast _XABRCoeffHolder.cell).Weights_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_XABRCoeffHolder.source + ".Weights_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_XABRCoeffHolder", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRCoeffHolder_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        ([<ExcelArgument(Name="forward",Description = "double")>] 
         forward : obj)
        ([<ExcelArgument(Name="_params",Description = "double range")>] 
         _params : obj)
        ([<ExcelArgument(Name="paramIsFixed",Description = "bool range")>] 
         paramIsFixed : obj)
        ([<ExcelArgument(Name="addParams",Description = "double range")>] 
         addParams : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _t = Helper.toCell<double> t "t" 
                let _forward = Helper.toCell<double> forward "forward" 
                let __params = Helper.toNullabletList<double> _params "_params" 
                let _paramIsFixed = Helper.toCell<Generic.List<bool>> paramIsFixed "paramIsFixed" 
                let _addParams = Helper.toNullabletList<double> addParams "addParams" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.XABRCoeffHolder 
                                                            _t.cell 
                                                            _forward.cell 
                                                            __params.cell 
                                                            _paramIsFixed.cell 
                                                            _addParams.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<XABRCoeffHolder>) l

                let source () = Helper.sourceFold "Fun.XABRCoeffHolder" 
                                               [| _t.source
                                               ;  _forward.source
                                               ;  __params.source
                                               ;  _paramIsFixed.source
                                               ;  _addParams.source
                                               |]
                let hash = Helper.hashFold 
                                [| _t.cell
                                ;  _forward.cell
                                ;  __params.cell
                                ;  _paramIsFixed.cell
                                ;  _addParams.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<XABRCoeffHolder> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_XABRCoeffHolder_XABREndCriteria_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRCoeffHolder_XABREndCriteria_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder"  
                let builder (current : ICell) = withMnemonic mnemonic ((XABRCoeffHolderModel.Cast _XABRCoeffHolder.cell).XABREndCriteria_
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_XABRCoeffHolder.source + ".XABREndCriteria_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
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
    [<ExcelFunction(Name="_XABRCoeffHolder_Range", Description="Create a range of XABRCoeffHolder",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let XABRCoeffHolder_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<XABRCoeffHolder> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<XABRCoeffHolder> (c)) :> ICell
                let format (i : Generic.List<ICell<XABRCoeffHolder>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<XABRCoeffHolder>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
