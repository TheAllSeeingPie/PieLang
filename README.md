# PieLang
For no reason whatsoever I feel like writing my own programming language. Lots of interesting times await me it seems ...

## Hello world!
A simple class that just has a "Hello world" method writing to the console:
```
with Greeting
	define HelloWorld as
		"Hello world!" >
```
This is how it would be invoked inside of a PieLang program:
```
Greeting -> say
say HelloWorld
```
## Introduction

So recently I tweeted out this blog post to one of the people I follow on Twitter: http://blogs.microsoft.co.il/sasha/2010/10/06/writing-a-compiler-in-c-lexical-analysis/. I realised that it's been sat in my bookmarks for while a while, and it's probably about time to do something about it. Obviously if I wanted to write my own language quickly I would use the suggested framework of Flex or something similar. However I am feeling brave today and that means I'll be creating the language from scratch as a compiled language using Roslyn and C# to the compilation part. However as things progress I might drop down to using Reflection.Emit and do the raw IL myself.

## Language Specification in Backus�Naur Form

statment	::= with-statment | define-statement