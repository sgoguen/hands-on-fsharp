// Union types - Powerful way to represent data that can be of multiple forms

type LogicSymbol = 
    | And 
    | Or 
    | Not 
    | Implies

type Proposition = 
    | Value of bool
    | Var of string
    | Operator of LogicSymbol * Proposition * Proposition


let example1 = Operator(And, Value(true), Value(false))

// We can write a function to symbolically evaluate the expression
let rec eval (p:Proposition) = 
    match p with
    | Value(v) -> v
    // | Var(_) -> failwith "Cannot evaluate a variable"
    | Operator(And, left, right) -> eval left && eval right
    | Operator(Or, left, right) -> eval left || eval right
    | Operator(Not, left, right) -> not (eval left)
    | Operator(Implies, left, right) -> not (eval left) || eval right