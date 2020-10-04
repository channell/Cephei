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
  Forward-curve traits
  </summary> *)
[<AutoSerializable(true)>]
module ForwardRateFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_ForwardRate_discountImpl", Description="Create a ForwardRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRate_discountImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRate",Description = "Reference to ForwardRate")>] 
         forwardrate : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRate = Helper.toCell<ForwardRate> forwardrate "ForwardRate"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((ForwardRateModel.Cast _ForwardRate.cell).DiscountImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardRate.source + ".DiscountImpl") 
                                               [| _ForwardRate.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardRate.cell
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
    [<ExcelFunction(Name="_ForwardRate_forwardImpl", Description="Create a ForwardRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRate_forwardImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRate",Description = "Reference to ForwardRate")>] 
         forwardrate : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRate = Helper.toCell<ForwardRate> forwardrate "ForwardRate"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((ForwardRateModel.Cast _ForwardRate.cell).ForwardImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardRate.source + ".ForwardImpl") 
                                               [| _ForwardRate.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardRate.cell
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
    [<ExcelFunction(Name="_ForwardRate_guess", Description="Create a ForwardRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRate_guess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRate",Description = "Reference to ForwardRate")>] 
         forwardrate : obj)
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

                let _ForwardRate = Helper.toCell<ForwardRate> forwardrate "ForwardRate"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _f = Helper.toCell<int> f "f" 
                let builder () = withMnemonic mnemonic ((ForwardRateModel.Cast _ForwardRate.cell).Guess
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardRate.source + ".Guess") 
                                               [| _ForwardRate.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardRate.cell
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
    [<ExcelFunction(Name="_ForwardRate_initialDate", Description="Create a ForwardRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRate_initialDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRate",Description = "Reference to ForwardRate")>] 
         forwardrate : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRate = Helper.toCell<ForwardRate> forwardrate "ForwardRate"  
                let _c = Helper.toCell<YieldTermStructure> c "c" 
                let builder () = withMnemonic mnemonic ((ForwardRateModel.Cast _ForwardRate.cell).InitialDate
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_ForwardRate.source + ".InitialDate") 
                                               [| _ForwardRate.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardRate.cell
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
        start of curve data
    *)
    [<ExcelFunction(Name="_ForwardRate_initialValue", Description="Create a ForwardRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRate_initialValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRate",Description = "Reference to ForwardRate")>] 
         forwardrate : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRate = Helper.toCell<ForwardRate> forwardrate "ForwardRate"  
                let _c = Helper.toCell<YieldTermStructure> c "c" 
                let builder () = withMnemonic mnemonic ((ForwardRateModel.Cast _ForwardRate.cell).InitialValue
                                                            _c.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardRate.source + ".InitialValue") 
                                               [| _ForwardRate.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardRate.cell
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
        upper bound for convergence loop
    *)
    [<ExcelFunction(Name="_ForwardRate_maxIterations", Description="Create a ForwardRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRate_maxIterations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRate",Description = "Reference to ForwardRate")>] 
         forwardrate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRate = Helper.toCell<ForwardRate> forwardrate "ForwardRate"  
                let builder () = withMnemonic mnemonic ((ForwardRateModel.Cast _ForwardRate.cell).MaxIterations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardRate.source + ".MaxIterations") 
                                               [| _ForwardRate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardRate.cell
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
    [<ExcelFunction(Name="_ForwardRate_maxValueAfter", Description="Create a ForwardRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRate_maxValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRate",Description = "Reference to ForwardRate")>] 
         forwardrate : obj)
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

                let _ForwardRate = Helper.toCell<ForwardRate> forwardrate "ForwardRate"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _f = Helper.toCell<int> f "f" 
                let builder () = withMnemonic mnemonic ((ForwardRateModel.Cast _ForwardRate.cell).MaxValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardRate.source + ".MaxValueAfter") 
                                               [| _ForwardRate.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardRate.cell
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
    [<ExcelFunction(Name="_ForwardRate_minValueAfter", Description="Create a ForwardRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRate_minValueAfter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRate",Description = "Reference to ForwardRate")>] 
         forwardrate : obj)
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

                let _ForwardRate = Helper.toCell<ForwardRate> forwardrate "ForwardRate"  
                let _i = Helper.toCell<int> i "i" 
                let _c = Helper.toCell<InterpolatedCurve> c "c" 
                let _validData = Helper.toCell<bool> validData "validData" 
                let _f = Helper.toCell<int> f "f" 
                let builder () = withMnemonic mnemonic ((ForwardRateModel.Cast _ForwardRate.cell).MinValueAfter
                                                            _i.cell 
                                                            _c.cell 
                                                            _validData.cell 
                                                            _f.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardRate.source + ".MinValueAfter") 
                                               [| _ForwardRate.source
                                               ;  _i.source
                                               ;  _c.source
                                               ;  _validData.source
                                               ;  _f.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardRate.cell
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
        dummy value at reference date update with new guess
    *)
    [<ExcelFunction(Name="_ForwardRate_updateGuess", Description="Create a ForwardRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRate_updateGuess
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRate",Description = "Reference to ForwardRate")>] 
         forwardrate : obj)
        ([<ExcelArgument(Name="data",Description = "Reference to data")>] 
         data : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRate = Helper.toCell<ForwardRate> forwardrate "ForwardRate"  
                let _data = Helper.toCell<Generic.List<double>> data "data" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((ForwardRateModel.Cast _ForwardRate.cell).UpdateGuess
                                                            _data.cell 
                                                            _forward.cell 
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : ForwardRate) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ForwardRate.source + ".UpdateGuess") 
                                               [| _ForwardRate.source
                                               ;  _data.source
                                               ;  _forward.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardRate.cell
                                ;  _data.cell
                                ;  _forward.cell
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
    [<ExcelFunction(Name="_ForwardRate_zeroYieldImpl", Description="Create a ForwardRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRate_zeroYieldImpl
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardRate",Description = "Reference to ForwardRate")>] 
         forwardrate : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardRate = Helper.toCell<ForwardRate> forwardrate "ForwardRate"  
                let _i = Helper.toCell<Interpolation> i "i" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((ForwardRateModel.Cast _ForwardRate.cell).ZeroYieldImpl
                                                            _i.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_ForwardRate.source + ".ZeroYieldImpl") 
                                               [| _ForwardRate.source
                                               ;  _i.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardRate.cell
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
    [<ExcelFunction(Name="_ForwardRate_Range", Description="Create a range of ForwardRate",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardRate_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ForwardRate")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ForwardRate> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ForwardRate>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ForwardRate>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ForwardRate>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
