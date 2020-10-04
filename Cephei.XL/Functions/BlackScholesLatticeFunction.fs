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
(*!!
(* <summary>
  lattices
  </summary> *)
[<AutoSerializable(true)>]
module BlackScholesLatticeFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesLattice", Description="Create a BlackScholesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesLattice_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tree",Description = "Reference to tree")>] 
         tree : obj)
        ([<ExcelArgument(Name="riskFreeRate",Description = "Reference to riskFreeRate")>] 
         riskFreeRate : obj)
        ([<ExcelArgument(Name="End",Description = "Reference to End")>] 
         End : obj)
        ([<ExcelArgument(Name="steps",Description = "Reference to steps")>] 
         steps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tree = Helper.toCell<ITree> tree "tree" 
                let _riskFreeRate = Helper.toCell<double> riskFreeRate "riskFreeRate" 
                let _End = Helper.toCell<double> End "End" 
                let _steps = Helper.toCell<int> steps "steps" 
                let builder () = withMnemonic mnemonic (Fun.BlackScholesLattice 
                                                            _tree.cell 
                                                            _riskFreeRate.cell 
                                                            _End.cell 
                                                            _steps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackScholesLattice>) l

                let source = Helper.sourceFold "Fun.BlackScholesLattice" 
                                               [| _tree.source
                                               ;  _riskFreeRate.source
                                               ;  _End.source
                                               ;  _steps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tree.cell
                                ;  _riskFreeRate.cell
                                ;  _End.cell
                                ;  _steps.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesLattice> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesLattice_descendant", Description="Create a BlackScholesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesLattice_descendant
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesLattice",Description = "Reference to BlackScholesLattice")>] 
         blackscholeslattice : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="branch",Description = "Reference to branch")>] 
         branch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesLattice = Helper.toCell<BlackScholesLattice> blackscholeslattice "BlackScholesLattice"  
                let _i = Helper.toCell<int> i "i" 
                let _index = Helper.toCell<int> index "index" 
                let _branch = Helper.toCell<int> branch "branch" 
                let builder () = withMnemonic mnemonic ((BlackScholesLatticeModel.Cast _BlackScholesLattice.cell).Descendant
                                                            _i.cell 
                                                            _index.cell 
                                                            _branch.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesLattice.source + ".Descendant") 
                                               [| _BlackScholesLattice.source
                                               ;  _i.source
                                               ;  _index.source
                                               ;  _branch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesLattice.cell
                                ;  _i.cell
                                ;  _index.cell
                                ;  _branch.cell
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
    [<ExcelFunction(Name="_BlackScholesLattice_discount", Description="Create a BlackScholesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesLattice_discount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesLattice",Description = "Reference to BlackScholesLattice")>] 
         blackscholeslattice : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesLattice = Helper.toCell<BlackScholesLattice> blackscholeslattice "BlackScholesLattice"  
                let _i = Helper.toCell<int> i "i" 
                let _j = Helper.toCell<int> j "j" 
                let builder () = withMnemonic mnemonic ((BlackScholesLatticeModel.Cast _BlackScholesLattice.cell).Discount
                                                            _i.cell 
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesLattice.source + ".Discount") 
                                               [| _BlackScholesLattice.source
                                               ;  _i.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesLattice.cell
                                ;  _i.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_BlackScholesLattice_dt", Description="Create a BlackScholesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesLattice_dt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesLattice",Description = "Reference to BlackScholesLattice")>] 
         blackscholeslattice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesLattice = Helper.toCell<BlackScholesLattice> blackscholeslattice "BlackScholesLattice"  
                let builder () = withMnemonic mnemonic ((BlackScholesLatticeModel.Cast _BlackScholesLattice.cell).Dt
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesLattice.source + ".Dt") 
                                               [| _BlackScholesLattice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesLattice.cell
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
    [<ExcelFunction(Name="_BlackScholesLattice_probability", Description="Create a BlackScholesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesLattice_probability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesLattice",Description = "Reference to BlackScholesLattice")>] 
         blackscholeslattice : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="branch",Description = "Reference to branch")>] 
         branch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesLattice = Helper.toCell<BlackScholesLattice> blackscholeslattice "BlackScholesLattice"  
                let _i = Helper.toCell<int> i "i" 
                let _index = Helper.toCell<int> index "index" 
                let _branch = Helper.toCell<int> branch "branch" 
                let builder () = withMnemonic mnemonic ((BlackScholesLatticeModel.Cast _BlackScholesLattice.cell).Probability
                                                            _i.cell 
                                                            _index.cell 
                                                            _branch.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesLattice.source + ".Probability") 
                                               [| _BlackScholesLattice.source
                                               ;  _i.source
                                               ;  _index.source
                                               ;  _branch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesLattice.cell
                                ;  _i.cell
                                ;  _index.cell
                                ;  _branch.cell
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
    [<ExcelFunction(Name="_BlackScholesLattice_riskFreeRate", Description="Create a BlackScholesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesLattice_riskFreeRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesLattice",Description = "Reference to BlackScholesLattice")>] 
         blackscholeslattice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesLattice = Helper.toCell<BlackScholesLattice> blackscholeslattice "BlackScholesLattice"  
                let builder () = withMnemonic mnemonic ((BlackScholesLatticeModel.Cast _BlackScholesLattice.cell).RiskFreeRate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesLattice.source + ".RiskFreeRate") 
                                               [| _BlackScholesLattice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesLattice.cell
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
    [<ExcelFunction(Name="_BlackScholesLattice_size", Description="Create a BlackScholesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesLattice_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesLattice",Description = "Reference to BlackScholesLattice")>] 
         blackscholeslattice : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesLattice = Helper.toCell<BlackScholesLattice> blackscholeslattice "BlackScholesLattice"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((BlackScholesLatticeModel.Cast _BlackScholesLattice.cell).Size
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesLattice.source + ".Size") 
                                               [| _BlackScholesLattice.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesLattice.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_BlackScholesLattice_stepback", Description="Create a BlackScholesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesLattice_stepback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesLattice",Description = "Reference to BlackScholesLattice")>] 
         blackscholeslattice : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="values",Description = "Reference to values")>] 
         values : obj)
        ([<ExcelArgument(Name="newValues",Description = "Reference to newValues")>] 
         newValues : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesLattice = Helper.toCell<BlackScholesLattice> blackscholeslattice "BlackScholesLattice"  
                let _i = Helper.toCell<int> i "i" 
                let _values = Helper.toCell<Vector> values "values" 
                let _newValues = Helper.toCell<Vector> newValues "newValues" 
                let builder () = withMnemonic mnemonic ((BlackScholesLatticeModel.Cast _BlackScholesLattice.cell).Stepback
                                                            _i.cell 
                                                            _values.cell 
                                                            _newValues.cell 
                                                       ) :> ICell
                let format (o : BlackScholesLattice) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackScholesLattice.source + ".Stepback") 
                                               [| _BlackScholesLattice.source
                                               ;  _i.source
                                               ;  _values.source
                                               ;  _newValues.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesLattice.cell
                                ;  _i.cell
                                ;  _values.cell
                                ;  _newValues.cell
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
    [<ExcelFunction(Name="_BlackScholesLattice_underlying", Description="Create a BlackScholesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesLattice_underlying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesLattice",Description = "Reference to BlackScholesLattice")>] 
         blackscholeslattice : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesLattice = Helper.toCell<BlackScholesLattice> blackscholeslattice "BlackScholesLattice"  
                let _i = Helper.toCell<int> i "i" 
                let _index = Helper.toCell<int> index "index" 
                let builder () = withMnemonic mnemonic ((BlackScholesLatticeModel.Cast _BlackScholesLattice.cell).Underlying
                                                            _i.cell 
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesLattice.source + ".Underlying") 
                                               [| _BlackScholesLattice.source
                                               ;  _i.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesLattice.cell
                                ;  _i.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_BlackScholesLattice_grid", Description="Create a BlackScholesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesLattice_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesLattice",Description = "Reference to BlackScholesLattice")>] 
         blackscholeslattice : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesLattice = Helper.toCell<BlackScholesLattice> blackscholeslattice "BlackScholesLattice"  
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((BlackScholesLatticeModel.Cast _BlackScholesLattice.cell).Grid
                                                            _t.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_BlackScholesLattice.source + ".Grid") 
                                               [| _BlackScholesLattice.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesLattice.cell
                                ;  _t.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesLattice> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Lattice interface
    *)
    [<ExcelFunction(Name="_BlackScholesLattice_initialize", Description="Create a BlackScholesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesLattice_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesLattice",Description = "Reference to BlackScholesLattice")>] 
         blackscholeslattice : obj)
        ([<ExcelArgument(Name="asset",Description = "Reference to asset")>] 
         asset : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesLattice = Helper.toCell<BlackScholesLattice> blackscholeslattice "BlackScholesLattice"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((BlackScholesLatticeModel.Cast _BlackScholesLattice.cell).Initialize
                                                            _asset.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : BlackScholesLattice) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackScholesLattice.source + ".Initialize") 
                                               [| _BlackScholesLattice.source
                                               ;  _asset.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesLattice.cell
                                ;  _asset.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_BlackScholesLattice_partialRollback", Description="Create a BlackScholesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesLattice_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesLattice",Description = "Reference to BlackScholesLattice")>] 
         blackscholeslattice : obj)
        ([<ExcelArgument(Name="asset",Description = "Reference to asset")>] 
         asset : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesLattice = Helper.toCell<BlackScholesLattice> blackscholeslattice "BlackScholesLattice"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let _To = Helper.toCell<double> To "To" 
                let builder () = withMnemonic mnemonic ((BlackScholesLatticeModel.Cast _BlackScholesLattice.cell).PartialRollback
                                                            _asset.cell 
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : BlackScholesLattice) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackScholesLattice.source + ".PartialRollback") 
                                               [| _BlackScholesLattice.source
                                               ;  _asset.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesLattice.cell
                                ;  _asset.cell
                                ;  _To.cell
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
        ! Computes the present value of an asset using Arrow-Debrew prices
    *)
    [<ExcelFunction(Name="_BlackScholesLattice_presentValue", Description="Create a BlackScholesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesLattice_presentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesLattice",Description = "Reference to BlackScholesLattice")>] 
         blackscholeslattice : obj)
        ([<ExcelArgument(Name="asset",Description = "Reference to asset")>] 
         asset : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesLattice = Helper.toCell<BlackScholesLattice> blackscholeslattice "BlackScholesLattice"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let builder () = withMnemonic mnemonic ((BlackScholesLatticeModel.Cast _BlackScholesLattice.cell).PresentValue
                                                            _asset.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackScholesLattice.source + ".PresentValue") 
                                               [| _BlackScholesLattice.source
                                               ;  _asset.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesLattice.cell
                                ;  _asset.cell
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
    [<ExcelFunction(Name="_BlackScholesLattice_rollback", Description="Create a BlackScholesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesLattice_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesLattice",Description = "Reference to BlackScholesLattice")>] 
         blackscholeslattice : obj)
        ([<ExcelArgument(Name="asset",Description = "Reference to asset")>] 
         asset : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesLattice = Helper.toCell<BlackScholesLattice> blackscholeslattice "BlackScholesLattice"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let _To = Helper.toCell<double> To "To" 
                let builder () = withMnemonic mnemonic ((BlackScholesLatticeModel.Cast _BlackScholesLattice.cell).Rollback
                                                            _asset.cell 
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : BlackScholesLattice) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BlackScholesLattice.source + ".Rollback") 
                                               [| _BlackScholesLattice.source
                                               ;  _asset.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesLattice.cell
                                ;  _asset.cell
                                ;  _To.cell
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
    [<ExcelFunction(Name="_BlackScholesLattice_statePrices", Description="Create a BlackScholesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesLattice_statePrices
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesLattice",Description = "Reference to BlackScholesLattice")>] 
         blackscholeslattice : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesLattice = Helper.toCell<BlackScholesLattice> blackscholeslattice "BlackScholesLattice"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((BlackScholesLatticeModel.Cast _BlackScholesLattice.cell).StatePrices
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_BlackScholesLattice.source + ".StatePrices") 
                                               [| _BlackScholesLattice.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesLattice.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesLattice> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_BlackScholesLattice_timeGrid", Description="Create a BlackScholesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesLattice_timeGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackScholesLattice",Description = "Reference to BlackScholesLattice")>] 
         blackscholeslattice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackScholesLattice = Helper.toCell<BlackScholesLattice> blackscholeslattice "BlackScholesLattice"  
                let builder () = withMnemonic mnemonic ((BlackScholesLatticeModel.Cast _BlackScholesLattice.cell).TimeGrid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TimeGrid>) l

                let source = Helper.sourceFold (_BlackScholesLattice.source + ".TimeGrid") 
                                               [| _BlackScholesLattice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackScholesLattice.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackScholesLattice> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BlackScholesLattice_Range", Description="Create a range of BlackScholesLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let BlackScholesLattice_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BlackScholesLattice")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackScholesLattice> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BlackScholesLattice>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BlackScholesLattice>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BlackScholesLattice>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
