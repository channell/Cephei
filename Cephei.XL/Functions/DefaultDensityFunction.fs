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
module DefaultDensityFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DefaultDensity_discountImpl", Description="Create a DefaultDensity",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DefaultDensity_discountImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DefaultDensity",Description = "Reference to DefaultDensity")>] 
         defaultdensity : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DefaultDensity = Helper.toCell<DefaultDensity> defaultdensity "DefaultDensity"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_DefaultDensity.cell :?> DefaultDensityModel).DiscountImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DefaultDensity.source + ".DiscountImpl") 
                                               [| _DefaultDensity.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DefaultDensity.cell
                                ;  _i.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_DefaultDensity_forwardImpl", Description="Create a DefaultDensity",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DefaultDensity_forwardImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DefaultDensity",Description = "Reference to DefaultDensity")>] 
         defaultdensity : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DefaultDensity = Helper.toCell<DefaultDensity> defaultdensity "DefaultDensity"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_DefaultDensity.cell :?> DefaultDensityModel).ForwardImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DefaultDensity.source + ".ForwardImpl") 
                                               [| _DefaultDensity.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DefaultDensity.cell
                                ;  _i.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_DefaultDensity_guess", Description="Create a DefaultDensity",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DefaultDensity_guess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DefaultDensity",Description = "Reference to DefaultDensity")>] 
         defaultdensity : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "Reference to validData")>] 
         validData : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DefaultDensity = Helper.toCell<DefaultDensity> defaultdensity "DefaultDensity"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _f = Helper.toCell<int> f "f" 
                let builder () = withMnemonic mnemonic ((_DefaultDensity.cell :?> DefaultDensityModel).Guess
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DefaultDensity.source + ".Guess") 
                                               [| _DefaultDensity.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DefaultDensity.cell
                                ;  _i.cell
                                ;  _c.cell
                                ;  _validData.cell
                                ;  _f.cell
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
    [<ExcelFunction(Name="_DefaultDensity_initialDate", Description="Create a DefaultDensity",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DefaultDensity_initialDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DefaultDensity",Description = "Reference to DefaultDensity")>] 
         defaultdensity : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DefaultDensity = Helper.toCell<DefaultDensity> defaultdensity "DefaultDensity"  
                let _c = Helper.toCell<DefaultProbabilityTermStructure> c "c" 
                let builder () = withMnemonic mnemonic ((_DefaultDensity.cell :?> DefaultDensityModel).InitialDate
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_DefaultDensity.source + ".InitialDate") 
                                               [| _DefaultDensity.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DefaultDensity.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_DefaultDensity_initialValue", Description="Create a DefaultDensity",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DefaultDensity_initialValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DefaultDensity",Description = "Reference to DefaultDensity")>] 
         defaultdensity : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DefaultDensity = Helper.toCell<DefaultDensity> defaultdensity "DefaultDensity"  
                let _c = Helper.toCell<DefaultProbabilityTermStructure> c "c" 
                let builder () = withMnemonic mnemonic ((_DefaultDensity.cell :?> DefaultDensityModel).InitialValue
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DefaultDensity.source + ".InitialValue") 
                                               [| _DefaultDensity.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DefaultDensity.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_DefaultDensity_maxIterations", Description="Create a DefaultDensity",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DefaultDensity_maxIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DefaultDensity",Description = "Reference to DefaultDensity")>] 
         defaultdensity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DefaultDensity = Helper.toCell<DefaultDensity> defaultdensity "DefaultDensity"  
                let builder () = withMnemonic mnemonic ((_DefaultDensity.cell :?> DefaultDensityModel).MaxIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_DefaultDensity.source + ".MaxIterations") 
                                               [| _DefaultDensity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DefaultDensity.cell
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
    [<ExcelFunction(Name="_DefaultDensity_maxValueAfter", Description="Create a DefaultDensity",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DefaultDensity_maxValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DefaultDensity",Description = "Reference to DefaultDensity")>] 
         defaultdensity : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "Reference to validData")>] 
         validData : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DefaultDensity = Helper.toCell<DefaultDensity> defaultdensity "DefaultDensity"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _f = Helper.toCell<int> f "f" 
                let builder () = withMnemonic mnemonic ((_DefaultDensity.cell :?> DefaultDensityModel).MaxValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DefaultDensity.source + ".MaxValueAfter") 
                                               [| _DefaultDensity.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DefaultDensity.cell
                                ;  _i.cell
                                ;  _c.cell
                                ;  _validData.cell
                                ;  _f.cell
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
    [<ExcelFunction(Name="_DefaultDensity_minValueAfter", Description="Create a DefaultDensity",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DefaultDensity_minValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DefaultDensity",Description = "Reference to DefaultDensity")>] 
         defaultdensity : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="validData",Description = "Reference to validData")>] 
         validData : obj)
        ([<ExcelArgument(Name="f",Description = "Reference to f")>] 
         f : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DefaultDensity = Helper.toCell<DefaultDensity> defaultdensity "DefaultDensity"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _f = Helper.toCell<int> f "f" 
                let builder () = withMnemonic mnemonic ((_DefaultDensity.cell :?> DefaultDensityModel).MinValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DefaultDensity.source + ".MinValueAfter") 
                                               [| _DefaultDensity.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DefaultDensity.cell
                                ;  _i.cell
                                ;  _c.cell
                                ;  _validData.cell
                                ;  _f.cell
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
    [<ExcelFunction(Name="_DefaultDensity_updateGuess", Description="Create a DefaultDensity",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DefaultDensity_updateGuess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DefaultDensity",Description = "Reference to DefaultDensity")>] 
         defaultdensity : obj)
        ([<ExcelArgument(Name="data",Description = "Reference to data")>] 
         data : obj)
        ([<ExcelArgument(Name="density",Description = "Reference to density")>] 
         density : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DefaultDensity = Helper.toCell<DefaultDensity> defaultdensity "DefaultDensity"  
                let _data = Helper.toCell<Generic.List<double>> data "data" 
                let _density = Helper.toCell<double> density "density" 
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((_DefaultDensity.cell :?> DefaultDensityModel).UpdateGuess
                                                            _data.cell 
                                                            _density.cell 
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : DefaultDensity) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_DefaultDensity.source + ".UpdateGuess") 
                                               [| _DefaultDensity.source
                                               ;  _data.source
                                               ;  _density.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DefaultDensity.cell
                                ;  _data.cell
                                ;  _density.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_DefaultDensity_zeroYieldImpl", Description="Create a DefaultDensity",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DefaultDensity_zeroYieldImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DefaultDensity",Description = "Reference to DefaultDensity")>] 
         defaultdensity : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DefaultDensity = Helper.toCell<DefaultDensity> defaultdensity "DefaultDensity"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_DefaultDensity.cell :?> DefaultDensityModel).ZeroYieldImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_DefaultDensity.source + ".ZeroYieldImpl") 
                                               [| _DefaultDensity.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DefaultDensity.cell
                                ;  _i.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_DefaultDensity_Range", Description="Create a range of DefaultDensity",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let DefaultDensity_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the DefaultDensity")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DefaultDensity> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DefaultDensity>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<DefaultDensity>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<DefaultDensity>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
