﻿<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Class MixedLinearKrugerCubicModel
   </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Class MixedLinearKrugerCubicModel
   ">
    <meta name="generator" content="docfx 2.56.5.0">
    
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
            <article class="content wrap" id="_content" data-uid="Cephei.QL.MixedLinearKrugerCubicModel">
  
  
  <h1 id="Cephei_QL_MixedLinearKrugerCubicModel" data-uid="Cephei.QL.MixedLinearKrugerCubicModel" class="text-break">Class MixedLinearKrugerCubicModel
  </h1>
  <div class="markdown level0 summary"></div>
  <div class="markdown level0 conceptual"></div>
  <div class="inheritance">
    <h5>Inheritance</h5>
    <div class="level0"><span class="xref">System.Object</span></div>
    <div class="level1"><span class="xref">System.Collections.Concurrent.ConcurrentDictionary</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;</div>
    <div class="level2"><a class="xref" href="Cephei.Cell.Model.html">Model</a></div>
    <div class="level3"><a class="xref" href="Cephei.Cell.Generic.Model-1.html">Model</a>&lt;<span class="xref">QLNet.MixedLinearKrugerCubic</span>&gt;</div>
    <div class="level4"><span class="xref">MixedLinearKrugerCubicModel</span></div>
  </div>
  <div classs="implements">
    <h5>Implements</h5>
    <div><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.MixedLinearKrugerCubic</span>&gt;</div>
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
    <div><span class="xref">System.IObservable</span>&lt;<a class="xref" href="Cephei.Cell.ISession.html">ISession</a> * <a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.MixedLinearKrugerCubic</span>&gt; * <a class="xref" href="Cephei.Cell.CellEvent.html">CellEvent</a> * <a class="xref" href="Cephei.Cell.ICell.html">ICell</a> * <span class="xref">System.DateTime</span>&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<a class="xref" href="Cephei.Cell.ISession.html">ISession</a> * <a class="xref" href="Cephei.Cell.Model.html">Model</a> * <a class="xref" href="Cephei.Cell.CellEvent.html">CellEvent</a> * <a class="xref" href="Cephei.Cell.ICell.html">ICell</a> * <span class="xref">System.DateTime</span>&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">QLNet.MixedLinearKrugerCubic</span>&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<a class="xref" href="Cephei.Cell.ISession.html">ISession</a>,<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<a class="xref" href="Cephei.Cell.ICell.html">ICell</a>&gt;&gt;&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<a class="xref" href="Cephei.Cell.ISession.html">ISession</a>,<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<span class="xref">QLNet.MixedLinearKrugerCubic</span>&gt;&gt;&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<span class="xref">decimal</span>&gt;&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<span class="xref">float</span>&gt;&gt;</div>
    <div><span class="xref">System.IObservable</span>&lt;<span class="xref">System.Collections.Generic.KeyValuePair</span>&lt;<span class="xref">string</span>,<span class="xref">int</span>&gt;&gt;</div>
    <div><span class="xref">System.IObserver</span>&lt;<span class="xref">QLNet.MixedLinearKrugerCubic</span>&gt;</div>
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
  <h5 id="Cephei_QL_MixedLinearKrugerCubicModel_syntax">Syntax</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">[&lt;AutoSerializable(true)&gt;]
