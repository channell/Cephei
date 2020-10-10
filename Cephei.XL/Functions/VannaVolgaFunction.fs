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
  %VannaVolga-interpolation factory and traits
  </summary> *)
[<AutoSerializable(true)>]
module VannaVolgaFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_VannaVolga_interpolate", Description="Create a VannaVolga",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolga_interpolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolga",Description = "Reference to VannaVolga")>] 
         vannavolga : obj)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="size",Description = "Reference to size")>] 
         size : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolga = Helper.toCell<VannaVolga> vannavolga "VannaVolga"  
                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _size = Helper.toCell<int> size "size" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let builder (current : ICell) = withMnemonic mnemonic ((VannaVolgaModel.Cast _VannaVolga.cell).Interpolate
                                                            _xBegin.cell 
                                                            _size.cell 
                                                            _yBegin.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source () = Helper.sourceFold (_VannaVolga.source + ".Interpolate") 
                                               [| _VannaVolga.source
                                               ;  _xBegin.source
                                               ;  _size.source
                                               ;  _yBegin.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolga.cell
                                ;  _xBegin.cell
                                ;  _size.cell
                                ;  _yBegin.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VannaVolga> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_VannaVolga", Description="Create a VannaVolga",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolga_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="spot",Description = "Reference to spot")>] 
         spot : obj)
        ([<ExcelArgument(Name="dDiscount",Description = "Reference to dDiscount")>] 
         dDiscount : obj)
        ([<ExcelArgument(Name="fDiscount",Description = "Reference to fDiscount")>] 
         fDiscount : obj)
        ([<ExcelArgument(Name="T",Description = "Reference to T")>] 
         T : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _spot = Helper.toCell<double> spot "spot" 
                let _dDiscount = Helper.toCell<double> dDiscount "dDiscount" 
                let _fDiscount = Helper.toCell<double> fDiscount "fDiscount" 
                let _T = Helper.toCell<double> T "T" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.VannaVolga 
                                                            _spot.cell 
                                                            _dDiscount.cell 
                                                            _fDiscount.cell 
                                                            _T.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VannaVolga>) l

                let source () = Helper.sourceFold "Fun.VannaVolga" 
                                               [| _spot.source
                                               ;  _dDiscount.source
                                               ;  _fDiscount.source
                                               ;  _T.source
                                               |]
                let hash = Helper.hashFold 
                                [| _spot.cell
                                ;  _dDiscount.cell
                                ;  _fDiscount.cell
                                ;  _T.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VannaVolga> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_VannaVolga_Range", Description="Create a range of VannaVolga",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolga_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the VannaVolga")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<VannaVolga> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<VannaVolga>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<VannaVolga>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<VannaVolga>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
