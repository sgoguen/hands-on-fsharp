---
marp: true
theme: presentation
paginate: true

---


![bg right:66%](../images/brain.webp)

<!-- _class: white-text -->

# The Ergonomics of F#

Steve Goguen

---

# Agenda

## Talking
   * About Me and F#
   * Ergonomics
   * F#'s Origins in ML

## Playing
   * A Language for Types
   * A Functional-First Language
   * An Object-Oriented Language

---

# I asked a question on Twitter...

---

![bg contain](../images/opening-question.png)

---

# ...and got a lot of responses!

But two in particular echoed my story...

---

<!-- _class: white-text -->

![bg contain](../images/joy-again.png)

---


<!-- _class: white-text -->

![bg contain](../images/linq-gateway.png)

---

# My Story

* 1990 - Started programming - QBasic, Pascal
* 1991 - Learned C++ - Was ❤️❤️❤️ about OOP
* 1996 - Got first job writing a Windows 95 app Visual C++ / MFC - ❤️❤️❤️

---

# 2006

* Was a web-developer
* Still loved OOP, Design Patterns, etc.
* Was super productive with SQL Server and loved writing stored-procedures
* Front-end - Had been building DHTML/AJAX apps without frameworks for 6 years
*  Friend introduced me to jQuery, lambdas, declarative/functional programming
* LINQ was previewed ❤️❤️❤️

---

# 2007

* LINQ was released in .NET 3.5 - I was hooked
* Got a new job & convinced them to let me use LINQ
* Wanted to know how it worked, learned about expression trees and things called monads
* What is this F# thing? 🤔

---

# 2007-2011

* I was a C# developer LINQifying everything
   * Upgrading old apps to .NET 3.5 and code golfing with LINQ
   * Wrote a LINQ Parser (Monadic Parser), Lazy LINQ, Linq Validation, etc. etc.
   * Was trying to invent my own RX.NET (It was terrible)
* Started learning F# - But my heart was still with C#
* Erik Meijer previews Reactive Extensions (RX) at PDC 2009 😲
* F# was open sourced in 2010
* And then NYC F# Meetup Group started in 2011...

---

# I Found My People

They understood me!

![bg right:66%](../images/bee-girl.jpeg)

---

![bg left:66%](../images/a-whole-new-world.jpeg)

# F# was Going to Change Everything!

---

# I Started Writing F# at Work!

---

![bg](../images/happy-work.jpeg)

---

Meanwhile...

---

# Jet.com is Born

* Taking on Amazon!
* Built with F#!
* Many F# jobs!
* Many F# talks!

![bg left:66%](../images/jet.jpeg)

---

# Walmart Buys Jet.com

* F# jobs start disappearing in NYC
* F# talks stop happening
* Still popular in Europe!

![bg contain right:50%](../images/walmart-jet.jpeg)

---

# Here We Are Today

* F# is still awesome!
* Maybe it's not taking over the world
* But it has changed the world and has **directly** influenced TypeScript, JavaScript, C#, and more  (Async/Await, LINQ, etc.)
* It has quite literally influenced the designs of Swift, Kotlin, and Rust
* And it will continue to lend its ideas to other languages
* You will continue to get language features from F# in other languages for years to come for one big reason...

---

# The Ergonomics

* The study of people's efficiency in their working environment
* The goal is to reduce effort and increase efficiency
* In programming, this means reducing:
   * Reducing bugs
   * Reducing cognitive load
   * Improving understanding
   * Faster feedback loops
   * What else?

---

![bg contain right:40%](../images/bunch-of-things.png)

# This is why F# has Features like:
   * Static typing
   * Module Scoped Type inference (Not just function scoped)
   * Higher-order functions
   * Currying & Partial Application
   * Pattern matching / Active Patterns
   * REPLs / Interactive environments
   * Domain Specific Languages (DSLs)
   * Bridging OOP and FP

---

# But to understand why, we need to go back to the beginning...

[We need to talk about ML](../topics/ml.md)

---

# Play Time!


1. [Chalking up Ideas with Types](../topics/chalking-ideas.md)
2. [A Functional First Language](../topics/functional-first.md)
3. [An Object-Oriented Language](../topics/object-oriented.fsx)

---


# Conclusion

* ML was designed to be a language to describe and transform mathematical objects and proofs.  **It was designed to be trusted.**
* F# was designed to be a language that was ergonomic for developers.
   * It provides a powerful core functional language (ML) that's design with rigor and precision of thought first.
   * It's designed to bridge the gap between functional and object-oriented programming coherently.
* **It's designed to build production software - Not just mathy code**

---

# Thank You!

## F# Learning Resources

* [F# for Fun and Profit](https://fsharpforfunandprofit.com/) - Scott Wlaschin's site is the best place to start learning F#
* [F# Weekly](https://sergeytihon.com/) - Sergey Tihon will keep you up to date on all things F#
* [https://fsharp.org/](https://fsharp.org/) - The F# Software Foundation

## Hit Me Up

* Steve Goguen
* Email: first-initial+last-name@gmail.com