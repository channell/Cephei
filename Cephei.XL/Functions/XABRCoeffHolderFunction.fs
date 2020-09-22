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
module XABRCoeffHolderFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_XABRCoeffHolder_addParams_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let XABRCoeffHolder_addParams_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "Reference to XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder" true 
                let builder () = withMnemonic mnemonic ((_XABRCoeffHolder.cell :?> XABRCoeffHolderModel).AddParams_
                                                       ) :> ICell
                let format (i : Generic.List<Nullable<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_XABRCoeffHolder.source + ".AddParams_") 
                                               [| _XABRCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_XABRCoeffHolder_error_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let XABRCoeffHolder_error_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "Reference to XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder" true 
                let builder () = withMnemonic mnemonic ((_XABRCoeffHolder.cell :?> XABRCoeffHolderModel).Error_
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_XABRCoeffHolder.source + ".Error_") 
                                               [| _XABRCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
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
    [<ExcelFunction(Name="_XABRCoeffHolder_forward_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let XABRCoeffHolder_forward_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "Reference to XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder" true 
                let builder () = withMnemonic mnemonic ((_XABRCoeffHolder.cell :?> XABRCoeffHolderModel).Forward_
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_XABRCoeffHolder.source + ".Forward_") 
                                               [| _XABRCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
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
    [<ExcelFunction(Name="_XABRCoeffHolder_maxError_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let XABRCoeffHolder_maxError_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "Reference to XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder" true 
                let builder () = withMnemonic mnemonic ((_XABRCoeffHolder.cell :?> XABRCoeffHolderModel).MaxError_
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_XABRCoeffHolder.source + ".MaxError_") 
                                               [| _XABRCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
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
    [<ExcelFunction(Name="_XABRCoeffHolder_model_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let XABRCoeffHolder_model_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "Reference to XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder" true 
                let builder () = withMnemonic mnemonic ((_XABRCoeffHolder.cell :?> XABRCoeffHolderModel).Model_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IModel>) l

                let source = Helper.sourceFold (_XABRCoeffHolder.source + ".Model_") 
                                               [| _XABRCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
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
        ! Model instance (if required)
    *)
    [<ExcelFunction(Name="_XABRCoeffHolder_modelInstance_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let XABRCoeffHolder_modelInstance_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "Reference to XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder" true 
                let builder () = withMnemonic mnemonic ((_XABRCoeffHolder.cell :?> XABRCoeffHolderModel).ModelInstance_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IWrapper>) l

                let source = Helper.sourceFold (_XABRCoeffHolder.source + ".ModelInstance_") 
                                               [| _XABRCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
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
        
    *)
    [<ExcelFunction(Name="_XABRCoeffHolder_paramIsFixed_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let XABRCoeffHolder_paramIsFixed_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "Reference to XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder" true 
                let builder () = withMnemonic mnemonic ((_XABRCoeffHolder.cell :?> XABRCoeffHolderModel).ParamIsFixed_
                                                       ) :> ICell
                let format (i : Generic.List<bool>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_XABRCoeffHolder.source + ".ParamIsFixed_") 
                                               [| _XABRCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_XABRCoeffHolder_params_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let XABRCoeffHolder_params_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "Reference to XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder" true 
                let builder () = withMnemonic mnemonic ((_XABRCoeffHolder.cell :?> XABRCoeffHolderModel).Params_
                                                       ) :> ICell
                let format (i : Generic.List<Nullable<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_XABRCoeffHolder.source + ".Params_") 
                                               [| _XABRCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_XABRCoeffHolder_t_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let XABRCoeffHolder_t_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "Reference to XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder" true 
                let builder () = withMnemonic mnemonic ((_XABRCoeffHolder.cell :?> XABRCoeffHolderModel).T_
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_XABRCoeffHolder.source + ".T_") 
                                               [| _XABRCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
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
    [<ExcelFunction(Name="_XABRCoeffHolder_updateModelInstance", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let XABRCoeffHolder_updateModelInstance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "Reference to XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder" true 
                let builder () = withMnemonic mnemonic ((_XABRCoeffHolder.cell :?> XABRCoeffHolderModel).UpdateModelInstance
                                                       ) :> ICell
                let format (o : XABRCoeffHolder) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_XABRCoeffHolder.source + ".UpdateModelInstance") 
                                               [| _XABRCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
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
    [<ExcelFunction(Name="_XABRCoeffHolder_weights_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let XABRCoeffHolder_weights_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "Reference to XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder" true 
                let builder () = withMnemonic mnemonic ((_XABRCoeffHolder.cell :?> XABRCoeffHolderModel).Weights_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_XABRCoeffHolder.source + ".Weights_") 
                                               [| _XABRCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
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
    [<ExcelFunction(Name="_XABRCoeffHolder", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let XABRCoeffHolder_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="_params",Description = "Reference to _params")>] 
         _params : obj)
        ([<ExcelArgument(Name="paramIsFixed",Description = "Reference to paramIsFixed")>] 
         paramIsFixed : obj)
        ([<ExcelArgument(Name="addParams",Description = "Reference to addParams")>] 
         addParams : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _t = Helper.toCell<double> t "t" true
                let _forward = Helper.toCell<double> forward "forward" true
                let __params = Helper.toCell<Generic.List<Nullable<double>>> _params "_params" true
                let _paramIsFixed = Helper.toCell<Generic.List<bool>> paramIsFixed "paramIsFixed" true
                let _addParams = Helper.toCell<Generic.List<Nullable<double>>> addParams "addParams" true
                let builder () = withMnemonic mnemonic (Fun.XABRCoeffHolder 
                                                            _t.cell 
                                                            _forward.cell 
                                                            __params.cell 
                                                            _paramIsFixed.cell 
                                                            _addParams.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<XABRCoeffHolder>) l

                let source = Helper.sourceFold "Fun.XABRCoeffHolder" 
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
        
    *)
    [<ExcelFunction(Name="_XABRCoeffHolder_XABREndCriteria_", Description="Create a XABRCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let XABRCoeffHolder_XABREndCriteria_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="XABRCoeffHolder",Description = "Reference to XABRCoeffHolder")>] 
         xabrcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _XABRCoeffHolder = Helper.toCell<XABRCoeffHolder> xabrcoeffholder "XABRCoeffHolder" true 
                let builder () = withMnemonic mnemonic ((_XABRCoeffHolder.cell :?> XABRCoeffHolderModel).XABREndCriteria_
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_XABRCoeffHolder.source + ".XABREndCriteria_") 
                                               [| _XABRCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _XABRCoeffHolder.cell
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
    [<ExcelFunction(Name="_XABRCoeffHolder_Range", Description="Create a range of XABRCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let XABRCoeffHolder_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the XABRCoeffHolder")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<XABRCoeffHolder> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<XABRCoeffHolder>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<XABRCoeffHolder>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<XABRCoeffHolder>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
