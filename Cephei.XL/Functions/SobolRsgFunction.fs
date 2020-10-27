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
  A Gray code counter and bitwise operations are used for very fast sequence generation.  The implementation relies on primitive polynomials modulo two from the book "Monte Carlo Methods in Finance" by Peter Jдckel.  21 200 primitive polynomials modulo two are provided in QuantLib. Jдckel has calculated 8 129 334 polynomials: if you need that many dimensions you can replace the primitivepolynomials.c file included in QuantLib with the one provided in the CD of the "Monte Carlo Methods in Finance" book.  The choice of initialization numbers (also know as free direction integers) is crucial for the homogeneity properties of the sequence. Sobol defines two homogeneity properties: Property A and Property A'.  The unit initialization numbers suggested in "Numerical Recipes in C", 2nd edition, by Press, Teukolsky, Vetterling, and Flannery (section 7.7) fail the test for Property A even for low dimensions.  Bratley and Fox published coefficients of the free direction integers up to dimension 40, crediting unpublished work of Sobol' and Levitan. See Bratley, P., Fox, B.L. (1988) "Algorithm 659: Implementing Sobol's quasirandom sequence generator," ACM Transactions on Mathematical Software 14:88-100. These values satisfy Property A for d<=20 and d = 23, 31, 33, 34, 37; Property A' holds for d<=6.  Jдckel provides in his book (section 8.3) initialization numbers up to dimension 32. Coefficients for d<=8 are the same as in Bradley-Fox, so Property A' holds for d<=6 but Property A holds for d<=32.  The implementation of Lemieux, Cieslak, and Luttmer includes coefficients of the free direction integers up to dimension 360.  Coefficients for d<=40 are the same as in Bradley-Fox. For dimension 40<d<=360 the coefficients have been calculated as optimal values based on the "resolution" criterion. See "RandQMC user's guide - A package for randomized quasi-Monte Carlo methods in C," by C. Lemieux, M. Cieslak, and K. Luttmer, version January 13 2004, and references cited there (http://www.math.ucalgary.ca/~lemieux/randqmc.html). The values up to d<=360 has been provided to the QuantLib team by Christiane Lemieux, private communication, September 2004.  For more info on Sobol' sequences see also "Monte Carlo Methods in Financial Engineering," by P. Glasserman, 2004, Springer, section 5.2.3  The Joe--Kuo numbers and the Kuo numbers are due to Stephen Joe and Frances Kuo.  S. Joe and F. Y. Kuo, Constructing Sobol sequences with better two-dimensional projections, preprint Nov 22 2007  See http://web.maths.unsw.edu.au/~fkuo/sobol/ for more information.  Note that the Kuo numbers were generated to work with a different ordering of primitive polynomials for the first 40 or so dimensions which is why we have the Alternative Primitive Polynomials.  - the correctness of the returned values is tested by reproducing known good values. - the correctness of the returned values is tested by checking their discrepancy against known good values.
  </summary> *)
