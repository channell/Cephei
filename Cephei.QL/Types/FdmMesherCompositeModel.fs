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


  </summary> *)
[<AutoSerializable(true)>]
type FdmMesherCompositeModel
    ( layout                                       : ICell<FdmLinearOpLayout>
    , mesher                                       : ICell<Generic.List<Fdm1dMesher>>
    ) as this =

    inherit Model<FdmMesherComposite> ()
(*
    Parameters
*)
    let _layout                                    = layout
    let _mesher                                    = mesher
(*
    Functions
*)
    let _FdmMesherComposite                        = cell (fun () -> new FdmMesherComposite (layout.Value, mesher.Value))
    let _dminus                                    (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.dminus(iter.Value, direction.Value))
    let _dplus                                     (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.dplus(iter.Value, direction.Value))
    let _getFdm1dMeshers                           = triv (fun () -> _FdmMesherComposite.Value.getFdm1dMeshers())
    let _location                                  (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.location(iter.Value, direction.Value))
    let _locations                                 (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.locations(direction.Value))
    let _layout                                    = triv (fun () -> _FdmMesherComposite.Value.layout())
    do this.Bind(_FdmMesherComposite)
(* 
    casting 
*)
    internal new () = new FdmMesherCompositeModel(null,null)
    member internal this.Inject v = _FdmMesherComposite.Value <- v
    static member Cast (p : ICell<FdmMesherComposite>) = 
        if p :? FdmMesherCompositeModel then 
            p :?> FdmMesherCompositeModel
        else
            let o = new FdmMesherCompositeModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.layout                             = _layout 
    member this.mesher                             = _mesher 
    member this.Dminus                             iter direction   
                                                   = _dminus iter direction 
    member this.Dplus                              iter direction   
                                                   = _dplus iter direction 
    member this.GetFdm1dMeshers                    = _getFdm1dMeshers
    member this.Location                           iter direction   
                                                   = _location iter direction 
    member this.Locations                          direction   
                                                   = _locations direction 
    member this.Layout                             = _layout
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type FdmMesherCompositeModel1
    ( mesher                                       : ICell<Generic.List<Fdm1dMesher>>
    ) as this =

    inherit Model<FdmMesherComposite> ()
(*
    Parameters
*)
    let _mesher                                    = mesher
(*
    Functions
*)
    let _FdmMesherComposite                        = cell (fun () -> new FdmMesherComposite (mesher.Value))
    let _dminus                                    (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.dminus(iter.Value, direction.Value))
    let _dplus                                     (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.dplus(iter.Value, direction.Value))
    let _getFdm1dMeshers                           = triv (fun () -> _FdmMesherComposite.Value.getFdm1dMeshers())
    let _location                                  (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.location(iter.Value, direction.Value))
    let _locations                                 (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.locations(direction.Value))
    let _layout                                    = triv (fun () -> _FdmMesherComposite.Value.layout())
    do this.Bind(_FdmMesherComposite)
(* 
    casting 
*)
    internal new () = new FdmMesherCompositeModel1(null)
    member internal this.Inject v = _FdmMesherComposite.Value <- v
    static member Cast (p : ICell<FdmMesherComposite>) = 
        if p :? FdmMesherCompositeModel1 then 
            p :?> FdmMesherCompositeModel1
        else
            let o = new FdmMesherCompositeModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.mesher                             = _mesher 
    member this.Dminus                             iter direction   
                                                   = _dminus iter direction 
    member this.Dplus                              iter direction   
                                                   = _dplus iter direction 
    member this.GetFdm1dMeshers                    = _getFdm1dMeshers
    member this.Location                           iter direction   
                                                   = _location iter direction 
    member this.Locations                          direction   
                                                   = _locations direction 
    member this.Layout                             = _layout
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type FdmMesherCompositeModel2
    ( m1                                           : ICell<Fdm1dMesher>
    , m2                                           : ICell<Fdm1dMesher>
    , m3                                           : ICell<Fdm1dMesher>
    , m4                                           : ICell<Fdm1dMesher>
    ) as this =

    inherit Model<FdmMesherComposite> ()
(*
    Parameters
*)
    let _m1                                        = m1
    let _m2                                        = m2
    let _m3                                        = m3
    let _m4                                        = m4
(*
    Functions
*)
    let _FdmMesherComposite                        = cell (fun () -> new FdmMesherComposite (m1.Value, m2.Value, m3.Value, m4.Value))
    let _dminus                                    (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.dminus(iter.Value, direction.Value))
    let _dplus                                     (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.dplus(iter.Value, direction.Value))
    let _getFdm1dMeshers                           = triv (fun () -> _FdmMesherComposite.Value.getFdm1dMeshers())
    let _location                                  (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.location(iter.Value, direction.Value))
    let _locations                                 (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.locations(direction.Value))
    let _layout                                    = triv (fun () -> _FdmMesherComposite.Value.layout())
    do this.Bind(_FdmMesherComposite)
(* 
    casting 
*)
    internal new () = new FdmMesherCompositeModel2(null,null,null,null)
    member internal this.Inject v = _FdmMesherComposite.Value <- v
    static member Cast (p : ICell<FdmMesherComposite>) = 
        if p :? FdmMesherCompositeModel2 then 
            p :?> FdmMesherCompositeModel2
        else
            let o = new FdmMesherCompositeModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.m1                                 = _m1 
    member this.m2                                 = _m2 
    member this.m3                                 = _m3 
    member this.m4                                 = _m4 
    member this.Dminus                             iter direction   
                                                   = _dminus iter direction 
    member this.Dplus                              iter direction   
                                                   = _dplus iter direction 
    member this.GetFdm1dMeshers                    = _getFdm1dMeshers
    member this.Location                           iter direction   
                                                   = _location iter direction 
    member this.Locations                          direction   
                                                   = _locations direction 
    member this.Layout                             = _layout
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type FdmMesherCompositeModel3
    ( mesher                                       : ICell<Fdm1dMesher>
    ) as this =

    inherit Model<FdmMesherComposite> ()
