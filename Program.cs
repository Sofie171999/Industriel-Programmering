<html>
<head>
<title>Program.cs</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<style type="text/css">
.s0 { color: #85c46c; font-style: italic;}
.s1 { color: #d0d0d0;}
.s2 { color: #bdbdbd;}
.s3 { color: #c9a26d;}
.s4 { color: #6c95eb;}
.s5 { color: #ed94c0;}
</style>
</head>
<body bgcolor="#262626">
<table CELLSPACING=0 CELLPADDING=5 COLS=1 WIDTH="100%" BGCOLOR="#606060" >
<tr><td><center>
<font face="Arial, Helvetica" color="#000000">
Program.cs</font>
</center></td></tr></table>
<pre><span class="s0">// See https://aka.ms/new-console-template for more information</span>

<span class="s1">Console</span><span class="s2">.</span><span class="s1">WriteLine</span><span class="s2">(</span><span class="s3">&quot;Hello, World!&quot;</span><span class="s2">);</span>

<span class="s4">int </span><span class="s1">Control</span><span class="s2">(</span><span class="s4">int </span><span class="s1">altitude</span><span class="s2">)</span>
<span class="s2">{</span>
    <span class="s4">int </span><span class="s1">thruster </span><span class="s2">= </span><span class="s5">0</span><span class="s2">;</span>

    <span class="s4">if </span><span class="s2">(</span><span class="s1">altitude </span><span class="s2">&gt; </span><span class="s5">100</span><span class="s2">)</span>
    <span class="s2">{</span>
        <span class="s1">thruster </span><span class="s2">= </span><span class="s5">0</span><span class="s2">; </span><span class="s0">// Thruster OFF</span>
    <span class="s2">}</span>
    <span class="s4">else if </span><span class="s2">(</span><span class="s1">altitude </span><span class="s2">&gt; </span><span class="s5">0</span><span class="s2">)</span>
    <span class="s2">{</span>
        <span class="s1">thruster </span><span class="s2">= </span><span class="s5">1</span><span class="s2">; </span><span class="s0">// Thruster ON</span>
    <span class="s2">}</span>
    <span class="s4">else</span>
    <span class="s2">{</span>
        <span class="s1">thruster </span><span class="s2">= </span><span class="s5">0</span><span class="s2">; </span><span class="s0">// Thruster OFF</span>
    <span class="s2">}</span>

    <span class="s4">return </span><span class="s1">thruster</span><span class="s2">;</span>
<span class="s2">}</span>
<span class="s4">void </span><span class="s1">Test</span><span class="s2">(</span><span class="s4">int </span><span class="s1">altitude</span><span class="s2">)</span>
<span class="s2">{</span>
    <span class="s4">int </span><span class="s1">thruster </span><span class="s2">= </span><span class="s1">Control</span><span class="s2">(</span><span class="s1">altitude</span><span class="s2">);</span>
    <span class="s4">bool </span><span class="s1">behaviorCorrect </span><span class="s2">= (</span><span class="s1">altitude </span><span class="s2">&gt; </span><span class="s5">100 </span><span class="s2">&amp;&amp; </span><span class="s1">thruster </span><span class="s2">== </span><span class="s5">0</span><span class="s2">) ||</span>
                           <span class="s2">(</span><span class="s1">altitude </span><span class="s4">is </span><span class="s2">&lt;= </span><span class="s5">100 </span><span class="s1">and </span><span class="s2">&gt; </span><span class="s5">0 </span><span class="s2">&amp;&amp; </span><span class="s1">thruster </span><span class="s2">== </span><span class="s5">1</span><span class="s2">) ||</span>
                           <span class="s2">(</span><span class="s1">altitude </span><span class="s2">&lt;= </span><span class="s5">0 </span><span class="s2">&amp;&amp; </span><span class="s1">thruster </span><span class="s2">== </span><span class="s5">0</span><span class="s2">);</span>
    <span class="s1">var behaviorCorrectIcon </span><span class="s2">= </span><span class="s1">behaviorCorrect ? </span><span class="s3">&quot;✅&quot; </span><span class="s1">: </span><span class="s3">&quot;❌&quot;</span><span class="s2">;</span>
    <span class="s1">Console</span><span class="s2">.</span><span class="s1">WriteLine</span><span class="s2">(</span><span class="s3">$&quot;For altitude </span><span class="s2">{</span><span class="s1">altitude</span><span class="s2">}</span><span class="s3">, your thruster is </span><span class="s2">{</span><span class="s1">thruster</span><span class="s2">} </span><span class="s3">|</span><span class="s2">{</span><span class="s1">behaviorCorrectIcon</span><span class="s2">}</span><span class="s3">|&quot;</span><span class="s2">);</span>
<span class="s2">}</span>

<span class="s1">Test</span><span class="s2">(</span><span class="s5">150</span><span class="s2">);</span>
<span class="s1">Test</span><span class="s2">(</span><span class="s5">100</span><span class="s2">);</span>
<span class="s1">Test</span><span class="s2">(</span><span class="s5">50</span><span class="s2">);</span>
<span class="s1">Test</span><span class="s2">(</span><span class="s5">0</span><span class="s2">);</span>
<span class="s1">Test</span><span class="s2">(-</span><span class="s5">1</span><span class="s2">);</span>
</pre>
</body>
</html>
