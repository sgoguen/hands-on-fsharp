#nowarn "3391"

//////////////////////////////////////////////////////////////////
// Union types
//////////////////////////////////////////////////////////////////

type BinaryOp = And | Or | Implies

type Proposition = 
    | Value of bool
    | Not of Proposition
    | And of Proposition * Proposition
    | Or of Proposition * Proposition
    | Implies of Proposition * Proposition

let example1 = And(Value(true), Value(false))





//////////////////////////////////////////////////////////////////
// Functions and Pattern Matching
//////////////////////////////////////////////////////////////////
let rec eval (p:Proposition) = 
    match p with
    | Value(v)               -> v
    | Not(p)                -> not (eval p)
    | And(left, right)      -> eval left && eval right
    | Or(left, right)       -> eval left || eval right
    | Implies(left, right)  -> not (eval left) || eval right

let evaluated = eval example1


//////////////////////////////////////////////////////////////////
// Define Operators
//////////////////////////////////////////////////////////////////

let (&&&) left right = And(left, right)
let (|||) left right = Or(left, right)
let (==>) left right = Implies(left, right)
let (~~~) p = Not(p)

let example2 = Value(true) &&& Value(false) ||| Value(true) &&& Value(true) ==> Value(false)


//////////////////////////////////////////////////////////////////
// Implicit Conversion (F# Only)
//////////////////////////////////////////////////////////////////
type Proposition with
    //  Implicit conversion from bool to Proposition
    static member inline op_Implicit (v:bool) = Value(v)

let example3 = Value(true) &&& false ||| true &&& true ==> false
