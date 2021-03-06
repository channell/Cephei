﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Cephei.Gen
{
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class Collect : CollectBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            
            #line 1 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
/*  
Name:			Collect.tt
Author:			Stephen Channell
Description:	Generate XL collection functions
*/
            
            #line default
            #line hidden
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing Syste" +
                    "m.Text;\r\nusing ExcelDna.Integration;\r\nusing Cephei;\r\nusing Cephei.Core;\r\nusing C" +
                    "ephei.Data;\r\n\r\nnamespace Cephei.XL\r\n{   \r\n    public class ");
            
            #line 22 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write("s\r\n    {\r\n        [ExcelFunction (Description = \"Create a reference to a ");
            
            #line 24 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write("\", Category = \"Cephei\", Name = \"_");
            
            #line 24 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write("\", IsMacroType = true)]\r\n        public static object _");
            
            #line 25 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write("\r\n            ([ExcelArgument (Description = \"identifer for the value\", AllowRefe" +
                    "rence = true)] string Mnemonic\r\n           , [ExcelArgument (Description = \"valu" +
                    "e\", AllowReference = true)] ");
            
            #line 27 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TypeCode));
            
            #line default
            #line hidden
            this.Write(@" v
           )
        {
            if (CepheiModel.Instance.IsInFunctionWizard ())
                return Mnemonic;
            try
            {
                Tuple<Type, Object[]> __pam = new Tuple<Type, object[]>
                    ( typeof (Cephei.Data.");
            
            #line 35 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@"Cell)
                    , new object[]
                        { Mnemonic
                        , v
                        }
                    );
                CepheiModel.Instance.WriteLog
                    (LogType.Information
                    , 2");
            
            #line 43 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MsgNo));
            
            #line default
            #line hidden
            this.Write("0000001\r\n                    , \"Cephei.XL\"\r\n                    , \"Create\"\r\n     " +
                    "               , \"");
            
            #line 46 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@"""
                    );
                return CepheiModel.Instance.Subscribe (__pam);
            }
            catch (Exception e)
            {
                CepheiModel.Instance.WriteLog
                    (LogType.Error
                    , 2");
            
            #line 54 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MsgNo));
            
            #line default
            #line hidden
            this.Write("0000002\r\n                    , \"Cephei.XL\"\r\n                    , \"Create\"\r\n     " +
                    "               , \"");
            
            #line 57 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@"Double:"" + e.Message
                    );
                throw e;
            }
        }

        /// <summary>
        /// Create Vector from Excel
        /// </summary>
        [ExcelFunction (Description = ""Create a reference to a list of references to ");
            
            #line 66 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write("\", Category = \"Cephei.XL\", Name = \"_");
            
            #line 66 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write("_Vector\", IsMacroType = true)]\r\n        public static object _");
            
            #line 67 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write("_Vector\r\n            ([ExcelArgument (\"Mnemonic\")] string Mnemonic\r\n           , " +
                    "[ExcelArgument (\"vector of Mnemonic for the ");
            
            #line 69 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@"s"")] object[] v
           )
        {
            if (CepheiModel.Instance.IsInFunctionWizard ())
                return Mnemonic;
            try
            {
                Tuple<Type, Object[]> __pam = new Tuple<Type, object[]>
                    ( typeof (Cephei.Data.");
            
            #line 77 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@"CellVector)
                    , new object[]
                        { Mnemonic
                        , v
                        }
                    );
                CepheiModel.Instance.WriteLog
                    ( LogType.Information
                    , 2");
            
            #line 85 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MsgNo));
            
            #line default
            #line hidden
            this.Write("0000003\r\n                    , \"Cephei.XL\"\r\n                    , \"CreateVector\"\r" +
                    "\n                    , \"");
            
            #line 88 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@"""
                    );
                return CepheiModel.Instance.Subscribe (__pam);
            }
            catch (Exception e)
            {
                CepheiModel.Instance.WriteLog
                    (LogType.Error
                    , 2");
            
            #line 96 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MsgNo));
            
            #line default
            #line hidden
            this.Write("0000003\r\n                    , \"Cephei.XL\"\r\n                    , \"CreateVector\"\r" +
                    "\n                    , \"");
            
            #line 99 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@":"" + e.Message
                    );
                throw e;
            }
        }

        /// <summary>
        /// Create Matrix from Excel
        /// </summary>
        [ExcelFunction (Description = ""Create a reference to a table of references to ");
            
            #line 108 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write("\", Category = \"Cephei.XL\", Name = \"_");
            
            #line 108 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write("_Matrix\", IsMacroType = true)]\r\n        public static object _");
            
            #line 109 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write("_Matrix\r\n            ([ExcelArgument (\"Mnemonic\")] string Mnemonic\r\n           , " +
                    "[ExcelArgument (\"matrix of Mnemonic for the ");
            
            #line 111 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@"s"")] object[] v
           )
        {
            if (CepheiModel.Instance.IsInFunctionWizard ())
                return Mnemonic;
            try
            {
                Tuple<Type, Object[]> __pam = new Tuple<Type, object[]>
                    ( typeof (Cephei.Data.");
            
            #line 119 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@"CellMatrix)
                    , new object[]
                        { Mnemonic
                        , v
                        }
                    );
                CepheiModel.Instance.WriteLog
                    ( LogType.Information
                    , 2");
            
            #line 127 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MsgNo));
            
            #line default
            #line hidden
            this.Write("0000004\r\n                    , \"Cephei.XL\"\r\n                    , \"CreateMatrix\"\r" +
                    "\n                    , \"");
            
            #line 130 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@"""
                    );
                return CepheiModel.Instance.Subscribe (__pam);
            }
            catch (Exception e)
            {
                CepheiModel.Instance.WriteLog
                    (LogType.Error
                    , 2");
            
            #line 138 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MsgNo));
            
            #line default
            #line hidden
            this.Write("0000004\r\n                    , \"Cephei.XL\"\r\n                    , \"CreateMatrix\"\r" +
                    "\n                    , \"");
            
            #line 141 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@":"" + e.Message
                    );
                throw e;
            }
        }
        /// <summary>
        /// Create Cube from Excel
        /// </summary>
        [ExcelFunction (Description = ""Create a reference to a cube of references to ");
            
            #line 149 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write("\", Category = \"Cephei.XL\", Name = \"_");
            
            #line 149 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write("_Cube\", IsMacroType = true)]\r\n        public static object _");
            
            #line 150 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write("_Cube\r\n            ([ExcelArgument (\"Mnemonic\")] string Mnemonic\r\n           , [E" +
                    "xcelArgument (\"Cube of Mnemonic for the ");
            
            #line 152 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@"s"")] object[] v
           )
        {
            if (CepheiModel.Instance.IsInFunctionWizard ())
                return Mnemonic;
            try
            {
                Tuple<Type, Object[]> __pam = new Tuple<Type, object[]>
                    (typeof (Cephei.Data.");
            
            #line 160 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@"CellCube)
                    , new object[]
                        { Mnemonic
                        , v
                        }
                    );
                CepheiModel.Instance.WriteLog
                    ( LogType.Information
                    , 2");
            
            #line 168 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MsgNo));
            
            #line default
            #line hidden
            this.Write("0000005\r\n                    , \"Cephei.XL\"\r\n                    , \"CreateCube\"\r\n " +
                    "                   , \"");
            
            #line 171 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@"""
                    );
                return CepheiModel.Instance.Subscribe (__pam);
            }
            catch (Exception e)
            {
                CepheiModel.Instance.WriteLog
                    (LogType.Error
                    , 2");
            
            #line 179 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MsgNo));
            
            #line default
            #line hidden
            this.Write("0000005\r\n                    , \"Cephei.XL\"\r\n                    , \"CreateCube\"\r\n " +
                    "                   , \"");
            
            #line 182 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@":"" + e.Message
                    );
                throw e;
            }
        }
        /// <summary>
        /// Create Vector from VBA
        /// </summary>
        public static ICell VectorCreate
           ( string Mnemonic
           , object[] v
           )
        {
            try
            {
                object[] __pam =
                    new object[]
                        { Mnemonic
                        , v
                        };
                CepheiModel.Instance.WriteLog
                    ( LogType.Information
                    , 2");
            
            #line 204 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MsgNo));
            
            #line default
            #line hidden
            this.Write("0000006\r\n                    , \"Cephei.XL\"\r\n                    , \"CreateVector\"\r" +
                    "\n                    , \"");
            
            #line 207 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write("\"\r\n                    );\r\n                var _r = new Cephei.Data.");
            
            #line 209 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@"CellVector (CepheiModel.Instance, __pam);
                CepheiModel.Instance[Mnemonic] = _r;
                return _r;
            }
            catch (Exception e)
            {
                CepheiModel.Instance.WriteLog
                    (LogType.Error
                    , 2");
            
            #line 217 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MsgNo));
            
            #line default
            #line hidden
            this.Write("0000007\r\n                    , \"Cephei.XL\"\r\n                    , \"CreateVector\"\r" +
                    "\n                    , \"");
            
            #line 220 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@":"" + e.Message
                    );
                throw e;
            }
        }

        /// <summary>
        /// Create Matrix from VBA
        /// </summary>
        public static ICell MatrixCreate
           ( string Mnemonic
           , object[] v
           )
        {
            try
            {
                object[] __pam =
                    new object[]
                        { Mnemonic
                        , v
                        };
                CepheiModel.Instance.WriteLog
                    ( LogType.Information
                    , 2");
            
            #line 243 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MsgNo));
            
            #line default
            #line hidden
            this.Write("0000008\r\n                    , \"Cephei.XL\"\r\n                    , \"CreateMatrix\"\r" +
                    "\n                    , \"");
            
            #line 246 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write("\"\r\n                    );\r\n                var _r = new Cephei.Data.");
            
            #line 248 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@"CellMatrix (CepheiModel.Instance, __pam);
                CepheiModel.Instance[Mnemonic] = _r;
                return _r;
            }
            catch (Exception e)
            {
                CepheiModel.Instance.WriteLog
                    (LogType.Error
                    , 2");
            
            #line 256 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MsgNo));
            
            #line default
            #line hidden
            this.Write("0000008\r\n                    , \"Cephei.XL\"\r\n                    , \"CreateMatrix\"\r" +
                    "\n                    , \"");
            
            #line 259 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@":"" + e.Message
                    );
                throw e;
            }
        }
        /// <summary>
        /// Create Cube from VBA
        /// </summary>
        public static ICell CubeCreate
           ( string Mnemonic
           , object[] v
           )
        {
            try
            {
                object[] __pam =
                    new object[]
                        { Mnemonic
                        , v
                        };
                CepheiModel.Instance.WriteLog
                    ( LogType.Information
                    , 2");
            
            #line 281 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MsgNo));
            
            #line default
            #line hidden
            this.Write("0000009\r\n                    , \"Cephei.XL\"\r\n                    , \"CreateCube\"\r\n " +
                    "                   , \"");
            
            #line 284 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write("\"\r\n                    );\r\n                var _r = new Cephei.Data.");
            
            #line 286 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(@"CellCube (CepheiModel.Instance, __pam);
                CepheiModel.Instance[Mnemonic] = _r;
                return _r;
            }
            catch (Exception e)
            {
                CepheiModel.Instance.WriteLog
                    (LogType.Error
                    , 2");
            
            #line 294 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(MsgNo));
            
            #line default
            #line hidden
            this.Write("0000009\r\n                    , \"Cephei.XL\"\r\n                    , \"CreateCube\"\r\n " +
                    "                   , \"");
            
            #line 297 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Mnemonic));
            
            #line default
            #line hidden
            this.Write(":\" + e.Message\r\n                    );\r\n                throw e;\r\n            }\r\n" +
                    "        }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 304 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"

	public Collect
		( string Mnemonic 
		, string typeCode
		, int msgNo
		)
	{
		_MnemonicField = Mnemonic;
        _TypeCodeField = typeCode;
        _MsgNoField = msgNo;
	}

        
        #line default
        #line hidden
        
        #line 1 "C:\Users\steve\source\repos\Cephei2\Cephei.Gen\XL\Collect.tt"

private string _MnemonicField;

/// <summary>
/// Access the Mnemonic parameter of the template.
/// </summary>
private string Mnemonic
{
    get
    {
        return this._MnemonicField;
    }
}

private string _TypeCodeField;

/// <summary>
/// Access the TypeCode parameter of the template.
/// </summary>
private string TypeCode
{
    get
    {
        return this._TypeCodeField;
    }
}

private int _MsgNoField;

/// <summary>
/// Access the MsgNo parameter of the template.
/// </summary>
private int MsgNo
{
    get
    {
        return this._MsgNoField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool MnemonicValueAcquired = false;
if (this.Session.ContainsKey("Mnemonic"))
{
    this._MnemonicField = ((string)(this.Session["Mnemonic"]));
    MnemonicValueAcquired = true;
}
if ((MnemonicValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Mnemonic");
    if ((data != null))
    {
        this._MnemonicField = ((string)(data));
    }
}
bool TypeCodeValueAcquired = false;
if (this.Session.ContainsKey("TypeCode"))
{
    this._TypeCodeField = ((string)(this.Session["TypeCode"]));
    TypeCodeValueAcquired = true;
}
if ((TypeCodeValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("TypeCode");
    if ((data != null))
    {
        this._TypeCodeField = ((string)(data));
    }
}
bool MsgNoValueAcquired = false;
if (this.Session.ContainsKey("MsgNo"))
{
    this._MsgNoField = ((int)(this.Session["MsgNo"]));
    MsgNoValueAcquired = true;
}
if ((MsgNoValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("MsgNo");
    if ((data != null))
    {
        this._MsgNoField = ((int)(data));
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public class CollectBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
