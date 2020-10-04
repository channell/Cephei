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
  Lorig Pagliarani Pascucci expansion of order-3 for the Heston model. During calibration, it can be initialized once per expiry, and called many times with different strikes.  The formula is also available in the Mathematica notebook from the authors at http://explicitsolutions.wordpress.com/
  </summary> *)
[<AutoSerializable(true)>]
module LPP3HestonExpansionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LPP3HestonExpansion_impliedVolatility", Description="Create a LPP3HestonExpansion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LPP3HestonExpansion_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LPP3HestonExpansion",Description = "Reference to LPP3HestonExpansion")>] 
         lpp3hestonexpansion : obj)
        ([<ExcelArgument(Name="strike",Description = "Reference to strike")>] 
         strike : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LPP3HestonExpansion = Helper.toCell<LPP3HestonExpansion> lpp3hestonexpansion "LPP3HestonExpansion"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _forward = Helper.toCell<double> forward "forward" 
                let builder () = withMnemonic mnemonic ((LPP3HestonExpansionModel.Cast _LPP3HestonExpansion.cell).ImpliedVolatility
                                                            _strike.cell 
                                                            _forward.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_LPP3HestonExpansion.source + ".ImpliedVolatility") 
                                               [| _LPP3HestonExpansion.source
                                               ;  _strike.source
                                               ;  _forward.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LPP3HestonExpansion.cell
                                ;  _strike.cell
                                ;  _forward.cell
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
    [<ExcelFunction(Name="_LPP3HestonExpansion", Description="Create a LPP3HestonExpansion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LPP3HestonExpansion_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="kappa",Description = "Reference to kappa")>] 
         kappa : obj)
        ([<ExcelArgument(Name="theta",Description = "Reference to theta")>] 
         theta : obj)
        ([<ExcelArgument(Name="sigma",Description = "Reference to sigma")>] 
         sigma : obj)
        ([<ExcelArgument(Name="v0",Description = "Reference to v0")>] 
         v0 : obj)
        ([<ExcelArgument(Name="rho",Description = "Reference to rho")>] 
         rho : obj)
        ([<ExcelArgument(Name="term",Description = "Reference to term")>] 
         term : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _kappa = Helper.toCell<double> kappa "kappa" 
                let _theta = Helper.toCell<double> theta "theta" 
                let _sigma = Helper.toCell<double> sigma "sigma" 
                let _v0 = Helper.toCell<double> v0 "v0" 
                let _rho = Helper.toCell<double> rho "rho" 
                let _term = Helper.toCell<double> term "term" 
                let builder () = withMnemonic mnemonic (Fun.LPP3HestonExpansion 
                                                            _kappa.cell 
                                                            _theta.cell 
                                                            _sigma.cell 
                                                            _v0.cell 
                                                            _rho.cell 
                                                            _term.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LPP3HestonExpansion>) l

                let source = Helper.sourceFold "Fun.LPP3HestonExpansion" 
                                               [| _kappa.source
                                               ;  _theta.source
                                               ;  _sigma.source
                                               ;  _v0.source
                                               ;  _rho.source
                                               ;  _term.source
                                               |]
                let hash = Helper.hashFold 
                                [| _kappa.cell
                                ;  _theta.cell
                                ;  _sigma.cell
                                ;  _v0.cell
                                ;  _rho.cell
                                ;  _term.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LPP3HestonExpansion> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_LPP3HestonExpansion_Range", Description="Create a range of LPP3HestonExpansion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LPP3HestonExpansion_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LPP3HestonExpansion")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LPP3HestonExpansion> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LPP3HestonExpansion>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LPP3HestonExpansion>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LPP3HestonExpansion>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
