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
  Small-time expansion from "The small-time smile and term structure of implied volatility under the Heston model" M Forde, A Jacquier, R Lee - SIAM Journal on Financial Mathematics, 2012 - SIAM
  </summary> *)
[<AutoSerializable(true)>]
module FordeHestonExpansionFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FordeHestonExpansion", Description="Create a FordeHestonExpansion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FordeHestonExpansion_create
        ([<ExcelArgument(Name="Mnemonic",Description = "FordeHestonExpansion")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="kappa",Description = "double")>] 
         kappa : obj)
        ([<ExcelArgument(Name="theta",Description = "double")>] 
         theta : obj)
        ([<ExcelArgument(Name="sigma",Description = "double")>] 
         sigma : obj)
        ([<ExcelArgument(Name="v0",Description = "double")>] 
         v0 : obj)
        ([<ExcelArgument(Name="rho",Description = "double")>] 
         rho : obj)
        ([<ExcelArgument(Name="term",Description = "double")>] 
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FordeHestonExpansion 
                                                            _kappa.cell 
                                                            _theta.cell 
                                                            _sigma.cell 
                                                            _v0.cell 
                                                            _rho.cell 
                                                            _term.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FordeHestonExpansion>) l

                let source () = Helper.sourceFold "Fun.FordeHestonExpansion" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FordeHestonExpansion> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FordeHestonExpansion_impliedVolatility", Description="Create a FordeHestonExpansion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FordeHestonExpansion_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FordeHestonExpansion",Description = "FordeHestonExpansion")>] 
         fordehestonexpansion : obj)
        ([<ExcelArgument(Name="strike",Description = "double")>] 
         strike : obj)
        ([<ExcelArgument(Name="forward",Description = "double")>] 
         forward : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FordeHestonExpansion = Helper.toCell<FordeHestonExpansion> fordehestonexpansion "FordeHestonExpansion"  
                let _strike = Helper.toCell<double> strike "strike" 
                let _forward = Helper.toCell<double> forward "forward" 
                let builder (current : ICell) = withMnemonic mnemonic ((FordeHestonExpansionModel.Cast _FordeHestonExpansion.cell).ImpliedVolatility
                                                            _strike.cell 
                                                            _forward.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FordeHestonExpansion.source + ".ImpliedVolatility") 

                                               [| _strike.source
                                               ;  _forward.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FordeHestonExpansion.cell
                                ;  _strike.cell
                                ;  _forward.cell
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
    [<ExcelFunction(Name="_FordeHestonExpansion_Range", Description="Create a range of FordeHestonExpansion",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FordeHestonExpansion_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FordeHestonExpansion> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FordeHestonExpansion>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<FordeHestonExpansion>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<FordeHestonExpansion>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
