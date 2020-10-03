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
  bilinear-interpolation factory
  </summary> *)
[<AutoSerializable(true)>]
module BilinearFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Bilinear_interpolate", Description="Create a Bilinear",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bilinear_interpolate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bilinear",Description = "Reference to Bilinear")>] 
         bilinear : obj)
        ([<ExcelArgument(Name="xBegin",Description = "Reference to xBegin")>] 
         xBegin : obj)
        ([<ExcelArgument(Name="xSize",Description = "Reference to xSize")>] 
         xSize : obj)
        ([<ExcelArgument(Name="yBegin",Description = "Reference to yBegin")>] 
         yBegin : obj)
        ([<ExcelArgument(Name="ySize",Description = "Reference to ySize")>] 
         ySize : obj)
        ([<ExcelArgument(Name="zData",Description = "Reference to zData")>] 
         zData : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bilinear = Helper.toCell<Bilinear> bilinear "Bilinear"  
                let _xBegin = Helper.toCell<Generic.List<double>> xBegin "xBegin" 
                let _xSize = Helper.toCell<int> xSize "xSize" 
                let _yBegin = Helper.toCell<Generic.List<double>> yBegin "yBegin" 
                let _ySize = Helper.toCell<int> ySize "ySize" 
                let _zData = Helper.toCell<Matrix> zData "zData" 
                let builder () = withMnemonic mnemonic ((BilinearModel.Cast _Bilinear.cell).Interpolate
                                                            _xBegin.cell 
                                                            _xSize.cell 
                                                            _yBegin.cell 
                                                            _ySize.cell 
                                                            _zData.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation2D>) l

                let source = Helper.sourceFold (_Bilinear.source + ".Interpolate") 
                                               [| _Bilinear.source
                                               ;  _xBegin.source
                                               ;  _xSize.source
                                               ;  _yBegin.source
                                               ;  _ySize.source
                                               ;  _zData.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bilinear.cell
                                ;  _xBegin.cell
                                ;  _xSize.cell
                                ;  _yBegin.cell
                                ;  _ySize.cell
                                ;  _zData.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bilinear> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_Bilinear_Range", Description="Create a range of Bilinear",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bilinear_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Bilinear")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Bilinear> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Bilinear>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Bilinear>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Bilinear>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
