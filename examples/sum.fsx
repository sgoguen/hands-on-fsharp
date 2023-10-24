
// let add x y = x + y
// let addTuple(x, y) = x + y
// let add2 = add 2

// let sum (items: int[]) =
//   let mutable result = 0
//   for item in items do
//     result <- result + item
//   result

// let sumInit initialValue (items: int[]) =
//   let mutable result = initialValue
//   for item in items do
//     result <- result + item
//   result

// let fold f initialValue items =
//   let mutable result = initialValue
//   for item in items do
//     result <- f result item
//   result 

// let sum = fold (+) 0
// let sum2 = fold add 0
// let sum3 = fold (fun x y -> x + y) 0
// let product = fold (*) 0
// let sumInit = fold (+)