type MixedLinearKrugerCubicModel (xBegin:ICell&lt;List&lt;double&gt;&gt;, xEnd:ICell&lt;int&gt;, yBegin:ICell&lt;List&lt;double&gt;&gt;, n:ICell&lt;int&gt;, behavior:ICell&lt;Behavior&gt;)
    inherit Model&lt;MixedLinearKrugerCubic&gt;
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
    interface ICell&lt;MixedLinearKrugerCubic&gt;
    interface ICell
    interface ICellEvent
    interface IObservable&lt;MixedLinearKrugerCubic&gt;
    interface IObservable&lt;KeyValuePair&lt;ISession,KeyValuePair&lt;string,MixedLinearKrugerCubic&gt;&gt;&gt;
    interface IObservable&lt;ISession * ICell&lt;MixedLinearKrugerCubic&gt; * CellEvent * ICell * DateTime&gt;
    interface IObserver&lt;MixedLinearKrugerCubic&gt;</code></pre>
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
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">double</span>&gt;&gt;</td>
        <td><span class="parametername">xBegin</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">int</span>&gt;</td>
        <td><span class="parametername">xEnd</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">double</span>&gt;&gt;</td>
        <td><span class="parametername">yBegin</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">int</span>&gt;</td>
        <td><span class="parametername">n</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Behavior</span>&gt;</td>
        <td><span class="parametername">behavior</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="constructors">Constructors
  </h3>
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel__ctor_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.#ctor*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel__ctor_Cephei_Cell_Generic_ICell_System_Collections_Generic_List_double_____Cephei_Cell_Generic_ICell_int____Cephei_Cell_Generic_ICell_System_Collections_Generic_List_double_____Cephei_Cell_Generic_ICell_int____Cephei_Cell_Generic_ICell_QLNet_Behavior__" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.#ctor(Cephei.Cell.Generic.ICell&lt;System.Collections.Generic.List&lt;double&gt;&gt; * Cephei.Cell.Generic.ICell&lt;int&gt; * Cephei.Cell.Generic.ICell&lt;System.Collections.Generic.List&lt;double&gt;&gt; * Cephei.Cell.Generic.ICell&lt;int&gt; * Cephei.Cell.Generic.ICell&lt;QLNet.Behavior&gt;)">new: ICell&lt;List&lt;double&gt;&gt; * ICell&lt;int&gt; * ICell&lt;List&lt;double&gt;&gt; * ICell&lt;int&gt; * ICell&lt;Behavior&gt; -&gt; MixedLinearKrugerCubicModel</h4>
  <div class="markdown level1 summary"><p>Implicit constructor.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">new: xBegin:ICell&lt;List&lt;double&gt;&gt; * xEnd:ICell&lt;int&gt; * yBegin:ICell&lt;List&lt;double&gt;&gt; * n:ICell&lt;int&gt; * behavior:ICell&lt;Behavior&gt; -&gt; MixedLinearKrugerCubicModel</code></pre>
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
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">double</span>&gt;&gt;</td>
        <td><span class="parametername">xBegin</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">int</span>&gt;</td>
        <td><span class="parametername">xEnd</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">double</span>&gt;&gt;</td>
        <td><span class="parametername">yBegin</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">int</span>&gt;</td>
        <td><span class="parametername">n</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Behavior</span>&gt;</td>
        <td><span class="parametername">behavior</span></td>
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
        <td><a class="xref" href="Cephei.QL.MixedLinearKrugerCubicModel.html">MixedLinearKrugerCubicModel</a></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="properties">Properties
  </h3>
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_AllowsExtrapolation_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.AllowsExtrapolation*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_AllowsExtrapolation_unit_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.AllowsExtrapolation(unit)">property AllowsExtrapolation: ICell&lt;bool&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property AllowsExtrapolation: ICell&lt;bool&gt; with get</code></pre>
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
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_behavior_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.behavior*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_behavior_unit_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.behavior(unit)">property behavior: ICell&lt;Behavior&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property behavior: ICell&lt;Behavior&gt; with get</code></pre>
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
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.Behavior</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_Empty_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.Empty*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_Empty_unit_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.Empty(unit)">property Empty: ICell&lt;bool&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property Empty: ICell&lt;bool&gt; with get</code></pre>
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
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_Extrapolate_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.Extrapolate*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_Extrapolate_unit_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.Extrapolate(unit)">property Extrapolate: ICell&lt;bool&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property Extrapolate: ICell&lt;bool&gt; with get</code></pre>
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
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_n_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.n*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_n_unit_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.n(unit)">property n: ICell&lt;int&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property n: ICell&lt;int&gt; with get</code></pre>
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
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">int</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_Update_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.Update*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_Update_unit_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.Update(unit)">property Update: ICell&lt;MixedLinearKrugerCubic&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property Update: ICell&lt;MixedLinearKrugerCubic&gt; with get</code></pre>
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
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.MixedLinearKrugerCubic</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_xBegin_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.xBegin*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_xBegin_unit_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.xBegin(unit)">property xBegin: ICell&lt;List&lt;double&gt;&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property xBegin: ICell&lt;List&lt;double&gt;&gt; with get</code></pre>
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
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">double</span>&gt;&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_xEnd_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.xEnd*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_xEnd_unit_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.xEnd(unit)">property xEnd: ICell&lt;int&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property xEnd: ICell&lt;int&gt; with get</code></pre>
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
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">int</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_XMax_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.XMax*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_XMax_unit_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.XMax(unit)">property XMax: ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property XMax: ICell&lt;float&gt; with get</code></pre>
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
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_XMin_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.XMin*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_XMin_unit_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.XMin(unit)">property XMin: ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property XMin: ICell&lt;float&gt; with get</code></pre>
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
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_yBegin_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.yBegin*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_yBegin_unit_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.yBegin(unit)">property yBegin: ICell&lt;List&lt;double&gt;&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">property yBegin: ICell&lt;List&lt;double&gt;&gt; with get</code></pre>
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
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">double</span>&gt;&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="methods">Methods
  </h3>
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_Derivative_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.Derivative*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_Derivative_Cephei_Cell_Generic_ICell_double_____Cephei_Cell_Generic_ICell_bool__" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.Derivative(Cephei.Cell.Generic.ICell&lt;double&gt; -&gt; Cephei.Cell.Generic.ICell&lt;bool&gt;)">member Derivative: ICell&lt;double&gt; -&gt; ICell&lt;bool&gt; -&gt; ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member Derivative: x:ICell&lt;double&gt; -&gt; allowExtrapolation:ICell&lt;bool&gt; -&gt; ICell&lt;float&gt;</code></pre>
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
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">double</span>&gt;</td>
        <td><span class="parametername">x</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">bool</span>&gt;</td>
        <td><span class="parametername">allowExtrapolation</span></td>
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
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_DisableExtrapolation_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.DisableExtrapolation*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_DisableExtrapolation_Cephei_Cell_Generic_ICell_bool__" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.DisableExtrapolation(Cephei.Cell.Generic.ICell&lt;bool&gt;)">member DisableExtrapolation: ICell&lt;bool&gt; -&gt; ICell&lt;MixedLinearKrugerCubic&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member DisableExtrapolation: b:ICell&lt;bool&gt; -&gt; ICell&lt;MixedLinearKrugerCubic&gt;</code></pre>
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
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">bool</span>&gt;</td>
        <td><span class="parametername">b</span></td>
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
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.MixedLinearKrugerCubic</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_EnableExtrapolation_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.EnableExtrapolation*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_EnableExtrapolation_Cephei_Cell_Generic_ICell_bool__" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.EnableExtrapolation(Cephei.Cell.Generic.ICell&lt;bool&gt;)">member EnableExtrapolation: ICell&lt;bool&gt; -&gt; ICell&lt;MixedLinearKrugerCubic&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member EnableExtrapolation: b:ICell&lt;bool&gt; -&gt; ICell&lt;MixedLinearKrugerCubic&gt;</code></pre>
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
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">bool</span>&gt;</td>
        <td><span class="parametername">b</span></td>
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
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">QLNet.MixedLinearKrugerCubic</span>&gt;</td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_Primitive_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.Primitive*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_Primitive_Cephei_Cell_Generic_ICell_double_____Cephei_Cell_Generic_ICell_bool__" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.Primitive(Cephei.Cell.Generic.ICell&lt;double&gt; -&gt; Cephei.Cell.Generic.ICell&lt;bool&gt;)">member Primitive: ICell&lt;double&gt; -&gt; ICell&lt;bool&gt; -&gt; ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member Primitive: x:ICell&lt;double&gt; -&gt; allowExtrapolation:ICell&lt;bool&gt; -&gt; ICell&lt;float&gt;</code></pre>
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
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">double</span>&gt;</td>
        <td><span class="parametername">x</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">bool</span>&gt;</td>
        <td><span class="parametername">allowExtrapolation</span></td>
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
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_SecondDerivative_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.SecondDerivative*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_SecondDerivative_Cephei_Cell_Generic_ICell_double_____Cephei_Cell_Generic_ICell_bool__" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.SecondDerivative(Cephei.Cell.Generic.ICell&lt;double&gt; -&gt; Cephei.Cell.Generic.ICell&lt;bool&gt;)">member SecondDerivative: ICell&lt;double&gt; -&gt; ICell&lt;bool&gt; -&gt; ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member SecondDerivative: x:ICell&lt;double&gt; -&gt; allowExtrapolation:ICell&lt;bool&gt; -&gt; ICell&lt;float&gt;</code></pre>
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
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">double</span>&gt;</td>
        <td><span class="parametername">x</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">bool</span>&gt;</td>
        <td><span class="parametername">allowExtrapolation</span></td>
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
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_Value_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.Value*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_Value_Cephei_Cell_Generic_ICell_double__" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.Value(Cephei.Cell.Generic.ICell&lt;double&gt;)">member Value: ICell&lt;double&gt; -&gt; ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member Value: x:ICell&lt;double&gt; -&gt; ICell&lt;float&gt;</code></pre>
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
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">double</span>&gt;</td>
        <td><span class="parametername">x</span></td>
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
  
  
  <a id="Cephei_QL_MixedLinearKrugerCubicModel_Value1_" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.Value1*"></a>
  <h4 id="Cephei_QL_MixedLinearKrugerCubicModel_Value1_Cephei_Cell_Generic_ICell_double_____Cephei_Cell_Generic_ICell_bool__" data-uid="Cephei.QL.MixedLinearKrugerCubicModel.Value1(Cephei.Cell.Generic.ICell&lt;double&gt; -&gt; Cephei.Cell.Generic.ICell&lt;bool&gt;)">member Value1: ICell&lt;double&gt; -&gt; ICell&lt;bool&gt; -&gt; ICell&lt;float&gt;</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">member Value1: x:ICell&lt;double&gt; -&gt; allowExtrapolation:ICell&lt;bool&gt; -&gt; ICell&lt;float&gt;</code></pre>
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
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">double</span>&gt;</td>
        <td><span class="parametername">x</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="Cephei.Cell.Generic.ICell-1.html">ICell</a>&lt;<span class="xref">bool</span>&gt;</td>
        <td><span class="parametername">allowExtrapolation</span></td>
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
  <h3 id="implements">Implements</h3>
  <div>
      <span class="xref">Cephei.Cell.Generic.ICell&lt;QLNet.MixedLinearKrugerCubic&gt;</span>
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
      <span class="xref">System.IObservable&lt;Cephei.Cell.ISession * Cephei.Cell.Generic.ICell&lt;QLNet.MixedLinearKrugerCubic&gt; * Cephei.Cell.CellEvent * Cephei.Cell.ICell * System.DateTime&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;Cephei.Cell.ISession * Cephei.Cell.Model * Cephei.Cell.CellEvent * Cephei.Cell.ICell * System.DateTime&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;QLNet.MixedLinearKrugerCubic&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;System.Collections.Generic.KeyValuePair&lt;Cephei.Cell.ISession,System.Collections.Generic.KeyValuePair&lt;string,Cephei.Cell.ICell&gt;&gt;&gt;</span>
  </div>
  <div>
      <span class="xref">System.IObservable&lt;System.Collections.Generic.KeyValuePair&lt;Cephei.Cell.ISession,System.Collections.Generic.KeyValuePair&lt;string,QLNet.MixedLinearKrugerCubic&gt;&gt;&gt;</span>
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
      <span class="xref">System.IObserver&lt;QLNet.MixedLinearKrugerCubic&gt;</span>
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
                <h5>In This Article</h5>
                <div></div>
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