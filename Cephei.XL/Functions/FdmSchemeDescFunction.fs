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
module FdmSchemeDescFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmSchemeDesc_CraigSneyd", Description="Create a FdmSchemeDesc",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSchemeDesc_CraigSneyd
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmSchemeDesc")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSchemeDesc",Description = "FdmSchemeDesc")>] 
         fdmschemedesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSchemeDesc = Helper.toCell<FdmSchemeDesc> fdmschemedesc "FdmSchemeDesc"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmSchemeDescModel.Cast _FdmSchemeDesc.cell).CraigSneyd
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmSchemeDesc>) l

                let source () = Helper.sourceFold (_FdmSchemeDesc.source + ".CraigSneyd") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmSchemeDesc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSchemeDesc> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmSchemeDesc_CrankNicolson", Description="Create a FdmSchemeDesc",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSchemeDesc_CrankNicolson
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmSchemeDesc")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSchemeDesc",Description = "FdmSchemeDesc")>] 
         fdmschemedesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSchemeDesc = Helper.toCell<FdmSchemeDesc> fdmschemedesc "FdmSchemeDesc"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmSchemeDescModel.Cast _FdmSchemeDesc.cell).CrankNicolson
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmSchemeDesc>) l

                let source () = Helper.sourceFold (_FdmSchemeDesc.source + ".CrankNicolson") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmSchemeDesc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSchemeDesc> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        some default scheme descriptions
    *)
    [<ExcelFunction(Name="_FdmSchemeDesc_Douglas", Description="Create a FdmSchemeDesc",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSchemeDesc_Douglas
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmSchemeDesc")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSchemeDesc",Description = "FdmSchemeDesc")>] 
         fdmschemedesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSchemeDesc = Helper.toCell<FdmSchemeDesc> fdmschemedesc "FdmSchemeDesc"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmSchemeDescModel.Cast _FdmSchemeDesc.cell).Douglas
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmSchemeDesc>) l

                let source () = Helper.sourceFold (_FdmSchemeDesc.source + ".Douglas") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmSchemeDesc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSchemeDesc> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmSchemeDesc_ExplicitEuler", Description="Create a FdmSchemeDesc",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSchemeDesc_ExplicitEuler
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmSchemeDesc")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSchemeDesc",Description = "FdmSchemeDesc")>] 
         fdmschemedesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSchemeDesc = Helper.toCell<FdmSchemeDesc> fdmschemedesc "FdmSchemeDesc"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmSchemeDescModel.Cast _FdmSchemeDesc.cell).ExplicitEuler
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmSchemeDesc>) l

                let source () = Helper.sourceFold (_FdmSchemeDesc.source + ".ExplicitEuler") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmSchemeDesc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSchemeDesc> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmSchemeDesc", Description="Create a FdmSchemeDesc",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSchemeDesc_create
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmSchemeDesc")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Type",Description = "FdmSchemeDesc.FdmSchemeType: HundsdorferType, DouglasType, CraigSneydType, ModifiedCraigSneydType, ImplicitEulerType, ExplicitEulerType, MethodOfLinesType, TrBDF2Type, CrankNicolsonType")>] 
         Type : obj)
        ([<ExcelArgument(Name="theta",Description = "double")>] 
         theta : obj)
        ([<ExcelArgument(Name="mu",Description = "double")>] 
         mu : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Type = Helper.toCell<FdmSchemeDesc.FdmSchemeType> Type "Type" 
                let _theta = Helper.toCell<double> theta "theta" 
                let _mu = Helper.toCell<double> mu "mu" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdmSchemeDesc 
                                                            _Type.cell 
                                                            _theta.cell 
                                                            _mu.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmSchemeDesc>) l

                let source () = Helper.sourceFold "Fun.FdmSchemeDesc" 
                                               [| _Type.source
                                               ;  _theta.source
                                               ;  _mu.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Type.cell
                                ;  _theta.cell
                                ;  _mu.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSchemeDesc> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmSchemeDesc1", Description="Create a FdmSchemeDesc",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSchemeDesc_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmSchemeDesc")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.FdmSchemeDesc1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmSchemeDesc>) l

                let source () = Helper.sourceFold "Fun.FdmSchemeDesc1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSchemeDesc> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmSchemeDesc_Hundsdorfer", Description="Create a FdmSchemeDesc",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSchemeDesc_Hundsdorfer
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmSchemeDesc")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSchemeDesc",Description = "FdmSchemeDesc")>] 
         fdmschemedesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSchemeDesc = Helper.toCell<FdmSchemeDesc> fdmschemedesc "FdmSchemeDesc"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmSchemeDescModel.Cast _FdmSchemeDesc.cell).Hundsdorfer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmSchemeDesc>) l

                let source () = Helper.sourceFold (_FdmSchemeDesc.source + ".Hundsdorfer") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmSchemeDesc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSchemeDesc> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmSchemeDesc_ImplicitEuler", Description="Create a FdmSchemeDesc",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSchemeDesc_ImplicitEuler
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmSchemeDesc")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSchemeDesc",Description = "FdmSchemeDesc")>] 
         fdmschemedesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSchemeDesc = Helper.toCell<FdmSchemeDesc> fdmschemedesc "FdmSchemeDesc"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmSchemeDescModel.Cast _FdmSchemeDesc.cell).ImplicitEuler
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmSchemeDesc>) l

                let source () = Helper.sourceFold (_FdmSchemeDesc.source + ".ImplicitEuler") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmSchemeDesc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSchemeDesc> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmSchemeDesc_MethodOfLines", Description="Create a FdmSchemeDesc",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSchemeDesc_MethodOfLines
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmSchemeDesc")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSchemeDesc",Description = "FdmSchemeDesc")>] 
         fdmschemedesc : obj)
        ([<ExcelArgument(Name="eps",Description = "FdmSchemeDesc")>] 
         eps : obj)
        ([<ExcelArgument(Name="relInitStepSize",Description = "FdmSchemeDesc")>] 
         relInitStepSize : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSchemeDesc = Helper.toCell<FdmSchemeDesc> fdmschemedesc "FdmSchemeDesc"  
                let _eps = Helper.toDefault<double> eps "eps" 0.001
                let _relInitStepSize = Helper.toDefault<double> relInitStepSize "relInitStepSize" 0.01
                let builder (current : ICell) = withMnemonic mnemonic ((FdmSchemeDescModel.Cast _FdmSchemeDesc.cell).MethodOfLines
                                                            _eps.cell 
                                                            _relInitStepSize.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmSchemeDesc>) l

                let source () = Helper.sourceFold (_FdmSchemeDesc.source + ".MethodOfLines") 

                                               [| _eps.source
                                               ;  _relInitStepSize.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmSchemeDesc.cell
                                ;  _eps.cell
                                ;  _relInitStepSize.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSchemeDesc> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmSchemeDesc_ModifiedCraigSneyd", Description="Create a FdmSchemeDesc",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSchemeDesc_ModifiedCraigSneyd
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmSchemeDesc")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSchemeDesc",Description = "FdmSchemeDesc")>] 
         fdmschemedesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSchemeDesc = Helper.toCell<FdmSchemeDesc> fdmschemedesc "FdmSchemeDesc"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmSchemeDescModel.Cast _FdmSchemeDesc.cell).ModifiedCraigSneyd
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmSchemeDesc>) l

                let source () = Helper.sourceFold (_FdmSchemeDesc.source + ".ModifiedCraigSneyd") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmSchemeDesc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSchemeDesc> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmSchemeDesc_ModifiedHundsdorfer", Description="Create a FdmSchemeDesc",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSchemeDesc_ModifiedHundsdorfer
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmSchemeDesc")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSchemeDesc",Description = "FdmSchemeDesc")>] 
         fdmschemedesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSchemeDesc = Helper.toCell<FdmSchemeDesc> fdmschemedesc "FdmSchemeDesc"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmSchemeDescModel.Cast _FdmSchemeDesc.cell).ModifiedHundsdorfer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmSchemeDesc>) l

                let source () = Helper.sourceFold (_FdmSchemeDesc.source + ".ModifiedHundsdorfer") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmSchemeDesc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSchemeDesc> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmSchemeDesc_mu", Description="Create a FdmSchemeDesc",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSchemeDesc_mu
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmSchemeDesc")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSchemeDesc",Description = "FdmSchemeDesc")>] 
         fdmschemedesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSchemeDesc = Helper.toCell<FdmSchemeDesc> fdmschemedesc "FdmSchemeDesc"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmSchemeDescModel.Cast _FdmSchemeDesc.cell).Mu
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmSchemeDesc.source + ".Mu") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmSchemeDesc.cell
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
    [<ExcelFunction(Name="_FdmSchemeDesc_theta", Description="Create a FdmSchemeDesc",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSchemeDesc_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmSchemeDesc")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSchemeDesc",Description = "FdmSchemeDesc")>] 
         fdmschemedesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSchemeDesc = Helper.toCell<FdmSchemeDesc> fdmschemedesc "FdmSchemeDesc"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmSchemeDescModel.Cast _FdmSchemeDesc.cell).Theta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FdmSchemeDesc.source + ".Theta") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmSchemeDesc.cell
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
    [<ExcelFunction(Name="_FdmSchemeDesc_TrBDF2", Description="Create a FdmSchemeDesc",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSchemeDesc_TrBDF2
        ([<ExcelArgument(Name="Mnemonic",Description = "FdmSchemeDesc")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSchemeDesc",Description = "FdmSchemeDesc")>] 
         fdmschemedesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSchemeDesc = Helper.toCell<FdmSchemeDesc> fdmschemedesc "FdmSchemeDesc"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmSchemeDescModel.Cast _FdmSchemeDesc.cell).TrBDF2
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmSchemeDesc>) l

                let source () = Helper.sourceFold (_FdmSchemeDesc.source + ".TrBDF2") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmSchemeDesc.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FdmSchemeDesc> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmSchemeDesc_type", Description="Create a FdmSchemeDesc",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSchemeDesc_type
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmSchemeDesc",Description = "FdmSchemeDesc")>] 
         fdmschemedesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmSchemeDesc = Helper.toCell<FdmSchemeDesc> fdmschemedesc "FdmSchemeDesc"  
                let builder (current : ICell) = withMnemonic mnemonic ((FdmSchemeDescModel.Cast _FdmSchemeDesc.cell).Type
                                                       ) :> ICell
                let format (o : FdmSchemeDesc.FdmSchemeType) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FdmSchemeDesc.source + ".TYPE") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FdmSchemeDesc.cell
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
    [<ExcelFunction(Name="_FdmSchemeDesc_Range", Description="Create a range of FdmSchemeDesc",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FdmSchemeDesc_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmSchemeDesc> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdmSchemeDesc>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdmSchemeDesc>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FdmSchemeDesc>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
