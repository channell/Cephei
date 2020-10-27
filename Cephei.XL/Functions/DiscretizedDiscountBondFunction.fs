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
  Useful discretized discount bond asset
  </summary> *)
[<AutoSerializable(true)>]
module DiscretizedDiscountBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedDiscountBond_mandatoryTimes", Description="Create a DiscretizedDiscountBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDiscountBond_mandatoryTimes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDiscountBond",Description = "DiscretizedDiscountBond")>] 
         discretizeddiscountbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDiscountBond = Helper.toCell<DiscretizedDiscountBond> discretizeddiscountbond "DiscretizedDiscountBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDiscountBondModel.Cast _DiscretizedDiscountBond.cell).MandatoryTimes
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source () = Helper.sourceFold (_DiscretizedDiscountBond.source + ".MandatoryTimes") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDiscountBond.cell
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
    [<ExcelFunction(Name="_DiscretizedDiscountBond_reset", Description="Create a DiscretizedDiscountBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDiscountBond_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDiscountBond",Description = "DiscretizedDiscountBond")>] 
         discretizeddiscountbond : obj)
        ([<ExcelArgument(Name="size",Description = "int")>] 
         size : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDiscountBond = Helper.toCell<DiscretizedDiscountBond> discretizeddiscountbond "DiscretizedDiscountBond"  
                let _size = Helper.toCell<int> size "size" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDiscountBondModel.Cast _DiscretizedDiscountBond.cell).Reset
                                                            _size.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDiscountBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDiscountBond.source + ".Reset") 

                                               [| _size.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDiscountBond.cell
                                ;  _size.cell
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
        ! This method performs both pre- and post-adjustment
    *)
    [<ExcelFunction(Name="_DiscretizedDiscountBond_adjustValues", Description="Create a DiscretizedDiscountBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDiscountBond_adjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDiscountBond",Description = "DiscretizedDiscountBond")>] 
         discretizeddiscountbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDiscountBond = Helper.toCell<DiscretizedDiscountBond> discretizeddiscountbond "DiscretizedDiscountBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDiscountBondModel.Cast _DiscretizedDiscountBond.cell).AdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedDiscountBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDiscountBond.source + ".AdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDiscountBond.cell
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
        High-level interface  Users of discretized assets should use these methods in order to initialize, evolve and take the present value of the assets.  They call the corresponding methods in the Lattice interface, to which we refer for documentation.
    *)
    [<ExcelFunction(Name="_DiscretizedDiscountBond_initialize", Description="Create a DiscretizedDiscountBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDiscountBond_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDiscountBond",Description = "DiscretizedDiscountBond")>] 
         discretizeddiscountbond : obj)
        ([<ExcelArgument(Name="Method",Description = "Lattice")>] 
         Method : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDiscountBond = Helper.toCell<DiscretizedDiscountBond> discretizeddiscountbond "DiscretizedDiscountBond"  
                let _Method = Helper.toCell<Lattice> Method "Method" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDiscountBondModel.Cast _DiscretizedDiscountBond.cell).Initialize
                                                            _Method.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDiscountBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDiscountBond.source + ".Initialize") 

                                               [| _Method.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDiscountBond.cell
                                ;  _Method.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_DiscretizedDiscountBond_method", Description="Create a DiscretizedDiscountBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDiscountBond_method
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDiscountBond",Description = "DiscretizedDiscountBond")>] 
         discretizeddiscountbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDiscountBond = Helper.toCell<DiscretizedDiscountBond> discretizeddiscountbond "DiscretizedDiscountBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDiscountBondModel.Cast _DiscretizedDiscountBond.cell).Method
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Lattice>) l

                let source () = Helper.sourceFold (_DiscretizedDiscountBond.source + ".METHOD") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDiscountBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedDiscountBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_DiscretizedDiscountBond_partialRollback", Description="Create a DiscretizedDiscountBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDiscountBond_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDiscountBond",Description = "DiscretizedDiscountBond")>] 
         discretizeddiscountbond : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDiscountBond = Helper.toCell<DiscretizedDiscountBond> discretizeddiscountbond "DiscretizedDiscountBond"  
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDiscountBondModel.Cast _DiscretizedDiscountBond.cell).PartialRollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDiscountBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDiscountBond.source + ".PartialRollback") 

                                               [| _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDiscountBond.cell
                                ;  _To.cell
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
        ! This method will be invoked after rollback and after any other asset had their chance to look at the values. For instance, payments happening at the present time (and therefore not included in an option to be exercised at this time) will be added here.  This method is not virtual; derived classes must override the protected postAdjustValuesImpl() method instead.
    *)
    [<ExcelFunction(Name="_DiscretizedDiscountBond_postAdjustValues", Description="Create a DiscretizedDiscountBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDiscountBond_postAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDiscountBond",Description = "DiscretizedDiscountBond")>] 
         discretizeddiscountbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDiscountBond = Helper.toCell<DiscretizedDiscountBond> discretizeddiscountbond "DiscretizedDiscountBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDiscountBondModel.Cast _DiscretizedDiscountBond.cell).PostAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedDiscountBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDiscountBond.source + ".PostAdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDiscountBond.cell
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
        ! This method will be invoked after rollback and before any other asset (i.e., an option on this one) has any chance to look at the values. For instance, payments happening at times already spanned by the rollback will be added here.  This method is not virtual; derived classes must override the protected preAdjustValuesImpl() method instead.
    *)
    [<ExcelFunction(Name="_DiscretizedDiscountBond_preAdjustValues", Description="Create a DiscretizedDiscountBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDiscountBond_preAdjustValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDiscountBond",Description = "DiscretizedDiscountBond")>] 
         discretizeddiscountbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDiscountBond = Helper.toCell<DiscretizedDiscountBond> discretizeddiscountbond "DiscretizedDiscountBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDiscountBondModel.Cast _DiscretizedDiscountBond.cell).PreAdjustValues
                                                       ) :> ICell
                let format (o : DiscretizedDiscountBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDiscountBond.source + ".PreAdjustValues") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDiscountBond.cell
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
    [<ExcelFunction(Name="_DiscretizedDiscountBond_presentValue", Description="Create a DiscretizedDiscountBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDiscountBond_presentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDiscountBond",Description = "DiscretizedDiscountBond")>] 
         discretizeddiscountbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDiscountBond = Helper.toCell<DiscretizedDiscountBond> discretizeddiscountbond "DiscretizedDiscountBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDiscountBondModel.Cast _DiscretizedDiscountBond.cell).PresentValue
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscretizedDiscountBond.source + ".PresentValue") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDiscountBond.cell
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
    [<ExcelFunction(Name="_DiscretizedDiscountBond_rollback", Description="Create a DiscretizedDiscountBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDiscountBond_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDiscountBond",Description = "DiscretizedDiscountBond")>] 
         discretizeddiscountbond : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDiscountBond = Helper.toCell<DiscretizedDiscountBond> discretizeddiscountbond "DiscretizedDiscountBond"  
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDiscountBondModel.Cast _DiscretizedDiscountBond.cell).Rollback
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDiscountBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDiscountBond.source + ".Rollback") 

                                               [| _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDiscountBond.cell
                                ;  _To.cell
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
        safe version of QL double* time()
    *)
    [<ExcelFunction(Name="_DiscretizedDiscountBond_setTime", Description="Create a DiscretizedDiscountBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDiscountBond_setTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDiscountBond",Description = "DiscretizedDiscountBond")>] 
         discretizeddiscountbond : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDiscountBond = Helper.toCell<DiscretizedDiscountBond> discretizeddiscountbond "DiscretizedDiscountBond"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDiscountBondModel.Cast _DiscretizedDiscountBond.cell).SetTime
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDiscountBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDiscountBond.source + ".SetTime") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDiscountBond.cell
                                ;  _t.cell
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
        safe version of QL Vector* values()
    *)
    [<ExcelFunction(Name="_DiscretizedDiscountBond_setValues", Description="Create a DiscretizedDiscountBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDiscountBond_setValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDiscountBond",Description = "DiscretizedDiscountBond")>] 
         discretizeddiscountbond : obj)
        ([<ExcelArgument(Name="v",Description = "Vector")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDiscountBond = Helper.toCell<DiscretizedDiscountBond> discretizeddiscountbond "DiscretizedDiscountBond"  
                let _v = Helper.toCell<Vector> v "v" 
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDiscountBondModel.Cast _DiscretizedDiscountBond.cell).SetValues
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : DiscretizedDiscountBond) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_DiscretizedDiscountBond.source + ".SetValues") 

                                               [| _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _DiscretizedDiscountBond.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_DiscretizedDiscountBond_time", Description="Create a DiscretizedDiscountBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDiscountBond_time
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDiscountBond",Description = "DiscretizedDiscountBond")>] 
         discretizeddiscountbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDiscountBond = Helper.toCell<DiscretizedDiscountBond> discretizeddiscountbond "DiscretizedDiscountBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDiscountBondModel.Cast _DiscretizedDiscountBond.cell).Time
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_DiscretizedDiscountBond.source + ".Time") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDiscountBond.cell
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
    [<ExcelFunction(Name="_DiscretizedDiscountBond_values", Description="Create a DiscretizedDiscountBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDiscountBond_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="DiscretizedDiscountBond",Description = "DiscretizedDiscountBond")>] 
         discretizeddiscountbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _DiscretizedDiscountBond = Helper.toCell<DiscretizedDiscountBond> discretizeddiscountbond "DiscretizedDiscountBond"  
                let builder (current : ICell) = withMnemonic mnemonic ((DiscretizedDiscountBondModel.Cast _DiscretizedDiscountBond.cell).Values
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_DiscretizedDiscountBond.source + ".Values") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _DiscretizedDiscountBond.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<DiscretizedDiscountBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_DiscretizedDiscountBond_Range", Description="Create a range of DiscretizedDiscountBond",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let DiscretizedDiscountBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<DiscretizedDiscountBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<DiscretizedDiscountBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<DiscretizedDiscountBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<DiscretizedDiscountBond>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