(*
    Parameters
*)
    let _mesher                                    = mesher
(*
    Functions
*)
    let _FdmMesherComposite                        = cell (fun () -> new FdmMesherComposite (mesher.Value))
    let _dminus                                    (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.dminus(iter.Value, direction.Value))
    let _dplus                                     (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.dplus(iter.Value, direction.Value))
    let _getFdm1dMeshers                           = triv (fun () -> _FdmMesherComposite.Value.getFdm1dMeshers())
    let _location                                  (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.location(iter.Value, direction.Value))
    let _locations                                 (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.locations(direction.Value))
    let _layout                                    = triv (fun () -> _FdmMesherComposite.Value.layout())
    do this.Bind(_FdmMesherComposite)
(* 
    casting 
*)
    internal new () = new FdmMesherCompositeModel3(null)
    member internal this.Inject v = _FdmMesherComposite.Value <- v
    static member Cast (p : ICell<FdmMesherComposite>) = 
        if p :? FdmMesherCompositeModel3 then 
            p :?> FdmMesherCompositeModel3
        else
            let o = new FdmMesherCompositeModel3 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.mesher                             = _mesher 
    member this.Dminus                             iter direction   
                                                   = _dminus iter direction 
    member this.Dplus                              iter direction   
                                                   = _dplus iter direction 
    member this.GetFdm1dMeshers                    = _getFdm1dMeshers
    member this.Location                           iter direction   
                                                   = _location iter direction 
    member this.Locations                          direction   
                                                   = _locations direction 
    member this.Layout                             = _layout
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type FdmMesherCompositeModel4
    ( m1                                           : ICell<Fdm1dMesher>
    , m2                                           : ICell<Fdm1dMesher>
    ) as this =

    inherit Model<FdmMesherComposite> ()
(*
    Parameters
*)
    let _m1                                        = m1
    let _m2                                        = m2
(*
    Functions
*)
    let _FdmMesherComposite                        = cell (fun () -> new FdmMesherComposite (m1.Value, m2.Value))
    let _dminus                                    (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.dminus(iter.Value, direction.Value))
    let _dplus                                     (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.dplus(iter.Value, direction.Value))
    let _getFdm1dMeshers                           = triv (fun () -> _FdmMesherComposite.Value.getFdm1dMeshers())
    let _location                                  (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.location(iter.Value, direction.Value))
    let _locations                                 (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.locations(direction.Value))
    let _layout                                    = triv (fun () -> _FdmMesherComposite.Value.layout())
    do this.Bind(_FdmMesherComposite)
(* 
    casting 
*)
    internal new () = new FdmMesherCompositeModel4(null,null)
    member internal this.Inject v = _FdmMesherComposite.Value <- v
    static member Cast (p : ICell<FdmMesherComposite>) = 
        if p :? FdmMesherCompositeModel4 then 
            p :?> FdmMesherCompositeModel4
        else
            let o = new FdmMesherCompositeModel4 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.m1                                 = _m1 
    member this.m2                                 = _m2 
    member this.Dminus                             iter direction   
                                                   = _dminus iter direction 
    member this.Dplus                              iter direction   
                                                   = _dplus iter direction 
    member this.GetFdm1dMeshers                    = _getFdm1dMeshers
    member this.Location                           iter direction   
                                                   = _location iter direction 
    member this.Locations                          direction   
                                                   = _locations direction 
    member this.Layout                             = _layout
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type FdmMesherCompositeModel5
    ( m1                                           : ICell<Fdm1dMesher>
    , m2                                           : ICell<Fdm1dMesher>
    , m3                                           : ICell<Fdm1dMesher>
    ) as this =

    inherit Model<FdmMesherComposite> ()
(*
    Parameters
*)
    let _m1                                        = m1
    let _m2                                        = m2
    let _m3                                        = m3
(*
    Functions
*)
    let _FdmMesherComposite                        = cell (fun () -> new FdmMesherComposite (m1.Value, m2.Value, m3.Value))
    let _dminus                                    (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.dminus(iter.Value, direction.Value))
    let _dplus                                     (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.dplus(iter.Value, direction.Value))
    let _getFdm1dMeshers                           = triv (fun () -> _FdmMesherComposite.Value.getFdm1dMeshers())
    let _location                                  (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.location(iter.Value, direction.Value))
    let _locations                                 (direction : ICell<int>)   
                                                   = triv (fun () -> _FdmMesherComposite.Value.locations(direction.Value))
    let _layout                                    = triv (fun () -> _FdmMesherComposite.Value.layout())
    do this.Bind(_FdmMesherComposite)
(* 
    casting 
*)
    internal new () = new FdmMesherCompositeModel5(null,null,null)
    member internal this.Inject v = _FdmMesherComposite.Value <- v
    static member Cast (p : ICell<FdmMesherComposite>) = 
        if p :? FdmMesherCompositeModel5 then 
            p :?> FdmMesherCompositeModel5
        else
            let o = new FdmMesherCompositeModel5 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.m1                                 = _m1 
    member this.m2                                 = _m2 
    member this.m3                                 = _m3 
    member this.Dminus                             iter direction   
                                                   = _dminus iter direction 
    member this.Dplus                              iter direction   
                                                   = _dplus iter direction 
    member this.GetFdm1dMeshers                    = _getFdm1dMeshers
    member this.Location                           iter direction   
                                                   = _location iter direction 
    member this.Locations                          direction   
                                                   = _locations direction 
    member this.Layout                             = _layout
