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
module AbcdCoeffHolderFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AbcdCoeffHolder_a_", Description="Create a AbcdCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCoeffHolder_a_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCoeffHolder",Description = "Reference to AbcdCoeffHolder")>] 
         abcdcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCoeffHolder = Helper.toCell<AbcdCoeffHolder> abcdcoeffholder "AbcdCoeffHolder"  
                let builder () = withMnemonic mnemonic ((AbcdCoeffHolderModel.Cast _AbcdCoeffHolder.cell).A_
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdCoeffHolder.source + ".A_") 
                                               [| _AbcdCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCoeffHolder.cell
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
    [<ExcelFunction(Name="_AbcdCoeffHolder", Description="Create a AbcdCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCoeffHolder_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="aIsFixed",Description = "Reference to aIsFixed")>] 
         aIsFixed : obj)
        ([<ExcelArgument(Name="bIsFixed",Description = "Reference to bIsFixed")>] 
         bIsFixed : obj)
        ([<ExcelArgument(Name="cIsFixed",Description = "Reference to cIsFixed")>] 
         cIsFixed : obj)
        ([<ExcelArgument(Name="dIsFixed",Description = "Reference to dIsFixed")>] 
         dIsFixed : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _a = Helper.toNullable<double> a "a"
                let _b = Helper.toNullable<double> b "b"
                let _c = Helper.toNullable<double> c "c"
                let _d = Helper.toNullable<double> d "d"
                let _aIsFixed = Helper.toCell<bool> aIsFixed "aIsFixed" 
                let _bIsFixed = Helper.toCell<bool> bIsFixed "bIsFixed" 
                let _cIsFixed = Helper.toCell<bool> cIsFixed "cIsFixed" 
                let _dIsFixed = Helper.toCell<bool> dIsFixed "dIsFixed" 
                let builder () = withMnemonic mnemonic (Fun.AbcdCoeffHolder 
                                                            _a.cell 
                                                            _b.cell 
                                                            _c.cell 
                                                            _d.cell 
                                                            _aIsFixed.cell 
                                                            _bIsFixed.cell 
                                                            _cIsFixed.cell 
                                                            _dIsFixed.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AbcdCoeffHolder>) l

                let source = Helper.sourceFold "Fun.AbcdCoeffHolder" 
                                               [| _a.source
                                               ;  _b.source
                                               ;  _c.source
                                               ;  _d.source
                                               ;  _aIsFixed.source
                                               ;  _bIsFixed.source
                                               ;  _cIsFixed.source
                                               ;  _dIsFixed.source
                                               |]
                let hash = Helper.hashFold 
                                [| _a.cell
                                ;  _b.cell
                                ;  _c.cell
                                ;  _d.cell
                                ;  _aIsFixed.cell
                                ;  _bIsFixed.cell
                                ;  _cIsFixed.cell
                                ;  _dIsFixed.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AbcdCoeffHolder> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AbcdCoeffHolder_abcdEndCriteria_", Description="Create a AbcdCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCoeffHolder_abcdEndCriteria_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCoeffHolder",Description = "Reference to AbcdCoeffHolder")>] 
         abcdcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCoeffHolder = Helper.toCell<AbcdCoeffHolder> abcdcoeffholder "AbcdCoeffHolder"  
                let builder () = withMnemonic mnemonic ((AbcdCoeffHolderModel.Cast _AbcdCoeffHolder.cell).AbcdEndCriteria_
                                                       ) :> ICell
                let format (o : EndCriteria.Type) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdCoeffHolder.source + ".AbcdEndCriteria_") 
                                               [| _AbcdCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCoeffHolder.cell
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
    [<ExcelFunction(Name="_AbcdCoeffHolder_aIsFixed_", Description="Create a AbcdCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCoeffHolder_aIsFixed_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCoeffHolder",Description = "Reference to AbcdCoeffHolder")>] 
         abcdcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCoeffHolder = Helper.toCell<AbcdCoeffHolder> abcdcoeffholder "AbcdCoeffHolder"  
                let builder () = withMnemonic mnemonic ((AbcdCoeffHolderModel.Cast _AbcdCoeffHolder.cell).AIsFixed_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdCoeffHolder.source + ".AIsFixed_") 
                                               [| _AbcdCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCoeffHolder.cell
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
    [<ExcelFunction(Name="_AbcdCoeffHolder_b_", Description="Create a AbcdCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCoeffHolder_b_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCoeffHolder",Description = "Reference to AbcdCoeffHolder")>] 
         abcdcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCoeffHolder = Helper.toCell<AbcdCoeffHolder> abcdcoeffholder "AbcdCoeffHolder"  
                let builder () = withMnemonic mnemonic ((AbcdCoeffHolderModel.Cast _AbcdCoeffHolder.cell).B_
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdCoeffHolder.source + ".B_") 
                                               [| _AbcdCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCoeffHolder.cell
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
    [<ExcelFunction(Name="_AbcdCoeffHolder_bIsFixed_", Description="Create a AbcdCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCoeffHolder_bIsFixed_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCoeffHolder",Description = "Reference to AbcdCoeffHolder")>] 
         abcdcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCoeffHolder = Helper.toCell<AbcdCoeffHolder> abcdcoeffholder "AbcdCoeffHolder"  
                let builder () = withMnemonic mnemonic ((AbcdCoeffHolderModel.Cast _AbcdCoeffHolder.cell).BIsFixed_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdCoeffHolder.source + ".BIsFixed_") 
                                               [| _AbcdCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCoeffHolder.cell
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
    [<ExcelFunction(Name="_AbcdCoeffHolder_c_", Description="Create a AbcdCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCoeffHolder_c_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCoeffHolder",Description = "Reference to AbcdCoeffHolder")>] 
         abcdcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCoeffHolder = Helper.toCell<AbcdCoeffHolder> abcdcoeffholder "AbcdCoeffHolder"  
                let builder () = withMnemonic mnemonic ((AbcdCoeffHolderModel.Cast _AbcdCoeffHolder.cell).C_
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdCoeffHolder.source + ".C_") 
                                               [| _AbcdCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCoeffHolder.cell
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
    [<ExcelFunction(Name="_AbcdCoeffHolder_cIsFixed_", Description="Create a AbcdCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCoeffHolder_cIsFixed_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCoeffHolder",Description = "Reference to AbcdCoeffHolder")>] 
         abcdcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCoeffHolder = Helper.toCell<AbcdCoeffHolder> abcdcoeffholder "AbcdCoeffHolder"  
                let builder () = withMnemonic mnemonic ((AbcdCoeffHolderModel.Cast _AbcdCoeffHolder.cell).CIsFixed_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdCoeffHolder.source + ".CIsFixed_") 
                                               [| _AbcdCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCoeffHolder.cell
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
    [<ExcelFunction(Name="_AbcdCoeffHolder_d_", Description="Create a AbcdCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCoeffHolder_d_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCoeffHolder",Description = "Reference to AbcdCoeffHolder")>] 
         abcdcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCoeffHolder = Helper.toCell<AbcdCoeffHolder> abcdcoeffholder "AbcdCoeffHolder"  
                let builder () = withMnemonic mnemonic ((AbcdCoeffHolderModel.Cast _AbcdCoeffHolder.cell).D_
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdCoeffHolder.source + ".D_") 
                                               [| _AbcdCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCoeffHolder.cell
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
    [<ExcelFunction(Name="_AbcdCoeffHolder_dIsFixed_", Description="Create a AbcdCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCoeffHolder_dIsFixed_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCoeffHolder",Description = "Reference to AbcdCoeffHolder")>] 
         abcdcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCoeffHolder = Helper.toCell<AbcdCoeffHolder> abcdcoeffholder "AbcdCoeffHolder"  
                let builder () = withMnemonic mnemonic ((AbcdCoeffHolderModel.Cast _AbcdCoeffHolder.cell).DIsFixed_
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdCoeffHolder.source + ".DIsFixed_") 
                                               [| _AbcdCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCoeffHolder.cell
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
    [<ExcelFunction(Name="_AbcdCoeffHolder_error_", Description="Create a AbcdCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCoeffHolder_error_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCoeffHolder",Description = "Reference to AbcdCoeffHolder")>] 
         abcdcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCoeffHolder = Helper.toCell<AbcdCoeffHolder> abcdcoeffholder "AbcdCoeffHolder"  
                let builder () = withMnemonic mnemonic ((AbcdCoeffHolderModel.Cast _AbcdCoeffHolder.cell).Error_
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdCoeffHolder.source + ".Error_") 
                                               [| _AbcdCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCoeffHolder.cell
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
    [<ExcelFunction(Name="_AbcdCoeffHolder_k_", Description="Create a AbcdCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCoeffHolder_k_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCoeffHolder",Description = "Reference to AbcdCoeffHolder")>] 
         abcdcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCoeffHolder = Helper.toCell<AbcdCoeffHolder> abcdcoeffholder "AbcdCoeffHolder"  
                let builder () = withMnemonic mnemonic ((AbcdCoeffHolderModel.Cast _AbcdCoeffHolder.cell).K_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_AbcdCoeffHolder.source + ".K_") 
                                               [| _AbcdCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCoeffHolder.cell
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
    [<ExcelFunction(Name="_AbcdCoeffHolder_maxError_", Description="Create a AbcdCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCoeffHolder_maxError_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AbcdCoeffHolder",Description = "Reference to AbcdCoeffHolder")>] 
         abcdcoeffholder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AbcdCoeffHolder = Helper.toCell<AbcdCoeffHolder> abcdcoeffholder "AbcdCoeffHolder"  
                let builder () = withMnemonic mnemonic ((AbcdCoeffHolderModel.Cast _AbcdCoeffHolder.cell).MaxError_
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AbcdCoeffHolder.source + ".MaxError_") 
                                               [| _AbcdCoeffHolder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AbcdCoeffHolder.cell
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
    [<ExcelFunction(Name="_AbcdCoeffHolder_Range", Description="Create a range of AbcdCoeffHolder",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AbcdCoeffHolder_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AbcdCoeffHolder")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AbcdCoeffHolder> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AbcdCoeffHolder>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AbcdCoeffHolder>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AbcdCoeffHolder>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
