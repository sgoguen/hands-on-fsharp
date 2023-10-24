---
marp: true
theme: presentation


---

# Features Adopted from F# in C#

<!-- _class: lead -->

# THE LEADING HEADER


---

<!-- class: invert -->

# Features Adopted

1. **Pattern Matching**: Simplifies complex conditional logic.
2. **Tuple Types**: Group multiple values together.
3. **Immutable Data Structures**: Promotes immutability in data structures.
4. **Async and Await**: Simplifies asynchronous programming.
5. **Type Inference**: Reduces verbosity in code.
6. **Records**: Immutable data structures.
7. **Discriminated Unions**: Define types with fixed cases.
8. **Deconstructors**: Decompose custom types.
9. **Pipelines**: Functional data transformation.
10. **Type Providers**: Generate types from data sources.
11. **Interoperability**: Better compatibility with functional libraries.
12. **Local Functions**: Define nested functions.
13. **Value-based Equality**: Improve value-based equality.

---

## Pattern Matching

<!-- class: two-columns -->

- CSharp
- FSharp
- ```csharp
  int result = input switch
  {
      1 => 10,
      2 => 20,
      _ => 0
  };
  ```
- ```fsharp
  let result =
      match input with
      | 1 -> 10
      | 2 -> 20
      | _ -> 0
  ```

1. Both are expression based
2. Both support guards
3. Both support deconstruction
4. Both support tuples

<!-- _note: 
These are your speaker notes for this slide. 
They won't be visible on the slide itself, but you can see them while presenting. -->


---


<!-- _class: two-columns -->

# Comparing F# and C# Functions 


* ```fsharp
  let add x y = x + y
  ```
* ```csharp
  int add(int x, int y) => x + y;
  ```

---


## Benefits

- Enhanced expressiveness.
- Reduced boilerplate code.
- More concise and maintainable code.
