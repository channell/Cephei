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
module VectorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Vector_Clone", Description="Create a Vector",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vector_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vector",Description = "Reference to Vector")>] 
         vector : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vector = Helper.toCell<Vector> vector "Vector"  
                let builder (current : ICell) = withMnemonic mnemonic ((VectorModel.Cast _Vector.cell).Clone
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_Vector.source + ".Clone") 
                                               [| _Vector.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vector.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Vector> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Vector_empty", Description="Create a Vector",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vector_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vector",Description = "Reference to Vector")>] 
         vector : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vector = Helper.toCell<Vector> vector "Vector"  
                let builder (current : ICell) = withMnemonic mnemonic ((VectorModel.Cast _Vector.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Vector.source + ".Empty") 
                                               [| _Vector.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vector.cell
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
    [<ExcelFunction(Name="_Vector_Equals", Description="Create a Vector",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vector_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vector",Description = "Reference to Vector")>] 
         vector : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vector = Helper.toCell<Vector> vector "Vector"  
                let _o = Helper.toCell<Object> o "o" 
                let builder (current : ICell) = withMnemonic mnemonic ((VectorModel.Cast _Vector.cell).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Vector.source + ".Equals") 
                                               [| _Vector.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vector.cell
                                ;  _o.cell
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
    [<ExcelFunction(Name="_Vector_Equals1", Description="Create a Vector",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vector_Equals1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vector",Description = "Reference to Vector")>] 
         vector : obj)
        ([<ExcelArgument(Name="other",Description = "Reference to other")>] 
         other : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vector = Helper.toCell<Vector> vector "Vector"  
                let _other = Helper.toCell<Vector> other "other" 
                let builder (current : ICell) = withMnemonic mnemonic ((VectorModel.Cast _Vector.cell).Equals1
                                                            _other.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Vector.source + ".Equals1") 
                                               [| _Vector.source
                                               ;  _other.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vector.cell
                                ;  _other.cell
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
    [<ExcelFunction(Name="_Vector_size", Description="Create a Vector",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vector_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vector",Description = "Reference to Vector")>] 
         vector : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vector = Helper.toCell<Vector> vector "Vector"  
                let builder (current : ICell) = withMnemonic mnemonic ((VectorModel.Cast _Vector.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Vector.source + ".Size") 
                                               [| _Vector.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vector.cell
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
    [<ExcelFunction(Name="_Vector_swap", Description="Create a Vector",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vector_swap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Vector",Description = "Reference to Vector")>] 
         vector : obj)
        ([<ExcelArgument(Name="i1",Description = "Reference to i1")>] 
         i1 : obj)
        ([<ExcelArgument(Name="i2",Description = "Reference to i2")>] 
         i2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Vector = Helper.toCell<Vector> vector "Vector"  
                let _i1 = Helper.toCell<int> i1 "i1" 
                let _i2 = Helper.toCell<int> i2 "i2" 
                let builder (current : ICell) = withMnemonic mnemonic ((VectorModel.Cast _Vector.cell).Swap
                                                            _i1.cell 
                                                            _i2.cell 
                                                       ) :> ICell
                let format (o : Vector) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Vector.source + ".Swap") 
                                               [| _Vector.source
                                               ;  _i1.source
                                               ;  _i2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Vector.cell
                                ;  _i1.cell
                                ;  _i2.cell
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
    [<ExcelFunction(Name="_Vector1", Description="Create a Vector",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vector_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="from",Description = "Reference to from")>] 
         from : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _from = Helper.toCell<Generic.List<double>> from "from" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Vector1 
                                                            _from.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold "Fun.Vector1" 
                                               [| _from.source
                                               |]
                let hash = Helper.hashFold 
                                [| _from.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Vector> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Vector", Description="Create a Vector",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vector_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.Vector ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold "Fun.Vector" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Vector> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Vector4", Description="Create a Vector",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vector_create4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Vector4
                                                            _size.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold "Fun.Vector4" 
                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _size.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Vector> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Vector5", Description="Create a Vector",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vector_create5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _size = Helper.toCell<int> size "size" 
                let _value = Helper.toCell<double> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Vector5 
                                                            _size.cell 
                                                            _value.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold "Fun.Vector5" 
                                               [| _size.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _size.cell
                                ;  _value.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Vector> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Vector2", Description="Create a Vector",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vector_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="from",Description = "Reference to from")>] 
         from : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _from = Helper.toCell<Vector> from "from" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Vector2
                                                            _from.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold "Fun.Vector2" 
                                               [| _from.source
                                               |]
                let hash = Helper.hashFold 
                                [| _from.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Vector> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Vector3", Description="Create a Vector",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vector_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        ([<ExcelArgument(Name="increment",Description = "Reference to increment")>] 
         increment : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _size = Helper.toCell<int> size "size" 
                let _value = Helper.toCell<double> value "value" 
                let _increment = Helper.toCell<double> increment "increment" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Vector3
                                                            _size.cell 
                                                            _value.cell 
                                                            _increment.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold "Fun.Vector3" 
                                               [| _size.source
                                               ;  _value.source
                                               ;  _increment.source
                                               |]
                let hash = Helper.hashFold 
                                [| _size.cell
                                ;  _value.cell
                                ;  _increment.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Vector> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_Vector_Range", Description="Create a range of Vector",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Vector_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Vector")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Vector> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Vector>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<Vector>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<Vector>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
