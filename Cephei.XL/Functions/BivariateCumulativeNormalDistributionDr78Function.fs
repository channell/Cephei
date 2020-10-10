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
  Drezner (1978) algorithm, six decimal places accuracy.  For this implementation see "Option pricing formulas", E.G. Haug, McGraw-Hill 1998  check accuracy of this algorithm and compare with: 1) Drezner, Z, (1978), Computation of the bivariate normal integral, Mathematics of Computation 32, pp. 277-279. 2) Drezner, Z. and Wesolowsky, G. O. (1990) `On the Computation of the Bivariate Normal Integral', Journal of Statistical Computation and Simulation 35, pp. 101-107. 3) Drezner, Z (1992) Computation of the Multivariate Normal Integral, ACM Transactions on Mathematics Software 18, pp. 450-460. 4) Drezner, Z (1994) Computation of the Trivariate Normal Integral, Mathematics of Computation 62, pp. 289-294. 5) Genz, A. (1992) `Numerical Computation of the Multivariate Normal Probabilities', J. Comput. Graph. Stat. 1, pp. 141-150.  the correctness of the returned value is tested by checking it against known good results.
  </summary> *)
[<AutoSerializable(true)>]
module BivariateCumulativeNormalDistributionDr78Function =

    (*
        
    *)
    [<ExcelFunction(Name="_BivariateCumulativeNormalDistributionDr78", Description="Create a BivariateCumulativeNormalDistributionDr78",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BivariateCumulativeNormalDistributionDr78_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rho",Description = "Reference to rho")>] 
         rho : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rho = Helper.toCell<double> rho "rho" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.BivariateCumulativeNormalDistributionDr78 
                                                            _rho.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BivariateCumulativeNormalDistributionDr78>) l

                let source () = Helper.sourceFold "Fun.BivariateCumulativeNormalDistributionDr78" 
                                               [| _rho.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rho.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BivariateCumulativeNormalDistributionDr78> format
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
    [<ExcelFunction(Name="_BivariateCumulativeNormalDistributionDr78_value", Description="Create a BivariateCumulativeNormalDistributionDr78",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BivariateCumulativeNormalDistributionDr78_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BivariateCumulativeNormalDistributionDr78",Description = "Reference to BivariateCumulativeNormalDistributionDr78")>] 
         bivariatecumulativenormaldistributiondr78 : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BivariateCumulativeNormalDistributionDr78 = Helper.toCell<BivariateCumulativeNormalDistributionDr78> bivariatecumulativenormaldistributiondr78 "BivariateCumulativeNormalDistributionDr78"  
                let _a = Helper.toCell<double> a "a" 
                let _b = Helper.toCell<double> b "b" 
                let builder (current : ICell) = withMnemonic mnemonic ((BivariateCumulativeNormalDistributionDr78Model.Cast _BivariateCumulativeNormalDistributionDr78.cell).Value
                                                            _a.cell 
                                                            _b.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_BivariateCumulativeNormalDistributionDr78.source + ".Value") 
                                               [| _BivariateCumulativeNormalDistributionDr78.source
                                               ;  _a.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BivariateCumulativeNormalDistributionDr78.cell
                                ;  _a.cell
                                ;  _b.cell
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
    [<ExcelFunction(Name="_BivariateCumulativeNormalDistributionDr78_Range", Description="Create a range of BivariateCumulativeNormalDistributionDr78",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BivariateCumulativeNormalDistributionDr78_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BivariateCumulativeNormalDistributionDr78")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BivariateCumulativeNormalDistributionDr78> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BivariateCumulativeNormalDistributionDr78>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<BivariateCumulativeNormalDistributionDr78>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<BivariateCumulativeNormalDistributionDr78>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
