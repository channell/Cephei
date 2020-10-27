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
module FdmMesherCompositeFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmMesherComposite_dminus", Description="Create a FdmMesherComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmMesherComposite_dminus
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmMesherComposite")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmMesherComposite",Description = "FdmMesherComposite")>] 
         fdmmeshercomposite : obj)
        ([<ExcelArgument(Name="iter",Description = "FdmLinearOpIterator")>] 
         iter : obj)
        ([<ExcelArgument(Name="direction",Description = "int")>] 
         direction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmMesherComposite = Helper.toCell<FdmMesherComposite> fdmmeshercomposite "FdmMesherComposite"  
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" 
                let _direction = Helper.toCell<int> direction "direction" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmMesherCompositeModel.Cast _FdmMesherComposite.cell).Dminus
                                                            _iter.cell 
                                                            _direction.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmMesherComposite.source + ".Dminus") 

                                               [| _iter.source
                                               ;  _direction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmMesherComposite.cell
                                ;  _iter.cell
                                ;  _direction.cell
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
    [<ExcelFunction(Name="_FdmMesherComposite_dplus", Description="Create a FdmMesherComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmMesherComposite_dplus
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmMesherComposite")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmMesherComposite",Description = "FdmMesherComposite")>] 
         fdmmeshercomposite : obj)
        ([<ExcelArgument(Name="iter",Description = "FdmLinearOpIterator")>] 
         iter : obj)
        ([<ExcelArgument(Name="direction",Description = "int")>] 
         direction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmMesherComposite = Helper.toCell<FdmMesherComposite> fdmmeshercomposite "FdmMesherComposite"  
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" 
                let _direction = Helper.toCell<int> direction "direction" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmMesherCompositeModel.Cast _FdmMesherComposite.cell).Dplus
                                                            _iter.cell 
                                                            _direction.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmMesherComposite.source + ".Dplus") 

                                               [| _iter.source
                                               ;  _direction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmMesherComposite.cell
                                ;  _iter.cell
                                ;  _direction.cell
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
    [<ExcelFunction(Name="_FdmMesherComposite", Description="Create a FdmMesherComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmMesherComposite_create
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmMesherComposite")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="layout",Description = "FdmLinearOpLayout")>] 
         layout : obj)
        ([<ExcelArgument(Name="mesher",Description = "Fdm1dMesher")>] 
         mesher : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _layout = Helper.toCell<FdmLinearOpLayout> layout "layout" 
                let _mesher = Helper.toCell<Generic.List<Fdm1dMesher>> mesher "mesher" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdmMesherComposite 
                                                            _layout.cell 
                                                            _mesher.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmMesherComposite>) l

                let source () = Helper.sourceFold "Fun.FdmMesherComposite" 
                                               [| _layout.source
                                               ;  _mesher.source
                                               |]
                let hash = Helper.hashFold 
                                [| _layout.cell
                                ;  _mesher.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmMesherComposite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmMesherComposite1", Description="Create a FdmMesherComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmMesherComposite_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmMesherComposite")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="mesher",Description = "Fdm1dMesher")>] 
         mesher : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _mesher = Helper.toCell<Generic.List<Fdm1dMesher>> mesher "mesher" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdmMesherComposite1 
                                                            _mesher.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmMesherComposite>) l

                let source () = Helper.sourceFold "Fun.FdmMesherComposite1" 
                                               [| _mesher.source
                                               |]
                let hash = Helper.hashFold 
                                [| _mesher.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmMesherComposite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmMesherComposite3", Description="Create a FdmMesherComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmMesherComposite_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmMesherComposite")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="mesher",Description = "Fdm1dMesher")>] 
         mesher : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _mesher = Helper.toCell<Fdm1dMesher> mesher "mesher" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdmMesherComposite3
                                                            _mesher.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmMesherComposite>) l

                let source () = Helper.sourceFold "Fun.FdmMesherComposite3" 
                                               [| _mesher.source
                                               |]
                let hash = Helper.hashFold 
                                [| _mesher.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmMesherComposite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmMesherComposite4", Description="Create a FdmMesherComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmMesherComposite_create4
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmMesherComposite")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="m1",Description = "Fdm1dMesher")>] 
         m1 : obj)
        ([<ExcelArgument(Name="m2",Description = "Fdm1dMesher")>] 
         m2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _m1 = Helper.toCell<Fdm1dMesher> m1 "m1" 
                let _m2 = Helper.toCell<Fdm1dMesher> m2 "m2" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdmMesherComposite4
                                                            _m1.cell 
                                                            _m2.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmMesherComposite>) l

                let source () = Helper.sourceFold "Fun.FdmMesherComposite4" 
                                               [| _m1.source
                                               ;  _m2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _m1.cell
                                ;  _m2.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmMesherComposite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmMesherComposite2", Description="Create a FdmMesherComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmMesherComposite_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmMesherComposite")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="m1",Description = "Fdm1dMesher")>] 
         m1 : obj)
        ([<ExcelArgument(Name="m2",Description = "Fdm1dMesher")>] 
         m2 : obj)
        ([<ExcelArgument(Name="m3",Description = "Fdm1dMesher")>] 
         m3 : obj)
        ([<ExcelArgument(Name="m4",Description = "Fdm1dMesher")>] 
         m4 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _m1 = Helper.toCell<Fdm1dMesher> m1 "m1" 
                let _m2 = Helper.toCell<Fdm1dMesher> m2 "m2" 
                let _m3 = Helper.toCell<Fdm1dMesher> m3 "m3" 
                let _m4 = Helper.toCell<Fdm1dMesher> m4 "m4" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdmMesherComposite2
                                                            _m1.cell 
                                                            _m2.cell 
                                                            _m3.cell 
                                                            _m4.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmMesherComposite>) l

                let source () = Helper.sourceFold "Fun.FdmMesherComposite2" 
                                               [| _m1.source
                                               ;  _m2.source
                                               ;  _m3.source
                                               ;  _m4.source
                                               |]
                let hash = Helper.hashFold 
                                [| _m1.cell
                                ;  _m2.cell
                                ;  _m3.cell
                                ;  _m4.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmMesherComposite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmMesherComposite5", Description="Create a FdmMesherComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmMesherComposite_create5
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmMesherComposite")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="m1",Description = "Fdm1dMesher")>] 
         m1 : obj)
        ([<ExcelArgument(Name="m2",Description = "Fdm1dMesher")>] 
         m2 : obj)
        ([<ExcelArgument(Name="m3",Description = "Fdm1dMesher")>] 
         m3 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _m1 = Helper.toCell<Fdm1dMesher> m1 "m1" 
                let _m2 = Helper.toCell<Fdm1dMesher> m2 "m2" 
                let _m3 = Helper.toCell<Fdm1dMesher> m3 "m3" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdmMesherComposite5 
                                                            _m1.cell 
                                                            _m2.cell 
                                                            _m3.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmMesherComposite>) l

                let source () = Helper.sourceFold "Fun.FdmMesherComposite5" 
                                               [| _m1.source
                                               ;  _m2.source
                                               ;  _m3.source
                                               |]
                let hash = Helper.hashFold 
                                [| _m1.cell
                                ;  _m2.cell
                                ;  _m3.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmMesherComposite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmMesherComposite_getFdm1dMeshers", Description="Create a FdmMesherComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmMesherComposite_getFdm1dMeshers
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmMesherComposite",Description = "FdmMesherComposite")>] 
         fdmmeshercomposite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmMesherComposite = Helper.toCell<FdmMesherComposite> fdmmeshercomposite "FdmMesherComposite"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmMesherCompositeModel.Cast _FdmMesherComposite.cell).GetFdm1dMeshers
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Fdm1dMesher>>) (l : string) = Helper.Range.fromModelList i l

                let source () = Helper.sourceFold (_FdmMesherComposite.source + ".GetFdm1dMeshers") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmMesherComposite.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmMesherComposite_location", Description="Create a FdmMesherComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmMesherComposite_location
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmMesherComposite",Description = "FdmMesherComposite")>] 
         fdmmeshercomposite : obj)
        ([<ExcelArgument(Name="iter",Description = "FdmLinearOpIterator")>] 
         iter : obj)
        ([<ExcelArgument(Name="direction",Description = "int")>] 
         direction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmMesherComposite = Helper.toCell<FdmMesherComposite> fdmmeshercomposite "FdmMesherComposite"  
                let _iter = Helper.toCell<FdmLinearOpIterator> iter "iter" 
                let _direction = Helper.toCell<int> direction "direction" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmMesherCompositeModel.Cast _FdmMesherComposite.cell).Location
                                                            _iter.cell 
                                                            _direction.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmMesherComposite.source + ".Location") 

                                               [| _iter.source
                                               ;  _direction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmMesherComposite.cell
                                ;  _iter.cell
                                ;  _direction.cell
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
    [<ExcelFunction(Name="_FdmMesherComposite_locations", Description="Create a FdmMesherComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmMesherComposite_locations
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmMesherComposite",Description = "FdmMesherComposite")>] 
         fdmmeshercomposite : obj)
        ([<ExcelArgument(Name="direction",Description = "int")>] 
         direction : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmMesherComposite = Helper.toCell<FdmMesherComposite> fdmmeshercomposite "FdmMesherComposite"  
                let _direction = Helper.toCell<int> direction "direction" 
                let builder (current : ICell) = withMnemonic mnemonic ((FdmMesherCompositeModel.Cast _FdmMesherComposite.cell).Locations
                                                            _direction.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FdmMesherComposite.source + ".Locations") 

                                               [| _direction.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmMesherComposite.cell
                                ;  _direction.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmMesherComposite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmMesherComposite_layout", Description="Create a FdmMesherComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmMesherComposite_layout
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmLinearOpLayout")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmMesherComposite",Description = "FdmMesherComposite")>] 
         fdmmeshercomposite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmMesherComposite = Helper.toCell<FdmMesherComposite> fdmmeshercomposite "FdmMesherComposite"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmMesherCompositeModel.Cast _FdmMesherComposite.cell).Layout
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmLinearOpLayout>) l

                let source () = Helper.sourceFold (_FdmMesherComposite.source + ".Layout") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmMesherComposite.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmMesherComposite> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FdmMesherComposite_Range", Description="Create a range of FdmMesherComposite",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmMesherComposite_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmMesherComposite> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdmMesherComposite>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdmMesherComposite>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FdmMesherComposite>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
