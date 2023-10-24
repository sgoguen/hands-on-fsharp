# Structural Equality

Structural equality in F# refers to the ability to compare values based on their actual content or structure, rather than their references in memory. This is in contrast to reference equality, which checks if two references point to the same object in memory.

### Types that Support Structural Equality

Most of F#'s built-in types support structural equality. These include:

1. **Primitive Types**: Such as `int`, `float`, `char`, `string`, etc.
2. **Tuples**: Combinations of other values.
3. **Records**: Named collections of values.
4. **Lists, Arrays, and Other Collections**: These are compared element by element.
5. **Option Types**: `Some` and `None` values.
6. **Discriminated Unions**: Values of user-defined types.

However, some types, like reference cells (`ref` types) and objects from .NET classes, use reference equality by default.

### Code Examples

1. **Primitive Types**

    ```fsharp
    let a = 5
    let b = 5
    printfn "%b" (a = b)  // Outputs "true"
    ```

2. **Tuples**

    ```fsharp
    let tuple1 = (1, "hello")
    let tuple2 = (1, "hello")
    printfn "%b" (tuple1 = tuple2)  // Outputs "true"
    ```

3. **Records**

    ```fsharp
    type Person = { Name: string; Age: int }
    let person1 = { Name = "Alice"; Age = 30 }
    let person2 = { Name = "Alice"; Age = 30 }
    printfn "%b" (person1 = person2)  // Outputs "true"
    ```

4. **Lists and Arrays**

    ```fsharp
    let list1 = [1; 2; 3]
    let list2 = [1; 2; 3]
    printfn "%b" (list1 = list2)  // Outputs "true"

    let array1 = [|1; 2; 3|]
    let array2 = [|1; 2; 3|]
    printfn "%b" (array1 = array2)  // Outputs "true"
    ```

5. **Option Types**

    ```fsharp
    let value1 = Some 5
    let value2 = Some 5
    printfn "%b" (value1 = value2)  // Outputs "true"
    ```

6. **Discriminated Unions**

    ```fsharp
    type Shape =
        | Circle of float
        | Rectangle of float * float

    let shape1 = Circle 5.0
    let shape2 = Circle 5.0
    printfn "%b" (shape1 = shape2)  // Outputs "true"
    ```

7. Combining Different Types

```fsharp
type Task = 
	Task of completed: bool * description: string

type Role = 
    | Manager
    | Developer
    | Designer

type Employee = {
    Name: string;
    Address: Address;
    CurrentRole: Role;
    Tasks: Task list;
    Supervisor: string option;

let employee1 = {
	Name = "Alice";
	Address = { Street = "123 Main St."; City = "New York"; State = "NY" };
	CurrentRole = Developer;
	Tasks = [Task (true, "Write code")
			 Task (false, "Test code")];
	Supervisor = Some "Bob";
}

let employee2 = {
	Name = "Alice";
	Address = { Street = "123 Main St."; City = "New York"; State = "NY" };
	CurrentRole = Developer;
	Tasks = [Task (true, "Write code")
			 Task (false, "Test code")];
	Supervisor = Some "Bob";
}

printfn "%b" (employee1 = employee2)  // Outputs "true"
```




### Conclusion

Structural equality in F# allows for intuitive comparisons of values based on their content. This is especially useful in functional programming paradigms where immutability and value-based computations are common. However, it's essential to be aware of the types that use reference equality by default and to understand the performance implications of deep structural comparisons, especially for large data structures.