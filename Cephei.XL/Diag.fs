
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open Cephei.QL.Util
open System.Collections
open System


module Diag =

    [<ExcelFunction(Name="_dependencies", Description="get the cell dependencies",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true, IsMacroType = true)>]
    let dependencies () : obj[,]=

        Model.dependancyMatrix ()


