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
  Convex-monotone interpolation factory and traits
  </summary> *)
[<AutoSerializable(true)>]
module ConvexMonotoneFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ConvexMonotone", Description="Create a ConvexMonotone",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvexMonotone_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="quadraticity",Description = "Reference to quadraticity")>] 
         quadraticity : obj)
        ([<ExcelArgument(Name="monotonicity",Description = "Reference to monotonicity")>] 
         monotonicity : obj)
        ([<ExcelArgument(Name="forcePositive",Description = "Reference to forcePositive")>] 
         forcePositive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _quadraticity = Helper.toCell<double> quadraticity "quadraticity" 
                let _monotonicity = Helper.toCell<double> monotonicity "monotonicity" 
                let _forcePositive = Helper.toCell<bool> forcePositive "forcePositive" 
                let builder () = withMnemonic mnemonic (Fun.ConvexMonotone 
                                                            _quadraticity.cell 
                                                            _monotonicity.cell 
                                                            _forcePositive.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConvexMonotone>) l

                let source = Helper.sourceFold "Fun.ConvexMonotone" 
                                               [| _quadraticity.source
                                               ;  _monotonicity.source
                                               ;  _forcePositive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _quadraticity.cell
                                ;  _monotonicity.cell
                                ;  _forcePositive.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvexMonotone> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvexMonotone1", Description="Create a ConvexMonotone",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvexMonotone_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.ConvexMonotone1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ConvexMonotone>) l

                let source = Helper.sourceFold "Fun.ConvexMonotone1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvexMonotone> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvexMonotone_dataSizeAdjustment", Description="Create a ConvexMonotone",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvexMonotone_dataSizeAdjustment
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotone",Description = "Reference to ConvexMonotone")>] 
         convexmonotone : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotone = Helper.toCell<ConvexMonotone> convexmonotone "ConvexMonotone"  
                let builder () = withMnemonic mnemonic ((ConvexMonotoneModel.Cast _ConvexMonotone.cell).DataSizeAdjustment
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvexMonotone.source + ".DataSizeAdjustment") 
                                               [| _ConvexMonotone.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotone.cell
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
    [<ExcelFunction(Name="_ConvexMonotone_global", Description="Create a ConvexMonotone",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvexMonotone_global
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotone",Description = "Reference to ConvexMonotone")>] 
         convexmonotone : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotone = Helper.toCell<ConvexMonotone> convexmonotone "ConvexMonotone"  
                let builder () = withMnemonic mnemonic ((ConvexMonotoneModel.Cast _ConvexMonotone.cell).Global
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ConvexMonotone.source + ".GLOBAL") 
                                               [| _ConvexMonotone.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotone.cell
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
    [<ExcelFunction(Name="_ConvexMonotone_interpolate", Description="Create a ConvexMonotone",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvexMonotone_interpolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotone",Description = "Reference to ConvexMonotone")>] 
         convexmonotone : obj)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotone = Helper.toCell<ConvexMonotone> convexmonotone "ConvexMonotone"  
                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let builder () = withMnemonic mnemonic ((ConvexMonotoneModel.Cast _ConvexMonotone.cell).Interpolate
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source = Helper.sourceFold (_ConvexMonotone.source + ".Interpolate") 
                                               [| _ConvexMonotone.source
                                               ;  _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotone.cell
                                ;  _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvexMonotone> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvexMonotone_localInterpolate", Description="Create a ConvexMonotone",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvexMonotone_localInterpolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotone",Description = "Reference to ConvexMonotone")>] 
         convexmonotone : obj)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="localisation",Description = "Reference to localisation")>] 
         localisation : obj)
        ([<ExcelArgument(Name="prevInterpolation",Description = "Reference to prevInterpolation")>] 
         prevInterpolation : obj)
        ([<ExcelArgument(Name="finalSize",Description = "Reference to finalSize")>] 
         finalSize : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotone = Helper.toCell<ConvexMonotone> convexmonotone "ConvexMonotone"  
                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _localisation = Helper.toCell<int> localisation "localisation" 
                let _prevInterpolation = Helper.toCell<ConvexMonotoneInterpolation> prevInterpolation "prevInterpolation" 
                let _finalSize = Helper.toCell<int> finalSize "finalSize" 
                let builder () = withMnemonic mnemonic ((ConvexMonotoneModel.Cast _ConvexMonotone.cell).LocalInterpolate
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                            _localisation.cell 
                                                            _prevInterpolation.cell 
                                                            _finalSize.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source = Helper.sourceFold (_ConvexMonotone.source + ".LocalInterpolate") 
                                               [| _ConvexMonotone.source
                                               ;  _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               ;  _localisation.source
                                               ;  _prevInterpolation.source
                                               ;  _finalSize.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotone.cell
                                ;  _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                ;  _localisation.cell
                                ;  _prevInterpolation.cell
                                ;  _finalSize.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ConvexMonotone> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_ConvexMonotone_requiredPoints", Description="Create a ConvexMonotone",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvexMonotone_requiredPoints
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ConvexMonotone",Description = "Reference to ConvexMonotone")>] 
         convexmonotone : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ConvexMonotone = Helper.toCell<ConvexMonotone> convexmonotone "ConvexMonotone"  
                let builder () = withMnemonic mnemonic ((ConvexMonotoneModel.Cast _ConvexMonotone.cell).RequiredPoints
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ConvexMonotone.source + ".RequiredPoints") 
                                               [| _ConvexMonotone.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ConvexMonotone.cell
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
    [<ExcelFunction(Name="_ConvexMonotone_Range", Description="Create a range of ConvexMonotone",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ConvexMonotone_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ConvexMonotone")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ConvexMonotone> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ConvexMonotone>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ConvexMonotone>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ConvexMonotone>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
