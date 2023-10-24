type Proposition = 
  | And of Proposition * Proposition
  | Or of Proposition * Proposition
  | Implies of Proposition * Proposition
  | Not of Proposition
  | True
  | False

let rec simplify = function
  | And (True, p) | And (p, True)         -> simplify p
  | And (False, _) | And (_, False)       -> False
  | Or (True, _) | Or (_, True)           -> True
  | Or (False, p) | Or (p, False)         -> simplify p
  | Implies (True, p)                     -> simplify p
  | Implies (_, True)                     -> True
  | Implies (False, _)                    -> True
  | Implies (p, False)                    -> Not (simplify p)
  | Not p                                 -> Not (simplify p)   

//  Let's test it out.  We might find a bug!

let p1 = And (True, False)

//  How about we define some operators to make it easier to write propositions?
let (&&&) p1 p2 = And (p1, p2)
let (|||) p1 p2 = Or (p1, p2)
let (==>) p1 p2 = Implies (p1, p2)

let p2 = True &&& False
let p3 = True ||| False
let p4 = simplify (True &&& False)
let p5 = simplify (True ||| False)
let p6 = simplify (True ||| False ==> False)   // Not True


module Version2 = 


  let rec simplify p = 
    match p with
    | False -> False
    | True -> True
    | And(S(left), S(right)) -> 
        match (left, right) with
        | (False, _) | (_, False) -> False
        | (True, S(p)) | (S(p), True) -> p
        | _ -> And(left, right)
    | Or(S(left), S(right)) -> 
        match (left, right) with
        | (True, _) | (_, True) -> True
        | (False, S(p)) | (S(p), False) -> p
        | _ -> Or(left, right)
    | Implies(S(left), S(right)) -> 
        match (left, right) with
        | (False, _) -> True
        | (_, True) -> True
        | (True, S(p)) -> p
        | (S(p), False) -> (Not(p))
        | _ -> Implies(left, right)
    | Not(S(p)) -> (Not(p))
  and (|S|) = simplify
