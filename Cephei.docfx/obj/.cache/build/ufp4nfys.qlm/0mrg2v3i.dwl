﻿<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Class YearOnYearInflationSwapModel
   </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Class YearOnYearInflationSwapModel
   ">
    <meta name="generator" content="docfx 2.56.2.0">
    
    <link rel="shortcut icon" href="../favicon.ico">
    <link rel="stylesheet" href="../styles/docfx.vendor.css">
    <link rel="stylesheet" href="../styles/docfx.css">
    <link rel="stylesheet" href="../styles/main.css">
    <meta property="docfx:navrel" content="../toc.html">
    <meta property="docfx:tocrel" content="toc.html">
    
    
    
  </head>
  <body data-spy="scroll" data-target="#affix" data-offset="120">
    <div id="wrapper">
      <header>
        
        <nav id="autocollapse" class="navbar navbar-inverse ng-scope" role="navigation">
          <div class="container">
            <div class="navbar-header">
              <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              
              <a class="navbar-brand" href="../index.html">
                <img id="logo" class="svg" src="../logo.svg" alt="">
              </a>
            </div>
            <div class="collapse navbar-collapse" id="navbar">
              <form class="navbar-form navbar-right" role="search" id="search">
                <div class="form-group">
                  <input type="text" class="form-control" id="search-query" placeholder="Search" autocomplete="off">
                </div>
              </form>
            </div>
          </div>
        </nav>
        
        <div class="subnav navbar navbar-default">
          <div class="container hide-when-search" id="breadcrumb">
            <ul class="breadcrumb">
              <li></li>
            </ul>
          </div>
        </div>
      </header>
      <div role="main" class="container body-content hide-when-search">
        
        <div class="sidenav hide-when-search">
          <a class="btn toc-toggle collapse" data-toggle="collapse" href="#sidetoggle" aria-expanded="false" aria-controls="sidetoggle">Show / Hide Table of Contents</a>
          <div class="sidetoggle collapse" id="sidetoggle">
            <div id="sidetoc"></div>
          </div>
        </div>
        <div class="article row grid-right">
          <div class="col-md-10">
            <article class="content wrap" id="_content" data-uid="Cephei.QL.YearOnYearInflationSwapModel">
  
  
  <h1 id="Cephei_QL_YearOnYearInflationSwapModel" data-uid="Cephei.QL.YearOnYearInflationSwapModel" class="text-break">Class YearOnYearInflationSwapModel
  </h1>
  <div class="markdown level0 summary"></div>
  <div class="markdown level0 conceptual"></div>
  <div class="inheritance">
    <h5>Inheritance</h5>
    <div class="level0"><span class="xref">System.Object</span></div>
    <div class="level1"><span class="xref">System.Collections.Concurrent.ConcurrentDictionary</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;</div>
    <div class="level2"><a class="xref" href="Cephei.Cell.Model.html">Model</a></div>
    <div class="level3"><a class="xref" href="Cephei.Cell.Generic.Model-1.html">Model</a>&lt;<span class="xref">QLNet.YearOnYearInflationSwap</span>&gt;</div>
    <div class="level4"><span class="xref">YearOnYearInflationSwapModel</span></div>
  </div>
  <div classs="implements">
    <h5>Implements</h5>
    <div><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.YearOnYearInflationSwap</span>&gt;</div>
    <div><a class="xref" href="Cephei.Cell.ICell.html">ICell</a></div>
    <div><a class="xref" href="Cephei.Cell.ICellEvent.html">ICellEvent</a></div>
    <div><span class="xref">System.Collections.Generic.ICollection</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;&gt;</div>
    <div><span class="xref">System.Collections.Generic.IDictionary</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;</div>
    <div><span class="xref">System.Collections.Generic.IEnumerable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;&gt;</div>
    <div><span class="xref">System.Collections.Generic.IReadOnlyCollection</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;&gt;</div>
    <div><span class="xref">System.Collections.Generic.IReadOnlyDictionary</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;</div>
    <div><span class="xref">System.Collections.ICollection</span></div>
    <div><span class="xref">System.Collections.IDictionary</span></div>
    <div><span class="xref">System.Collections.IEnumerable</span></div>
    <div><span class="xref">System.IObservable</span>&lt;<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<a class="xref" href="Cephei.Cell.ISession.html">ISession</a> * <a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.YearOnYearInflationSwap</span>&gt; * <a class="xref" href="Cephei.Cell.CellEvent.html">CellEvent</a> * <a class="xref" href="Cephei.Cell.ICell.html">ICell</a> * <span class="xref">System.DateTime</span>&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<a class="xref" href="Cephei.Cell.ISession.html">ISession</a> * <a class="xref" href="Cephei.Cell.Model.html">Model</a> * <a class="xref" href="Cephei.Cell.CellEvent.html">CellEvent</a> * <a class="xref" href="Cephei.Cell.ICell.html">ICell</a> * <span class="xref">System.DateTime</span>&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">QLNet.YearOnYearInflationSwap</span>&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<a class="xref" href="Cephei.Cell.ISession.html">ISession</a>,<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;&gt;&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<a class="xref" href="Cephei.Cell.ISession.html">ISession</a>,<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<span class="xref">QLNet.YearOnYearInflationSwap</span>&gt;&gt;&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<span class="xref">decimal</span>&gt;&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<span class="xref">float</span>&gt;&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<span class="xref">int</span>&gt;&gt;</div>
    <div><span class="xref">System.IObserver</span>&lt;<span class="xref">QLNet.YearOnYearInflationSwap</span>&gt;</div>
  </div>
  <div class="inheritedMembers">
    <h5>Inherited Members</h5>
    <div>
      <span class="xref">member Cephei.Cell.Generic.Model.Bind: Cephei.Cell.Generic.ICell&lt;'T&gt; -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.OnCompleted: unit -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.OnError: exn -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.OnNext: 'T -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.Subscribe: System.IObserver&lt;'T&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.Subscribe: System.IObserver&lt;Cephei.Cell.ISession * Cephei.Cell.Generic.ICell&lt;'T&gt; * Cephei.Cell.CellEvent * Cephei.Cell.ICell * System.DateTime&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Generic.Model.Subscribe: System.IObserver&lt;System.Collections.Generic.KeyValuePair&lt;Cephei.Cell.ISession,System.Collections.Generic.KeyValuePair&lt;string,'T&gt;&gt;&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Generic.Model.Value: 'T</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.As: string -&gt; Cephei.Cell.Generic.ICell&lt;'T&gt;</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.Bind: unit -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.Box: obj</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Change: Cephei.Cell.CellChange</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.Create: Unit -&gt; 'T * string -&gt; Cephei.Cell.Generic.Cell&lt;'T&gt;</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.CreateValue: 'T * string -&gt; Cephei.Cell.Generic.Cell&lt;'T&gt;</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.Dependants: System.Collections.Generic.IEnumerable&lt;Cephei.Cell.ICellEvent&gt;</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.Dispose: unit -&gt; unit</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.GetOrAdd: string * Cephei.Cell.ICell -&gt; Cephei.Cell.ICell</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.HasFunction: bool</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.HasValue: bool</span>
    </div>
    <div>
      <span class="xref">property Cephei.Cell.Model.Item: string -&gt; Cephei.Cell.ICell</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.Mnemonic: string</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.OnChange: Cephei.Cell.CellEvent * Cephei.Cell.ICellEvent * System.DateTime * Cephei.Cell.ISession -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract property Cephei.Cell.Model.Parent: Cephei.Cell.ICell</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;Cephei.Cell.ICell&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;Cephei.Cell.ISession * Cephei.Cell.Model * Cephei.Cell.CellEvent * Cephei.Cell.ICell * System.DateTime&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;System.Collections.Generic.KeyValuePair&lt;Cephei.Cell.ISession,System.Collections.Generic.KeyValuePair&lt;string,Cephei.Cell.ICell&gt;&gt;&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;System.Collections.Generic.KeyValuePair&lt;string,decimal&gt;&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;System.Collections.Generic.KeyValuePair&lt;string,float&gt;&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.Subscribe: System.IObserver&lt;System.Collections.Generic.KeyValuePair&lt;string,int&gt;&gt; -&gt; System.IDisposable</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.TryAdd: string * Cephei.Cell.ICell -&gt; bool</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.TryRemove: string * Cephei.Cell.ICell byref -&gt; bool</span>
    </div>
    <div>
      <span class="xref">member Cephei.Cell.Model.TryUpdate: string * Cephei.Cell.ICell * Cephei.Cell.ICell -&gt; bool</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.add_Change: Cephei.Cell.CellChange -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member Cephei.Cell.Model.remove_Change: Cephei.Cell.CellChange -&gt; unit</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.AddOrUpdate: 'TKey * 'TValue * System.Func&lt;'TKey,'TValue,'TValue&gt; -&gt; 'TValue</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.AddOrUpdate: 'TKey * System.Func&lt;'TKey,'TValue&gt; * System.Func&lt;'TKey,'TValue,'TValue&gt; -&gt; 'TValue</span>
    </div>
    <div>
      <span class="xref">abstract member System.Collections.Concurrent.ConcurrentDictionary.Clear: unit -&gt; unit</span>
    </div>
    <div>
      <span class="xref">abstract member System.Collections.Concurrent.ConcurrentDictionary.ContainsKey: 'TKey -&gt; bool</span>
    </div>
    <div>
      <span class="xref">abstract property System.Collections.Concurrent.ConcurrentDictionary.Count: int</span>
    </div>
    <div>
      <span class="xref">abstract member System.Collections.Concurrent.ConcurrentDictionary.GetEnumerator: unit -&gt; System.Collections.Generic.IEnumerator&lt;System.Collections.Generic.KeyValuePair&lt;'TKey,'TValue&gt;&gt;</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.GetOrAdd: 'TKey * 'TValue -&gt; 'TValue</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.GetOrAdd: 'TKey * System.Func&lt;'TKey,'TValue&gt; -&gt; 'TValue</span>
    </div>
    <div>
      <span class="xref">property System.Collections.Concurrent.ConcurrentDictionary.IsEmpty: bool</span>
    </div>
    <div>
      <span class="xref">abstract property System.Collections.Concurrent.ConcurrentDictionary.Item: 'TKey -&gt; 'TValue</span>
    </div>
    <div>
      <span class="xref">abstract property System.Collections.Concurrent.ConcurrentDictionary.Keys: System.Collections.Generic.ICollection&lt;'TKey&gt;</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.ToArray: unit -&gt; System.Collections.Generic.KeyValuePair&lt;'TKey,'TValue&gt; []</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.TryAdd: 'TKey * 'TValue -&gt; bool</span>
    </div>
    <div>
      <span class="xref">abstract member System.Collections.Concurrent.ConcurrentDictionary.TryGetValue: 'TKey * 'TValue byref -&gt; bool</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.TryRemove: 'TKey * 'TValue byref -&gt; bool</span>
    </div>
    <div>
      <span class="xref">member System.Collections.Concurrent.ConcurrentDictionary.TryUpdate: 'TKey * 'TValue * 'TValue -&gt; bool</span>
    </div>
    <div>
      <span class="xref">abstract property System.Collections.Concurrent.ConcurrentDictionary.Values: System.Collections.Generic.ICollection&lt;'TValue&gt;</span>
    </div>
  </div>
  <h6><strong>Namespace</strong>: <a class="xref" href="Cephei.QL.html">Cephei.QL</a></h6>
  <h6><strong>Assembly</strong>: Cephei.QL.dll</h6>
  <h5 id="Cephei_QL_YearOnYearInflationSwapModel_syntax">Syntax</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">[&lt;AutoSerializable(true)&gt;]