[<AutoSerializable(true)>]
module SobolRsgFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SobolRsg_dimension", Description="Create a SobolRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolRsg_dimension
        ([<ExcelArgument(Name="Mnemonic",Description = "IRNG")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolRsg",Description = "SobolRsg")>] 
         sobolrsg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolRsg = Helper.toCell<SobolRsg> sobolrsg "SobolRsg"  
                let builder (current : ICell) = withMnemonic mnemonic ((SobolRsgModel.Cast _SobolRsg.cell).Dimension
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_SobolRsg.source + ".Dimension") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SobolRsg.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_SobolRsg_factory", Description="Create a SobolRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolRsg_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "IRNG")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolRsg",Description = "SobolRsg")>] 
         sobolrsg : obj)
        ([<ExcelArgument(Name="dimensionality",Description = "int")>] 
         dimensionality : obj)
        ([<ExcelArgument(Name="seed",Description = "uint64")>] 
         seed : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolRsg = Helper.toCell<SobolRsg> sobolrsg "SobolRsg"  
                let _dimensionality = Helper.toCell<int> dimensionality "dimensionality" 
                let _seed = Helper.toCell<uint64> seed "seed" 
                let builder (current : ICell) = withMnemonic mnemonic ((SobolRsgModel.Cast _SobolRsg.cell).Factory
                                                            _dimensionality.cell 
                                                            _seed.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IRNG>) l

                let source () = Helper.sourceFold (_SobolRsg.source + ".Factory") 

                                               [| _dimensionality.source
                                               ;  _seed.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SobolRsg.cell
                                ;  _dimensionality.cell
                                ;  _seed.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SobolRsg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    (*!! Sample not supported by helper
    [<ExcelFunction(Name="_SobolRsg_lastSequence", Description="Create a SobolRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolRsg_lastSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "SobolRsg")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolRsg",Description = "SobolRsg")>] 
         sobolrsg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolRsg = Helper.toCell<SobolRsg> sobolrsg "SobolRsg"  
                let builder (current : ICell) = withMnemonic mnemonic ((SobolRsgModel.Cast _SobolRsg.cell).LastSequence
                                                       ) :> ICell
                let format (i : Sample<Generic.List<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SobolRsg.source + ".LastSequence") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SobolRsg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_SobolRsg_nextInt32Sequence", Description="Create a SobolRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolRsg_nextInt32Sequence
        ([<ExcelArgument(Name="Mnemonic",Description = "SobolRsg")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolRsg",Description = "SobolRsg")>] 
         sobolrsg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolRsg = Helper.toCell<SobolRsg> sobolrsg "SobolRsg"  
                let builder (current : ICell) = withMnemonic mnemonic ((SobolRsgModel.Cast _SobolRsg.cell).NextInt32Sequence
                                                       ) :> ICell
                let format (i : Generic.List<uint64>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SobolRsg.source + ".NextInt32Sequence") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SobolRsg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    (*!! Sample not supported by Helper
    [<ExcelFunction(Name="_SobolRsg_nextSequence", Description="Create a SobolRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolRsg_nextSequence
        ([<ExcelArgument(Name="Mnemonic",Description = "SobolRsg")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolRsg",Description = "SobolRsg")>] 
         sobolrsg : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolRsg = Helper.toCell<SobolRsg> sobolrsg "SobolRsg"  
                let builder (current : ICell) = withMnemonic mnemonic ((SobolRsgModel.Cast _SobolRsg.cell).NextSequence
                                                       ) :> ICell
                let format (i : Sample<Generic.List<double>>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_SobolRsg.source + ".NextSequence") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _SobolRsg.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
            *)
    (*
        ! skip to the n-th sample in the low-discrepancy sequence
    *)
    [<ExcelFunction(Name="_SobolRsg_skipTo", Description="Create a SobolRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolRsg_skipTo
        ([<ExcelArgument(Name="Mnemonic",Description = "SobolRsg")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SobolRsg",Description = "SobolRsg")>] 
         sobolrsg : obj)
        ([<ExcelArgument(Name="skip",Description = "uint64")>] 
         skip : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SobolRsg = Helper.toCell<SobolRsg> sobolrsg "SobolRsg"  
                let _skip = Helper.toCell<uint64> skip "skip" 
                let builder (current : ICell) = withMnemonic mnemonic ((SobolRsgModel.Cast _SobolRsg.cell).SkipTo
                                                            _skip.cell 
                                                       ) :> ICell
                let format (o : SobolRsg) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_SobolRsg.source + ".SkipTo") 

                                               [| _skip.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SobolRsg.cell
                                ;  _skip.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_SobolRsg2", Description="Create a SobolRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolRsg_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "SobolRsg")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dimensionality",Description = "int")>] 
         dimensionality : obj)
        ([<ExcelArgument(Name="seed",Description = "uint64")>] 
         seed : obj)
        ([<ExcelArgument(Name="directionIntegers",Description = "SobolRsg.DirectionIntegers: Unit, Jaeckel, SobolLevitan, SobolLevitanLemieux, JoeKuoD5, JoeKuoD6, JoeKuoD7, Kuo, Kuo2, Kuo3")>] 
         directionIntegers : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dimensionality = Helper.toCell<int> dimensionality "dimensionality" 
                let _seed = Helper.toCell<uint64> seed "seed" 
                let _directionIntegers = Helper.toCell<SobolRsg.DirectionIntegers> directionIntegers "directionIntegers" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SobolRsg2 
                                                            _dimensionality.cell 
                                                            _seed.cell 
                                                            _directionIntegers.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SobolRsg>) l

                let source () = Helper.sourceFold "Fun.SobolRsg2" 
                                               [| _dimensionality.source
                                               ;  _seed.source
                                               ;  _directionIntegers.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dimensionality.cell
                                ;  _seed.cell
                                ;  _directionIntegers.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SobolRsg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SobolRsg3", Description="Create a SobolRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolRsg_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "SobolRsg")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dimensionality",Description = "int")>] 
         dimensionality : obj)
        ([<ExcelArgument(Name="seed",Description = "uint64")>] 
         seed : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dimensionality = Helper.toCell<int> dimensionality "dimensionality" 
                let _seed = Helper.toCell<uint64> seed "seed" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SobolRsg3
                                                            _dimensionality.cell 
                                                            _seed.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SobolRsg>) l

                let source () = Helper.sourceFold "Fun.SobolRsg3" 
                                               [| _dimensionality.source
                                               ;  _seed.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dimensionality.cell
                                ;  _seed.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SobolRsg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! \pre dimensionality must be <= PPMT_MAX_DIM
    *)
    [<ExcelFunction(Name="_SobolRsg", Description="Create a SobolRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolRsg_create
        ([<ExcelArgument(Name="Mnemonic",Description = "SobolRsg")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dimensionality",Description = "int")>] 
         dimensionality : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dimensionality = Helper.toCell<int> dimensionality "dimensionality" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.SobolRsg
                                                            _dimensionality.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SobolRsg>) l

                let source () = Helper.sourceFold "Fun.SobolRsg" 
                                               [| _dimensionality.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dimensionality.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SobolRsg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        required for generics
    *)
    [<ExcelFunction(Name="_SobolRsg1", Description="Create a SobolRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolRsg_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "SobolRsg")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.SobolRsg1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SobolRsg>) l

                let source () = Helper.sourceFold "Fun.SobolRsg1 " 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SobolRsg> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SobolRsg_Range", Description="Create a range of SobolRsg",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let SobolRsg_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SobolRsg> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SobolRsg>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<SobolRsg>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<SobolRsg>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
