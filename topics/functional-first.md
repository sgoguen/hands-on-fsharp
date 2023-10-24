---
marp: true
---

[Let's play](../examples/sum.fsx)

---

# Currying & Partial Application

--- 

# Currying

Turning functions with multiple arguments into a series of functions that take a single argument

```typescript
function add(x: int, y: int): int {
   return x + y
}
```

Curried

```typescript
function add(x: int) {
   return function(y: int): int {
      return x + y
   }
}
```

* F# and ML are curried by default

---

## Partial Application

When you call a function with fewer arguments than it expects, it returns a function that takes the remaining arguments


```typescript
function add(x: int) {
   return function(y: int): int {
      return x + y
   }
}

const addOne = add(1);
const result = addOne(2); // 3
```

---

## Currying & Partial Application in F#

```fsharp
let add x y = x + y
let addOne = add 1
let result = addOne 2 // 3
```

---

# Using Currying to Incrementally Abstract a Function

Let's define a normal function that add up some integers

```fsharp
let sum list = 
   let mutable result = 0
   for i in list do
      result <- result + i
   result
```

---

# Let's Add a Parameter

We may add an initial value

```fsharp
let sum initalValue list = 
   let mutable result = initalValue
   for i in list do
      result <- result + i
   result
```

---

# Adding a Final Parameter to Make it Generic

* We can pass a function as a parameter
* And turn our "sum" into a higher-order function called fold

```fsharp
let fold f initalValue list = 
   let mutable result = initalValue
   for i in list do
      result <- f result i
   result
```

---

# Partial Application

```fsharp
let add x y = x + y
let sum = fold (+) 0
let sum2 = fold add 0
let sum3 = fold (fun x y -> x + y) 0
let product = fold (*) 0
let stringConcat 
```