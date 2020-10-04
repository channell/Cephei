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
  Mersenne Twister random number generator of period 2**19937-1  For more details see http://www.math.keio.ac.jp/matumoto/emt.html  the correctness of the returned values is tested by checking them against known good results.
  </summary> *)
[<AutoSerializable(true)>]
module MersenneTwisterUniformRngFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MersenneTwisterUniformRng_factory", Description="Create a MersenneTwisterUniformRng",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MersenneTwisterUniformRng_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MersenneTwisterUniformRng",Description = "Reference to MersenneTwisterUniformRng")>] 
         mersennetwisteruniformrng : obj)
        ([<ExcelArgument(Name="seed",Description = "Reference to seed")>] 
         seed : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MersenneTwisterUniformRng = Helper.toCell<MersenneTwisterUniformRng> mersennetwisteruniformrng "MersenneTwisterUniformRng"  
                let _seed = Helper.toCell<uint64> seed "seed" 
                let builder () = withMnemonic mnemonic ((MersenneTwisterUniformRngModel.Cast _MersenneTwisterUniformRng.cell).Factory
                                                            _seed.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IRNGTraits>) l

                let source = Helper.sourceFold (_MersenneTwisterUniformRng.source + ".Factory") 
                                               [| _MersenneTwisterUniformRng.source
                                               ;  _seed.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MersenneTwisterUniformRng.cell
                                ;  _seed.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MersenneTwisterUniformRng> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MersenneTwisterUniformRng2", Description="Create a MersenneTwisterUniformRng",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MersenneTwisterUniformRng_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="seeds",Description = "Reference to seeds")>] 
         seeds : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _seeds = Helper.toCell<Generic.List<uint64>> seeds "seeds" 
                let builder () = withMnemonic mnemonic (Fun.MersenneTwisterUniformRng2
                                                            _seeds.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MersenneTwisterUniformRng>) l

                let source = Helper.sourceFold "Fun.MersenneTwisterUniformRng2" 
                                               [| _seeds.source
                                               |]
                let hash = Helper.hashFold 
                                [| _seeds.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MersenneTwisterUniformRng> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MersenneTwisterUniformRng", Description="Create a MersenneTwisterUniformRng",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MersenneTwisterUniformRng_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="seed",Description = "Reference to seed")>] 
         seed : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _seed = Helper.toCell<uint64> seed "seed" 
                let builder () = withMnemonic mnemonic (Fun.MersenneTwisterUniformRng
                                                            _seed.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MersenneTwisterUniformRng>) l

                let source = Helper.sourceFold "Fun.MersenneTwisterUniformRng" 
                                               [| _seed.source
                                               |]
                let hash = Helper.hashFold 
                                [| _seed.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MersenneTwisterUniformRng> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! if the given seed is 0, a random seed will be chosen based on clock()
    *)
    [<ExcelFunction(Name="_MersenneTwisterUniformRng1", Description="Create a MersenneTwisterUniformRng",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MersenneTwisterUniformRng_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.MersenneTwisterUniformRng1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MersenneTwisterUniformRng>) l

                let source = Helper.sourceFold "Fun.MersenneTwisterUniformRng1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MersenneTwisterUniformRng> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns a sample with weight 1.0 containing a random number on (0.0, 1.0)-real-interval
    *)
    [<ExcelFunction(Name="_MersenneTwisterUniformRng_next", Description="Create a MersenneTwisterUniformRng",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MersenneTwisterUniformRng_next
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MersenneTwisterUniformRng",Description = "Reference to MersenneTwisterUniformRng")>] 
         mersennetwisteruniformrng : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MersenneTwisterUniformRng = Helper.toCell<MersenneTwisterUniformRng> mersennetwisteruniformrng "MersenneTwisterUniformRng"  
                let builder () = withMnemonic mnemonic ((MersenneTwisterUniformRngModel.Cast _MersenneTwisterUniformRng.cell).Next
                                                       ) :> ICell
                let format (o : Sample<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MersenneTwisterUniformRng.source + ".Next") 
                                               [| _MersenneTwisterUniformRng.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MersenneTwisterUniformRng.cell
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
        ! return  a random number on [0,0xffffffff]-interval
    *)
    [<ExcelFunction(Name="_MersenneTwisterUniformRng_nextInt32", Description="Create a MersenneTwisterUniformRng",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MersenneTwisterUniformRng_nextInt32
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MersenneTwisterUniformRng",Description = "Reference to MersenneTwisterUniformRng")>] 
         mersennetwisteruniformrng : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MersenneTwisterUniformRng = Helper.toCell<MersenneTwisterUniformRng> mersennetwisteruniformrng "MersenneTwisterUniformRng"  
                let builder () = withMnemonic mnemonic ((MersenneTwisterUniformRngModel.Cast _MersenneTwisterUniformRng.cell).NextInt32
                                                       ) :> ICell
                let format (o : uint64) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MersenneTwisterUniformRng.source + ".NextInt32") 
                                               [| _MersenneTwisterUniformRng.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MersenneTwisterUniformRng.cell
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
        ! return a random number in the (0.0, 1.0)-interval
    *)
    [<ExcelFunction(Name="_MersenneTwisterUniformRng_nextReal", Description="Create a MersenneTwisterUniformRng",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MersenneTwisterUniformRng_nextReal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MersenneTwisterUniformRng",Description = "Reference to MersenneTwisterUniformRng")>] 
         mersennetwisteruniformrng : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MersenneTwisterUniformRng = Helper.toCell<MersenneTwisterUniformRng> mersennetwisteruniformrng "MersenneTwisterUniformRng"  
                let builder () = withMnemonic mnemonic ((MersenneTwisterUniformRngModel.Cast _MersenneTwisterUniformRng.cell).NextReal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MersenneTwisterUniformRng.source + ".NextReal") 
                                               [| _MersenneTwisterUniformRng.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MersenneTwisterUniformRng.cell
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
    [<ExcelFunction(Name="_MersenneTwisterUniformRng_Range", Description="Create a range of MersenneTwisterUniformRng",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MersenneTwisterUniformRng_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MersenneTwisterUniformRng")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MersenneTwisterUniformRng> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MersenneTwisterUniformRng>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MersenneTwisterUniformRng>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MersenneTwisterUniformRng>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
