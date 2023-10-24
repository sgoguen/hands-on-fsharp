---
marp: true
theme: default
---

# F# Tuples

A brief introduction to tuples in F#.

---

# What is a Tuple?

- A tuple is a simple way to group multiple values.
- It can contain values of different types.
- Defined using parentheses `(` and `)`.

---

# Basic Tuple

```fsharp
let person = ("John", 25)
```

person is a tuple containing a string and an integer.

---

# Tuples with More Than Two Elements

* Tuples can have more than two elements.
* No built-in functions like fst and snd for tuples with more than two elements.


```fsharp
let rgbColor = (255, 0, 0)
```

#
