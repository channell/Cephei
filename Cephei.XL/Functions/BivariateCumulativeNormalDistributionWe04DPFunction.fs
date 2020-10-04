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
  The implementation derives from the article "Better Approximations To Cumulative Normal Distibutions", Graeme West, Dec 2004 available at www.finmod.co.za. Also available in Wilmott Magazine, 2005, (May), 70-76, The main code is a port of the C++ code at www.finmod.co.za/cumfunctions.zip.  The algorithm is based on the near double-precision algorithm described in "Numerical Computation of Rectangular Bivariate an Trivariate Normal and t Probabilities", Genz (2004), Statistics and Computing 14, 151-160. (available at www.sci.wsu.edu/math/faculty/henz/homepage)  The QuantLib implementation mainly differs from the original code in two regards - The implementation of the cumulative normal distribution is QuantLib::CumulativeNormalDistribution - The arrays XX and W are zero-based  the correctness of the returned value is tested by checking it against known good results.
  </summary> *)
[<AutoSerializable(true)>]
module BivariateCumulativeNormalDistributionWe04DPFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BivariateCumulativeNormalDistributionWe04DP", Description="Create a BivariateCumulativeNormalDistributionWe04DP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BivariateCumulativeNormalDistributionWe04DP_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rho",Description = "Reference to rho")>] 
         rho : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rho = Helper.toCell<double> rho "rho" 
                let builder () = withMnemonic mnemonic (Fun.BivariateCumulativeNormalDistributionWe04DP 
                                                            _rho.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BivariateCumulativeNormalDistributionWe04DP>) l

                let source = Helper.sourceFold "Fun.BivariateCumulativeNormalDistributionWe04DP" 
                                               [| _rho.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rho.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BivariateCumulativeNormalDistributionWe04DP> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        function
    *)
    [<ExcelFunction(Name="_BivariateCumulativeNormalDistributionWe04DP_value", Description="Create a BivariateCumulativeNormalDistributionWe04DP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BivariateCumulativeNormalDistributionWe04DP_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BivariateCumulativeNormalDistributionWe04DP",Description = "Reference to BivariateCumulativeNormalDistributionWe04DP")>] 
         bivariatecumulativenormaldistributionwe04dp : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BivariateCumulativeNormalDistributionWe04DP = Helper.toCell<BivariateCumulativeNormalDistributionWe04DP> bivariatecumulativenormaldistributionwe04dp "BivariateCumulativeNormalDistributionWe04DP"  
                let _x = Helper.toCell<double> x "x" 
                let _y = Helper.toCell<double> y "y" 
                let builder () = withMnemonic mnemonic ((BivariateCumulativeNormalDistributionWe04DPModel.Cast _BivariateCumulativeNormalDistributionWe04DP.cell).Value
                                                            _x.cell 
                                                            _y.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BivariateCumulativeNormalDistributionWe04DP.source + ".Value") 
                                               [| _BivariateCumulativeNormalDistributionWe04DP.source
                                               ;  _x.source
                                               ;  _y.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BivariateCumulativeNormalDistributionWe04DP.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_BivariateCumulativeNormalDistributionWe04DP_Range", Description="Create a range of BivariateCumulativeNormalDistributionWe04DP",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BivariateCumulativeNormalDistributionWe04DP_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BivariateCumulativeNormalDistributionWe04DP")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BivariateCumulativeNormalDistributionWe04DP> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BivariateCumulativeNormalDistributionWe04DP>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BivariateCumulativeNormalDistributionWe04DP>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BivariateCumulativeNormalDistributionWe04DP>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
