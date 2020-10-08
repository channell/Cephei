open System

let  n = "--" 
let  p = "--" 
let  t = "--" 

String.Format ("
  [<ExcelFunction(Name=\"__{0}_{1}\", Description=\"Create a {2}\",Category=\"Cephei Models\", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
([<ExcelArgument(Name=\"Mnemonic\",Description = \"Identifer for the value\")>] 
   mnemonic : string)
  ([<ExcelArgument(Name=\"{0}\",Description = \"Reference to {0}\")>] 
   {1} : obj)
  = 
  if not (Model.IsInFunctionWizard()) then

      try
  try

    let _{0} = Helper.toCell<{0}> {0} \"{0}\"  
let builder () = withMnemonic mnemonic (_{0}.cell :> {0}).{1}) :> ICell
let format (o : {2}) (l:string) = o.Helper.Range.fromModel (i :?> {1}) l
let source = (_{0}.source + \".{1}\")
let hash = Helper.hashFold [| _{0}.cell |]
Model.specify 
{ mnemonic = mnemonic
; creator = builder
; subscriber = Helper.subscriber format
; source = source 
; hash = hash
              ", n, p, t)
(*
String.Format ("
    [<ExcelFunction(Name=\"__{0}_{1}\", Description=\"Create a {2}\",Category=\"Cephei Models\", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Period_ToShortString
        ([<ExcelArgument(Name=\"Mnemonic\",Description = \"Identifer for the value\")>] 
         mnemonic : string)
        ([<ExcelArgument(Name=\"{0}\",Description = \"Reference to {0}\")>] 
         {1} : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

            let _{0} = Helper.toCell<{0}> {0} \"{0}\"  
            let builder () = withMnemonic mnemonic (_{0}.cell :> {0}).{1}) :> ICell
            let format (o : {2}) (l:string) = o.Helper.Range.fromModel (i :?> {1}) l
            let source = (_{0}.source + \".{1}\")
            let hash = Helper.hashFold [| _{0}.cell |]
            Model.specify 
            {{ mnemonic = mnemonic
            ; creator = builder
            ; subscriber = Helper.subscriber format
            ; source = source 
            ; hash = hash
            }} :?> string
            with
            | _ as e ->  \"#\" + e.Message
        else
            \"<WIZ>\"
                        ", n, p, t)
*)