type YearOnYearInflationSwapModel (Type:ICell&lt;Type&gt;, nominal:ICell&lt;double&gt;, fixedSchedule:ICell&lt;Schedule&gt;, fixedRate:ICell&lt;double&gt;, fixedDayCount:ICell&lt;DayCounter&gt;, yoySchedule:ICell&lt;Schedule&gt;, yoyIndex:ICell&lt;YoYInflationIndex&gt;, observationLag:ICell&lt;Period&gt;, spread:ICell&lt;double&gt;, yoyDayCount:ICell&lt;DayCounter&gt;, paymentCalendar:ICell&lt;Calendar&gt;, paymentConvention:ICell&lt;BusinessDayConvention&gt;, pricingEngine:ICell&lt;IPricingEngine&gt;, evaluationDate:ICell&lt;Date&gt;)
    inherit Model&lt;YearOnYearInflationSwap&gt;
    interface IDictionary&lt;string,ICell&gt;
    interface ICollection&lt;KeyValuePair&lt;string,ICell&gt;&gt;
    interface IReadOnlyDictionary&lt;string,ICell&gt;
    interface IReadOnlyCollection&lt;KeyValuePair&lt;string,ICell&gt;&gt;
    interface IEnumerable&lt;KeyValuePair&lt;string,ICell&gt;&gt;
    interface IDictionary
    interface ICollection
    interface IEnumerable
    interface IObservable&lt;ICell&gt;
    interface IObservable&lt;KeyValuePair&lt;ISession,KeyValuePair&lt;string,ICell&gt;&gt;&gt;
    interface IObservable&lt;ISession * Model * CellEvent * ICell * DateTime&gt;
    interface IObservable&lt;KeyValuePair&lt;string,float&gt;&gt;
    interface IObservable&lt;KeyValuePair&lt;string,int&gt;&gt;
    interface IObservable&lt;KeyValuePair&lt;string,decimal&gt;&gt;
    interface ICell&lt;YearOnYearInflationSwap&gt;
    interface ICell
    interface ICellEvent
    interface IObservable&lt;YearOnYearInflationSwap&gt;
    interface IObservable&lt;KeyValuePair&lt;ISession,KeyValuePair&lt;string,YearOnYearInflationSwap&gt;&gt;&gt;
    interface IObservable&lt;ISession * ICell&lt;YearOnYearInflationSwap&gt; * CellEvent * ICell * DateTime&gt;
    interface IObserver&lt;YearOnYearInflationSwap&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.YearOnYearInflationSwap.Type</span>&gt;</td>
        <td><span class="parametername">Type</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">double</span>&gt;</td>
        <td><span class="parametername">nominal</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Schedule</span>&gt;</td>
        <td><span class="parametername">fixedSchedule</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">double</span>&gt;</td>
        <td><span class="parametername">fixedRate</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.DayCounter</span>&gt;</td>
        <td><span class="parametername">fixedDayCount</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Schedule</span>&gt;</td>
        <td><span class="parametername">yoySchedule</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.YoYInflationIndex</span>&gt;</td>
        <td><span class="parametername">yoyIndex</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Period</span>&gt;</td>
        <td><span class="parametername">observationLag</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">double</span>&gt;</td>
        <td><span class="parametername">spread</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.DayCounter</span>&gt;</td>
        <td><span class="parametername">yoyDayCount</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Calendar</span>&gt;</td>
        <td><span class="parametername">paymentCalendar</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.BusinessDayConvention</span>&gt;</td>
        <td><span class="parametername">paymentConvention</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.IPricingEngine</span>&gt;</td>
        <td><span class="parametername">pricingEngine</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td><span class="parametername">evaluationDate</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="constructors">Constructors
  </h3>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel__ctor_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.#ctor*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel__ctor_Cephei_Cell_Generic_ICell_QLNet_YearOnYearInflationSwap_Type____Cephei_Cell_Generic_ICell_double____Cephei_Cell_Generic_ICell_QLNet_Schedule____Cephei_Cell_Generic_ICell_double____Cephei_Cell_Generic_ICell_QLNet_DayCounter____Cephei_Cell_Generic_ICell_QLNet_Schedule____Cephei_Cell_Generic_ICell_QLNet_YoYInflationIndex____Cephei_Cell_Generic_ICell_QLNet_Period____Cephei_Cell_Generic_ICell_double____Cephei_Cell_Generic_ICell_QLNet_DayCounter____Cephei_Cell_Generic_ICell_QLNet_Calendar____Cephei_Cell_Generic_ICell_QLNet_BusinessDayConvention____Cephei_Cell_Generic_ICell_QLNet_IPricingEngine____Cephei_Cell_Generic_ICell_QLNet_Date__" data-uid="Cephei.QL.YearOnYearInflationSwapModel.#ctor(Cephei.Cell.Generic.ICell&lt;QLNet.YearOnYearInflationSwap.Type&gt; * Cephei.Cell.Generic.ICell&lt;double&gt; * Cephei.Cell.Generic.ICell&lt;QLNet.Schedule&gt; * Cephei.Cell.Generic.ICell&lt;double&gt; * Cephei.Cell.Generic.ICell&lt;QLNet.DayCounter&gt; * Cephei.Cell.Generic.ICell&lt;QLNet.Schedule&gt; * Cephei.Cell.Generic.ICell&lt;QLNet.YoYInflationIndex&gt; * Cephei.Cell.Generic.ICell&lt;QLNet.Period&gt; * Cephei.Cell.Generic.ICell&lt;double&gt; * Cephei.Cell.Generic.ICell&lt;QLNet.DayCounter&gt; * Cephei.Cell.Generic.ICell&lt;QLNet.Calendar&gt; * Cephei.Cell.Generic.ICell&lt;QLNet.BusinessDayConvention&gt; * Cephei.Cell.Generic.ICell&lt;QLNet.IPricingEngine&gt; * Cephei.Cell.Generic.ICell&lt;QLNet.Date&gt;)">new: ICell&lt;Type&gt; * ICell&lt;double&gt; * ICell&lt;Schedule&gt; * ICell&lt;double&gt; * ICell&lt;DayCounter&gt; * ICell&lt;Schedule&gt; * ICell&lt;YoYInflationIndex&gt; * ICell&lt;Period&gt; * ICell&lt;double&gt; * ICell&lt;DayCounter&gt; * ICell&lt;Calendar&gt; * ICell&lt;BusinessDayConvention&gt; * ICell&lt;IPricingEngine&gt; * ICell&lt;Date&gt; -&gt; YearOnYearInflationSwapModel</h4>
  <div class="markdown level1 summary"><p>Implicit constructor.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">new: Type:ICell&lt;Type&gt; * nominal:ICell&lt;double&gt; * fixedSchedule:ICell&lt;Schedule&gt; * fixedRate:ICell&lt;double&gt; * fixedDayCount:ICell&lt;DayCounter&gt; * yoySchedule:ICell&lt;Schedule&gt; * yoyIndex:ICell&lt;YoYInflationIndex&gt; * observationLag:ICell&lt;Period&gt; * spread:ICell&lt;double&gt; * yoyDayCount:ICell&lt;DayCounter&gt; * paymentCalendar:ICell&lt;Calendar&gt; * paymentConvention:ICell&lt;BusinessDayConvention&gt; * pricingEngine:ICell&lt;IPricingEngine&gt; * evaluationDate:ICell&lt;Date&gt; -&gt; YearOnYearInflationSwapModel</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.YearOnYearInflationSwap.Type</span>&gt;</td>
        <td><span class="parametername">Type</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">double</span>&gt;</td>
        <td><span class="parametername">nominal</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Schedule</span>&gt;</td>
        <td><span class="parametername">fixedSchedule</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">double</span>&gt;</td>
        <td><span class="parametername">fixedRate</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.DayCounter</span>&gt;</td>
        <td><span class="parametername">fixedDayCount</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Schedule</span>&gt;</td>
        <td><span class="parametername">yoySchedule</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.YoYInflationIndex</span>&gt;</td>
        <td><span class="parametername">yoyIndex</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Period</span>&gt;</td>
        <td><span class="parametername">observationLag</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">double</span>&gt;</td>
        <td><span class="parametername">spread</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.DayCounter</span>&gt;</td>
        <td><span class="parametername">yoyDayCount</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Calendar</span>&gt;</td>
        <td><span class="parametername">paymentCalendar</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.BusinessDayConvention</span>&gt;</td>
        <td><span class="parametername">paymentConvention</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.IPricingEngine</span>&gt;</td>
        <td><span class="parametername">pricingEngine</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td><span class="parametername">evaluationDate</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.QL.YearOnYearInflationSwapModel.html">YearOnYearInflationSwapModel</a></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="properties">Properties
  </h3>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_CASH_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.CASH*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_CASH_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.CASH(unit)">property CASH: ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property CASH: ICell&lt;float&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_Engine_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.Engine*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_Engine_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.Engine(unit)">property Engine: ICell&lt;SwapEngine&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property Engine: ICell&lt;SwapEngine&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Swap.SwapEngine</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_ErrorEstimate_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.ErrorEstimate*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_ErrorEstimate_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.ErrorEstimate(unit)">property ErrorEstimate: ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property ErrorEstimate: ICell&lt;float&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_EvaluationDate_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.EvaluationDate*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_EvaluationDate_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.EvaluationDate(unit)">property EvaluationDate: ICell&lt;Date&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property EvaluationDate: ICell&lt;Date&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_FairRate_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.FairRate*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_FairRate_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.FairRate(unit)">property FairRate: ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property FairRate: ICell&lt;float&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_FairSpread_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.FairSpread*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_FairSpread_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.FairSpread(unit)">property FairSpread: ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property FairSpread: ICell&lt;float&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_fixedDayCount_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.fixedDayCount*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_fixedDayCount_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.fixedDayCount(unit)">property fixedDayCount: ICell&lt;DayCounter&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property fixedDayCount: ICell&lt;DayCounter&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.DayCounter</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_FixedDayCount_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.FixedDayCount*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_FixedDayCount_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.FixedDayCount(unit)">property FixedDayCount: ICell&lt;DayCounter&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property FixedDayCount: ICell&lt;DayCounter&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.DayCounter</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_FixedLeg_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.FixedLeg*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_FixedLeg_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.FixedLeg(unit)">property FixedLeg: ICell&lt;List&lt;CashFlow&gt;&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property FixedLeg: ICell&lt;List&lt;CashFlow&gt;&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">QLNet.CashFlow</span>&gt;&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_FixedLegNPV_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.FixedLegNPV*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_FixedLegNPV_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.FixedLegNPV(unit)">property FixedLegNPV: ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property FixedLegNPV: ICell&lt;float&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_fixedRate_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.fixedRate*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_fixedRate_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.fixedRate(unit)">property fixedRate: ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property fixedRate: ICell&lt;float&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_FixedRate_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.FixedRate*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_FixedRate_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.FixedRate(unit)">property FixedRate: ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property FixedRate: ICell&lt;float&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_fixedSchedule_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.fixedSchedule*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_fixedSchedule_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.fixedSchedule(unit)">property fixedSchedule: ICell&lt;Schedule&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property fixedSchedule: ICell&lt;Schedule&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Schedule</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_FixedSchedule_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.FixedSchedule*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_FixedSchedule_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.FixedSchedule(unit)">property FixedSchedule: ICell&lt;Schedule&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property FixedSchedule: ICell&lt;Schedule&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Schedule</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_IsExpired_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.IsExpired*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_IsExpired_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.IsExpired(unit)">property IsExpired: ICell&lt;bool&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property IsExpired: ICell&lt;bool&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">bool</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_MaturityDate_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.MaturityDate*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_MaturityDate_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.MaturityDate(unit)">property MaturityDate: ICell&lt;Date&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property MaturityDate: ICell&lt;Date&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_nominal_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.nominal*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_nominal_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.nominal(unit)">property nominal: ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property nominal: ICell&lt;float&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_Nominal_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.Nominal*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_Nominal_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.Nominal(unit)">property Nominal: ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property Nominal: ICell&lt;float&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_NPV_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.NPV*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_NPV_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.NPV(unit)">property NPV: ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property NPV: ICell&lt;float&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_NpvDateDiscount_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.NpvDateDiscount*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_NpvDateDiscount_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.NpvDateDiscount(unit)">property NpvDateDiscount: ICell&lt;Nullable&lt;float&gt;&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property NpvDateDiscount: ICell&lt;Nullable&lt;float&gt;&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">System.Nullable</span>&lt;<span class="xref">float</span>&gt;&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_observationLag_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.observationLag*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_observationLag_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.observationLag(unit)">property observationLag: ICell&lt;Period&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property observationLag: ICell&lt;Period&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Period</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_ObservationLag_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.ObservationLag*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_ObservationLag_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.ObservationLag(unit)">property ObservationLag: ICell&lt;Period&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property ObservationLag: ICell&lt;Period&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Period</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_paymentCalendar_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.paymentCalendar*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_paymentCalendar_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.paymentCalendar(unit)">property paymentCalendar: ICell&lt;Calendar&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property paymentCalendar: ICell&lt;Calendar&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Calendar</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_PaymentCalendar_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.PaymentCalendar*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_PaymentCalendar_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.PaymentCalendar(unit)">property PaymentCalendar: ICell&lt;Calendar&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property PaymentCalendar: ICell&lt;Calendar&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Calendar</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_paymentConvention_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.paymentConvention*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_paymentConvention_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.paymentConvention(unit)">property paymentConvention: ICell&lt;BusinessDayConvention&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property paymentConvention: ICell&lt;BusinessDayConvention&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.BusinessDayConvention</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_PaymentConvention_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.PaymentConvention*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_PaymentConvention_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.PaymentConvention(unit)">property PaymentConvention: ICell&lt;BusinessDayConvention&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property PaymentConvention: ICell&lt;BusinessDayConvention&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.BusinessDayConvention</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_PricingEngine_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.PricingEngine*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_PricingEngine_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.PricingEngine(unit)">property PricingEngine: ICell&lt;IPricingEngine&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property PricingEngine: ICell&lt;IPricingEngine&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.IPricingEngine</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_spread_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.spread*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_spread_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.spread(unit)">property spread: ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property spread: ICell&lt;float&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_Spread_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.Spread*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_Spread_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.Spread(unit)">property Spread: ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property Spread: ICell&lt;float&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_StartDate_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.StartDate*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_StartDate_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.StartDate(unit)">property StartDate: ICell&lt;Date&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property StartDate: ICell&lt;Date&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_Type_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.Type*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_Type_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.Type(unit)">property Type: ICell&lt;Type&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property Type: ICell&lt;Type&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.YearOnYearInflationSwap.Type</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_Type1_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.Type1*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_Type1_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.Type1(unit)">property Type1: ICell&lt;Type&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property Type1: ICell&lt;Type&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.YearOnYearInflationSwap.Type</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_ValuationDate_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.ValuationDate*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_ValuationDate_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.ValuationDate(unit)">property ValuationDate: ICell&lt;Date&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property ValuationDate: ICell&lt;Date&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Date</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_yoyDayCount_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.yoyDayCount*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_yoyDayCount_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.yoyDayCount(unit)">property yoyDayCount: ICell&lt;DayCounter&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property yoyDayCount: ICell&lt;DayCounter&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.DayCounter</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_YoyDayCount_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.YoyDayCount*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_YoyDayCount_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.YoyDayCount(unit)">property YoyDayCount: ICell&lt;DayCounter&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property YoyDayCount: ICell&lt;DayCounter&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.DayCounter</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_yoyIndex_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.yoyIndex*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_yoyIndex_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.yoyIndex(unit)">property yoyIndex: ICell&lt;YoYInflationIndex&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property yoyIndex: ICell&lt;YoYInflationIndex&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.YoYInflationIndex</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_YoyInflationIndex_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.YoyInflationIndex*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_YoyInflationIndex_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.YoyInflationIndex(unit)">property YoyInflationIndex: ICell&lt;YoYInflationIndex&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property YoyInflationIndex: ICell&lt;YoYInflationIndex&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.YoYInflationIndex</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_YoyLeg_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.YoyLeg*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_YoyLeg_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.YoyLeg(unit)">property YoyLeg: ICell&lt;List&lt;CashFlow&gt;&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property YoyLeg: ICell&lt;List&lt;CashFlow&gt;&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">QLNet.CashFlow</span>&gt;&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_YoyLegNPV_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.YoyLegNPV*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_YoyLegNPV_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.YoyLegNPV(unit)">property YoyLegNPV: ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property YoyLegNPV: ICell&lt;float&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_yoySchedule_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.yoySchedule*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_yoySchedule_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.yoySchedule(unit)">property yoySchedule: ICell&lt;Schedule&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property yoySchedule: ICell&lt;Schedule&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Schedule</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_YoySchedule_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.YoySchedule*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_YoySchedule_unit_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.YoySchedule(unit)">property YoySchedule: ICell&lt;Schedule&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property YoySchedule: ICell&lt;Schedule&gt; with get</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Schedule</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="methods">Methods
  </h3>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_EndDiscounts_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.EndDiscounts*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_EndDiscounts_Cephei_Cell_Generic_ICell_int__" data-uid="Cephei.QL.YearOnYearInflationSwapModel.EndDiscounts(Cephei.Cell.Generic.ICell&lt;int&gt;)">member EndDiscounts: ICell&lt;int&gt; -&gt; ICell&lt;Nullable&lt;float&gt;&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member EndDiscounts: j:ICell&lt;int&gt; -&gt; ICell&lt;Nullable&lt;float&gt;&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">int</span>&gt;</td>
        <td><span class="parametername">j</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">System.Nullable</span>&lt;<span class="xref">float</span>&gt;&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_Leg_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.Leg*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_Leg_Cephei_Cell_Generic_ICell_int__" data-uid="Cephei.QL.YearOnYearInflationSwapModel.Leg(Cephei.Cell.Generic.ICell&lt;int&gt;)">member Leg: ICell&lt;int&gt; -&gt; ICell&lt;List&lt;CashFlow&gt;&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member Leg: j:ICell&lt;int&gt; -&gt; ICell&lt;List&lt;CashFlow&gt;&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">int</span>&gt;</td>
        <td><span class="parametername">j</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">QLNet.CashFlow</span>&gt;&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_LegBPS_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.LegBPS*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_LegBPS_Cephei_Cell_Generic_ICell_int__" data-uid="Cephei.QL.YearOnYearInflationSwapModel.LegBPS(Cephei.Cell.Generic.ICell&lt;int&gt;)">member LegBPS: ICell&lt;int&gt; -&gt; ICell&lt;Nullable&lt;float&gt;&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member LegBPS: j:ICell&lt;int&gt; -&gt; ICell&lt;Nullable&lt;float&gt;&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">int</span>&gt;</td>
        <td><span class="parametername">j</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">System.Nullable</span>&lt;<span class="xref">float</span>&gt;&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_LegNPV_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.LegNPV*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_LegNPV_Cephei_Cell_Generic_ICell_int__" data-uid="Cephei.QL.YearOnYearInflationSwapModel.LegNPV(Cephei.Cell.Generic.ICell&lt;int&gt;)">member LegNPV: ICell&lt;int&gt; -&gt; ICell&lt;Nullable&lt;float&gt;&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member LegNPV: j:ICell&lt;int&gt; -&gt; ICell&lt;Nullable&lt;float&gt;&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">int</span>&gt;</td>
        <td><span class="parametername">j</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">System.Nullable</span>&lt;<span class="xref">float</span>&gt;&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_Payer_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.Payer*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_Payer_Cephei_Cell_Generic_ICell_int__" data-uid="Cephei.QL.YearOnYearInflationSwapModel.Payer(Cephei.Cell.Generic.ICell&lt;int&gt;)">member Payer: ICell&lt;int&gt; -&gt; ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member Payer: j:ICell&lt;int&gt; -&gt; ICell&lt;float&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">int</span>&gt;</td>
        <td><span class="parametername">j</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">float</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_Result_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.Result*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_Result_Cephei_Cell_Generic_ICell_string__" data-uid="Cephei.QL.YearOnYearInflationSwapModel.Result(Cephei.Cell.Generic.ICell&lt;string&gt;)">member Result: ICell&lt;string&gt; -&gt; ICell&lt;obj&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member Result: tag:ICell&lt;string&gt; -&gt; ICell&lt;obj&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">string</span>&gt;</td>
        <td><span class="parametername">tag</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">obj</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_SetPricingEngine_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.SetPricingEngine*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_SetPricingEngine_Cephei_Cell_Generic_ICell_QLNet_IPricingEngine__" data-uid="Cephei.QL.YearOnYearInflationSwapModel.SetPricingEngine(Cephei.Cell.Generic.ICell&lt;QLNet.IPricingEngine&gt;)">member SetPricingEngine: ICell&lt;IPricingEngine&gt; -&gt; ICell&lt;YearOnYearInflationSwap&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member SetPricingEngine: e:ICell&lt;IPricingEngine&gt; -&gt; ICell&lt;YearOnYearInflationSwap&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.IPricingEngine</span>&gt;</td>
        <td><span class="parametername">e</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.YearOnYearInflationSwap</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_YearOnYearInflationSwapModel_StartDiscounts_" data-uid="Cephei.QL.YearOnYearInflationSwapModel.StartDiscounts*"></a>
  <h4 id="Cephei_QL_YearOnYearInflationSwapModel_StartDiscounts_Cephei_Cell_Generic_ICell_int__" data-uid="Cephei.QL.YearOnYearInflationSwapModel.StartDiscounts(Cephei.Cell.Generic.ICell&lt;int&gt;)">member StartDiscounts: ICell&lt;int&gt; -&gt; ICell&lt;Nullable&lt;float&gt;&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member StartDiscounts: j:ICell&lt;int&gt; -&gt; ICell&lt;Nullable&lt;float&gt;&gt;</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">int</span>&gt;</td>
        <td><span class="parametername">j</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">System.Nullable</span>&lt;<span class="xref">float</span>&gt;&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="implements">Implements</h3>
  <div>
      <span class="xref">Cephei.Cell.Generic.ICell&lt;QLNet.YearOnYearInflationSwap&gt;</span>
  </div>
  <div>
      <span class="xref">Cephei.Cell.ICell</span>
  </div>
  <div>
      <span class="xref">Cephei.Cell.ICellEvent</span>
  </div>
  <div>
      <span class="xref">System.Collections.Generic.ICollection&lt;System.Collections.Generic.KeyValuePair&lt;string,Cephei.Cell.ICell&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.Collections.Generic.IDictionary&lt;string,Cephei.Cell.ICell&gt;</span>
  </div>
  <div>
      <span class="xref">System.Collections.Generic.IEnumerable&lt;System.Collections.Generic.KeyValuePair&lt;string,Cephei.Cell.ICell&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.Collections.Generic.IReadOnlyCollection&lt;System.Collections.Generic.KeyValuePair&lt;string,Cephei.Cell.ICell&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.Collections.Generic.IReadOnlyDictionary&lt;string,Cephei.Cell.ICell&gt;</span>
  </div>
  <div>
      <span class="xref">System.Collections.ICollection</span>
  </div>
  <div>
      <span class="xref">System.Collections.IDictionary</span>
  </div>
  <div>
      <span class="xref">System.Collections.IEnumerable</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;Cephei.Cell.ICell&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;Cephei.Cell.ISession * Cephei.Cell.Generic.ICell&lt;QLNet.YearOnYearInflationSwap&gt; * Cephei.Cell.CellEvent * Cephei.Cell.ICell * System.DateTime&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;Cephei.Cell.ISession * Cephei.Cell.Model * Cephei.Cell.CellEvent * Cephei.Cell.ICell * System.DateTime&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;QLNet.YearOnYearInflationSwap&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;System.Collections.Generic.KeyValuePair&lt;Cephei.Cell.ISession,System.Collections.Generic.KeyValuePair&lt;string,Cephei.Cell.ICell&gt;&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;System.Collections.Generic.KeyValuePair&lt;Cephei.Cell.ISession,System.Collections.Generic.KeyValuePair&lt;string,QLNet.YearOnYearInflationSwap&gt;&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;System.Collections.Generic.KeyValuePair&lt;string,decimal&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;System.Collections.Generic.KeyValuePair&lt;string,float&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;System.Collections.Generic.KeyValuePair&lt;string,int&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObserver&lt;QLNet.YearOnYearInflationSwap&gt;</span>
  </div>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                </ul>
              </div>
              <nav class="bs-docs-sidebar hidden-print hidden-xs hidden-sm affix" id="affix">
              <!-- <p><a class="back-to-top" href="#top">Back to top</a><p> -->
              </nav>
            </div>
          </div>
        </div>
      </div>
      
      <footer>
        <div class="grad-bottom"></div>
        <div class="footer">
          <div class="container">
            <span class="pull-right">
              <a href="#top">Back to top</a>
            </span>
            
            <span>Generated by <strong>DocFX</strong></span>
          </div>
        </div>
      </footer>
    </div>
    
    <script type="text/javascript" src="../styles/docfx.vendor.js"></script>
    <script type="text/javascript" src="../styles/docfx.js"></script>
    <script type="text/javascript" src="../styles/main.js"></script>
  </body>
</html>