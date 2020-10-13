
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open Cephei.QL.Util
open System.Collections
open System


module Diag =

    [<ExcelFunction(Name="_dependancies", Description="get the cell dependancies",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true, IsMacroType = true)>]
    let Dependancies () : obj[,]=

        Model.dependancyMatrix ()

