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
namespace Cephei.QL

open System
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System.Collections
open System.Collections.Generic
open QLNet
open Cephei.QLNetHelper

(* <summary>
  A Gray code counter and bitwise operations are used for very fast sequence generation.  The implementation relies on primitive polynomials modulo two from the book "Monte Carlo Methods in Finance" by Peter Jдckel.  21 200 primitive polynomials modulo two are provided in QuantLib. Jдckel has calculated 8 129 334 polynomials: if you need that many dimensions you can replace the primitivepolynomials.c file included in QuantLib with the one provided in the CD of the "Monte Carlo Methods in Finance" book.  The choice of initialization numbers (also know as free direction integers) is crucial for the homogeneity properties of the sequence. Sobol defines two homogeneity properties: Property A and Property A'.  The unit initialization numbers suggested in "Numerical Recipes in C", 2nd edition, by Press, Teukolsky, Vetterling, and Flannery (section 7.7) fail the test for Property A even for low dimensions.  Bratley and Fox published coefficients of the free direction integers up to dimension 40, crediting unpublished work of Sobol' and Levitan. See Bratley, P., Fox, B.L. (1988) "Algorithm 659: Implementing Sobol's quasirandom sequence generator," ACM Transactions on Mathematical Software 14:88-100. These values satisfy Property A for d<=20 and d = 23, 31, 33, 34, 37; Property A' holds for d<=6.  Jдckel provides in his book (section 8.3) initialization numbers up to dimension 32. Coefficients for d<=8 are the same as in Bradley-Fox, so Property A' holds for d<=6 but Property A holds for d<=32.  The implementation of Lemieux, Cieslak, and Luttmer includes coefficients of the free direction integers up to dimension 360.  Coefficients for d<=40 are the same as in Bradley-Fox. For dimension 40<d<=360 the coefficients have been calculated as optimal values based on the "resolution" criterion. See "RandQMC user's guide - A package for randomized quasi-Monte Carlo methods in C," by C. Lemieux, M. Cieslak, and K. Luttmer, version January 13 2004, and references cited there (http://www.math.ucalgary.ca/~lemieux/randqmc.html). The values up to d<=360 has been provided to the QuantLib team by Christiane Lemieux, private communication, September 2004.  For more info on Sobol' sequences see also "Monte Carlo Methods in Financial Engineering," by P. Glasserman, 2004, Springer, section 5.2.3  The Joe--Kuo numbers and the Kuo numbers are due to Stephen Joe and Frances Kuo.  S. Joe and F. Y. Kuo, Constructing Sobol sequences with better two-dimensional projections, preprint Nov 22 2007  See http://web.maths.unsw.edu.au/~fkuo/sobol/ for more information.  Note that the Kuo numbers were generated to work with a different ordering of primitive polynomials for the first 40 or so dimensions which is why we have the Alternative Primitive Polynomials.  - the correctness of the returned values is tested by reproducing known good values. - the correctness of the returned values is tested by checking their discrepancy against known good values.
! \pre dimensionality must be <= PPMT_MAX_DIM
  </summary> *)
[<AutoSerializable(true)>]
type SobolRsgModel
    ( dimensionality                               : ICell<int>
    ) as this =

    inherit Model<SobolRsg> ()
(*
    Parameters
*)
    let _dimensionality                            = dimensionality
(*
    Functions
*)
    let _SobolRsg                                  = cell (fun () -> new SobolRsg (dimensionality.Value))
    let _dimension                                 = triv (fun () -> _SobolRsg.Value.dimension())
    let _factory                                   (dimensionality : ICell<int>) (seed : ICell<uint64>)   
                                                   = triv (fun () -> _SobolRsg.Value.factory(dimensionality.Value, seed.Value))
    let _lastSequence                              = triv (fun () -> _SobolRsg.Value.lastSequence())
    let _nextInt32Sequence                         = triv (fun () -> _SobolRsg.Value.nextInt32Sequence())
    let _nextSequence                              = triv (fun () -> _SobolRsg.Value.nextSequence())
    let _skipTo                                    (skip : ICell<uint64>)   
                                                   = triv (fun () -> _SobolRsg.Value.skipTo(skip.Value)
                                                                     _SobolRsg.Value)
    do this.Bind(_SobolRsg)
(* 
    casting 
*)
    internal new () = SobolRsgModel(null)
    member internal this.Inject v = _SobolRsg.Value <- v
    static member Cast (p : ICell<SobolRsg>) = 
        if p :? SobolRsgModel then 
            p :?> SobolRsgModel
        else
            let o = new SobolRsgModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.dimensionality                     = _dimensionality 
    member this.Dimension                          = _dimension
    member this.Factory                            dimensionality seed   
                                                   = _factory dimensionality seed 
    member this.LastSequence                       = _lastSequence
    member this.NextInt32Sequence                  = _nextInt32Sequence
    member this.NextSequence                       = _nextSequence
    member this.SkipTo                             skip   
                                                   = _skipTo skip 
(* <summary>
  A Gray code counter and bitwise operations are used for very fast sequence generation.  The implementation relies on primitive polynomials modulo two from the book "Monte Carlo Methods in Finance" by Peter Jдckel.  21 200 primitive polynomials modulo two are provided in QuantLib. Jдckel has calculated 8 129 334 polynomials: if you need that many dimensions you can replace the primitivepolynomials.c file included in QuantLib with the one provided in the CD of the "Monte Carlo Methods in Finance" book.  The choice of initialization numbers (also know as free direction integers) is crucial for the homogeneity properties of the sequence. Sobol defines two homogeneity properties: Property A and Property A'.  The unit initialization numbers suggested in "Numerical Recipes in C", 2nd edition, by Press, Teukolsky, Vetterling, and Flannery (section 7.7) fail the test for Property A even for low dimensions.  Bratley and Fox published coefficients of the free direction integers up to dimension 40, crediting unpublished work of Sobol' and Levitan. See Bratley, P., Fox, B.L. (1988) "Algorithm 659: Implementing Sobol's quasirandom sequence generator," ACM Transactions on Mathematical Software 14:88-100. These values satisfy Property A for d<=20 and d = 23, 31, 33, 34, 37; Property A' holds for d<=6.  Jдckel provides in his book (section 8.3) initialization numbers up to dimension 32. Coefficients for d<=8 are the same as in Bradley-Fox, so Property A' holds for d<=6 but Property A holds for d<=32.  The implementation of Lemieux, Cieslak, and Luttmer includes coefficients of the free direction integers up to dimension 360.  Coefficients for d<=40 are the same as in Bradley-Fox. For dimension 40<d<=360 the coefficients have been calculated as optimal values based on the "resolution" criterion. See "RandQMC user's guide - A package for randomized quasi-Monte Carlo methods in C," by C. Lemieux, M. Cieslak, and K. Luttmer, version January 13 2004, and references cited there (http://www.math.ucalgary.ca/~lemieux/randqmc.html). The values up to d<=360 has been provided to the QuantLib team by Christiane Lemieux, private communication, September 2004.  For more info on Sobol' sequences see also "Monte Carlo Methods in Financial Engineering," by P. Glasserman, 2004, Springer, section 5.2.3  The Joe--Kuo numbers and the Kuo numbers are due to Stephen Joe and Frances Kuo.  S. Joe and F. Y. Kuo, Constructing Sobol sequences with better two-dimensional projections, preprint Nov 22 2007  See http://web.maths.unsw.edu.au/~fkuo/sobol/ for more information.  Note that the Kuo numbers were generated to work with a different ordering of primitive polynomials for the first 40 or so dimensions which is why we have the Alternative Primitive Polynomials.  - the correctness of the returned values is tested by reproducing known good values. - the correctness of the returned values is tested by checking their discrepancy against known good values.
required for generics
  </summary> *)
[<AutoSerializable(true)>]
type SobolRsgModel1
    () as this =
    inherit Model<SobolRsg> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _SobolRsg                                  = cell (fun () -> new SobolRsg ())
    let _dimension                                 = triv (fun () -> _SobolRsg.Value.dimension())
    let _factory                                   (dimensionality : ICell<int>) (seed : ICell<uint64>)   
                                                   = triv (fun () -> _SobolRsg.Value.factory(dimensionality.Value, seed.Value))
    let _lastSequence                              = triv (fun () -> _SobolRsg.Value.lastSequence())
    let _nextInt32Sequence                         = triv (fun () -> _SobolRsg.Value.nextInt32Sequence())
    let _nextSequence                              = triv (fun () -> _SobolRsg.Value.nextSequence())
    let _skipTo                                    (skip : ICell<uint64>)   
                                                   = triv (fun () -> _SobolRsg.Value.skipTo(skip.Value)
                                                                     _SobolRsg.Value)
    do this.Bind(_SobolRsg)
(* 
    casting 
*)
    
    member internal this.Inject v = _SobolRsg.Value <- v
    static member Cast (p : ICell<SobolRsg>) = 
        if p :? SobolRsgModel1 then 
            p :?> SobolRsgModel1
        else
            let o = new SobolRsgModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Dimension                          = _dimension
    member this.Factory                            dimensionality seed   
                                                   = _factory dimensionality seed 
    member this.LastSequence                       = _lastSequence
    member this.NextInt32Sequence                  = _nextInt32Sequence
    member this.NextSequence                       = _nextSequence
    member this.SkipTo                             skip   
                                                   = _skipTo skip 
(* <summary>
  A Gray code counter and bitwise operations are used for very fast sequence generation.  The implementation relies on primitive polynomials modulo two from the book "Monte Carlo Methods in Finance" by Peter Jдckel.  21 200 primitive polynomials modulo two are provided in QuantLib. Jдckel has calculated 8 129 334 polynomials: if you need that many dimensions you can replace the primitivepolynomials.c file included in QuantLib with the one provided in the CD of the "Monte Carlo Methods in Finance" book.  The choice of initialization numbers (also know as free direction integers) is crucial for the homogeneity properties of the sequence. Sobol defines two homogeneity properties: Property A and Property A'.  The unit initialization numbers suggested in "Numerical Recipes in C", 2nd edition, by Press, Teukolsky, Vetterling, and Flannery (section 7.7) fail the test for Property A even for low dimensions.  Bratley and Fox published coefficients of the free direction integers up to dimension 40, crediting unpublished work of Sobol' and Levitan. See Bratley, P., Fox, B.L. (1988) "Algorithm 659: Implementing Sobol's quasirandom sequence generator," ACM Transactions on Mathematical Software 14:88-100. These values satisfy Property A for d<=20 and d = 23, 31, 33, 34, 37; Property A' holds for d<=6.  Jдckel provides in his book (section 8.3) initialization numbers up to dimension 32. Coefficients for d<=8 are the same as in Bradley-Fox, so Property A' holds for d<=6 but Property A holds for d<=32.  The implementation of Lemieux, Cieslak, and Luttmer includes coefficients of the free direction integers up to dimension 360.  Coefficients for d<=40 are the same as in Bradley-Fox. For dimension 40<d<=360 the coefficients have been calculated as optimal values based on the "resolution" criterion. See "RandQMC user's guide - A package for randomized quasi-Monte Carlo methods in C," by C. Lemieux, M. Cieslak, and K. Luttmer, version January 13 2004, and references cited there (http://www.math.ucalgary.ca/~lemieux/randqmc.html). The values up to d<=360 has been provided to the QuantLib team by Christiane Lemieux, private communication, September 2004.  For more info on Sobol' sequences see also "Monte Carlo Methods in Financial Engineering," by P. Glasserman, 2004, Springer, section 5.2.3  The Joe--Kuo numbers and the Kuo numbers are due to Stephen Joe and Frances Kuo.  S. Joe and F. Y. Kuo, Constructing Sobol sequences with better two-dimensional projections, preprint Nov 22 2007  See http://web.maths.unsw.edu.au/~fkuo/sobol/ for more information.  Note that the Kuo numbers were generated to work with a different ordering of primitive polynomials for the first 40 or so dimensions which is why we have the Alternative Primitive Polynomials.  - the correctness of the returned values is tested by reproducing known good values. - the correctness of the returned values is tested by checking their discrepancy against known good values.

  </summary> *)
[<AutoSerializable(true)>]
type SobolRsgModel2
    ( dimensionality                               : ICell<int>
    , seed                                         : ICell<uint64>
    , directionIntegers                            : ICell<SobolRsg.DirectionIntegers>
    ) as this =

    inherit Model<SobolRsg> ()
(*
    Parameters
*)
    let _dimensionality                            = dimensionality
    let _seed                                      = seed
    let _directionIntegers                         = directionIntegers
(*
    Functions
*)
    let _SobolRsg                                  = cell (fun () -> new SobolRsg (dimensionality.Value, seed.Value, directionIntegers.Value))
    let _dimension                                 = triv (fun () -> _SobolRsg.Value.dimension())
    let _factory                                   (dimensionality : ICell<int>) (seed : ICell<uint64>)   
                                                   = triv (fun () -> _SobolRsg.Value.factory(dimensionality.Value, seed.Value))
    let _lastSequence                              = triv (fun () -> _SobolRsg.Value.lastSequence())
    let _nextInt32Sequence                         = triv (fun () -> _SobolRsg.Value.nextInt32Sequence())
    let _nextSequence                              = triv (fun () -> _SobolRsg.Value.nextSequence())
    let _skipTo                                    (skip : ICell<uint64>)   
                                                   = triv (fun () -> _SobolRsg.Value.skipTo(skip.Value)
                                                                     _SobolRsg.Value)
    do this.Bind(_SobolRsg)
(* 
    casting 
*)
    internal new () = SobolRsgModel2(null,null,null)
    member internal this.Inject v = _SobolRsg.Value <- v
    static member Cast (p : ICell<SobolRsg>) = 
        if p :? SobolRsgModel2 then 
            p :?> SobolRsgModel2
        else
            let o = new SobolRsgModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.dimensionality                     = _dimensionality 
    member this.seed                               = _seed 
    member this.directionIntegers                  = _directionIntegers 
    member this.Dimension                          = _dimension
    member this.Factory                            dimensionality seed   
                                                   = _factory dimensionality seed 
    member this.LastSequence                       = _lastSequence
    member this.NextInt32Sequence                  = _nextInt32Sequence
    member this.NextSequence                       = _nextSequence
    member this.SkipTo                             skip   
                                                   = _skipTo skip 
(* <summary>
  A Gray code counter and bitwise operations are used for very fast sequence generation.  The implementation relies on primitive polynomials modulo two from the book "Monte Carlo Methods in Finance" by Peter Jдckel.  21 200 primitive polynomials modulo two are provided in QuantLib. Jдckel has calculated 8 129 334 polynomials: if you need that many dimensions you can replace the primitivepolynomials.c file included in QuantLib with the one provided in the CD of the "Monte Carlo Methods in Finance" book.  The choice of initialization numbers (also know as free direction integers) is crucial for the homogeneity properties of the sequence. Sobol defines two homogeneity properties: Property A and Property A'.  The unit initialization numbers suggested in "Numerical Recipes in C", 2nd edition, by Press, Teukolsky, Vetterling, and Flannery (section 7.7) fail the test for Property A even for low dimensions.  Bratley and Fox published coefficients of the free direction integers up to dimension 40, crediting unpublished work of Sobol' and Levitan. See Bratley, P., Fox, B.L. (1988) "Algorithm 659: Implementing Sobol's quasirandom sequence generator," ACM Transactions on Mathematical Software 14:88-100. These values satisfy Property A for d<=20 and d = 23, 31, 33, 34, 37; Property A' holds for d<=6.  Jдckel provides in his book (section 8.3) initialization numbers up to dimension 32. Coefficients for d<=8 are the same as in Bradley-Fox, so Property A' holds for d<=6 but Property A holds for d<=32.  The implementation of Lemieux, Cieslak, and Luttmer includes coefficients of the free direction integers up to dimension 360.  Coefficients for d<=40 are the same as in Bradley-Fox. For dimension 40<d<=360 the coefficients have been calculated as optimal values based on the "resolution" criterion. See "RandQMC user's guide - A package for randomized quasi-Monte Carlo methods in C," by C. Lemieux, M. Cieslak, and K. Luttmer, version January 13 2004, and references cited there (http://www.math.ucalgary.ca/~lemieux/randqmc.html). The values up to d<=360 has been provided to the QuantLib team by Christiane Lemieux, private communication, September 2004.  For more info on Sobol' sequences see also "Monte Carlo Methods in Financial Engineering," by P. Glasserman, 2004, Springer, section 5.2.3  The Joe--Kuo numbers and the Kuo numbers are due to Stephen Joe and Frances Kuo.  S. Joe and F. Y. Kuo, Constructing Sobol sequences with better two-dimensional projections, preprint Nov 22 2007  See http://web.maths.unsw.edu.au/~fkuo/sobol/ for more information.  Note that the Kuo numbers were generated to work with a different ordering of primitive polynomials for the first 40 or so dimensions which is why we have the Alternative Primitive Polynomials.  - the correctness of the returned values is tested by reproducing known good values. - the correctness of the returned values is tested by checking their discrepancy against known good values.

  </summary> *)
[<AutoSerializable(true)>]
type SobolRsgModel3
    ( dimensionality                               : ICell<int>
    , seed                                         : ICell<uint64>
    ) as this =

    inherit Model<SobolRsg> ()
(*
    Parameters
*)
    let _dimensionality                            = dimensionality
    let _seed                                      = seed
(*
    Functions
*)
    let _SobolRsg                                  = cell (fun () -> new SobolRsg (dimensionality.Value, seed.Value))
    let _dimension                                 = triv (fun () -> _SobolRsg.Value.dimension())
    let _factory                                   (dimensionality : ICell<int>) (seed : ICell<uint64>)   
                                                   = triv (fun () -> _SobolRsg.Value.factory(dimensionality.Value, seed.Value))
    let _lastSequence                              = triv (fun () -> _SobolRsg.Value.lastSequence())
    let _nextInt32Sequence                         = triv (fun () -> _SobolRsg.Value.nextInt32Sequence())
    let _nextSequence                              = triv (fun () -> _SobolRsg.Value.nextSequence())
    let _skipTo                                    (skip : ICell<uint64>)   
                                                   = triv (fun () -> _SobolRsg.Value.skipTo(skip.Value)
                                                                     _SobolRsg.Value)
    do this.Bind(_SobolRsg)
(* 
    casting 
*)
    internal new () = SobolRsgModel3(null,null)
    member internal this.Inject v = _SobolRsg.Value <- v
    static member Cast (p : ICell<SobolRsg>) = 
        if p :? SobolRsgModel3 then 
            p :?> SobolRsgModel3
        else
            let o = new SobolRsgModel3 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.dimensionality                     = _dimensionality 
    member this.seed                               = _seed 
    member this.Dimension                          = _dimension
    member this.Factory                            dimensionality seed   
                                                   = _factory dimensionality seed 
    member this.LastSequence                       = _lastSequence
    member this.NextInt32Sequence                  = _nextInt32Sequence
    member this.NextSequence                       = _nextSequence
    member this.SkipTo                             skip   
                                                   = _skipTo skip 
