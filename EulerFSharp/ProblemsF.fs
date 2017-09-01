
module ProjectEuler.EulerFSharp.Rubbish

open System
open System.Collections.Generic

let dataPath = @"E:\prog\Visual Studio 2010\Projects\ProjectEuler\EulerCSharp\Data"

let rec EP31 (coins : int list) value =
    match value with
    | 0 -> 1
    | _ ->    
        match coins with
        | [] -> 0
        | [a] -> if value % a = 0 then 1 else 0
        | a :: t ->
            if a > value then
                EP31 t value
            else
                let maxBiggest = value / a in
                let possibleBiggest = [ 0 .. maxBiggest ] in
                let possibleValues = List.map (fun x -> value - x*a) possibleBiggest in
                let possibleCombinations = List.map (EP31 t) possibleValues in
                List.fold (+) 0 possibleCombinations

let EulerProblem31 value = EP31 [200; 100; 50; 20; 10; 5; 2; 1] value



let Divisors n = 
    match n with
    | x when x < 1 -> failwith "n must be greater than 1"
    | 2 -> [1]
    | _ ->
        List.filter (fun x -> n % x = 0) [ 1 .. n-1 ]

let SumDivisors n = 
    List.fold (+) 0 (Divisors n)

let IsAmicable n =
    let sd = SumDivisors n in
    let sdsd = SumDivisors sd in
    n = sdsd && n <> sd

let EulerProblem21 max =
    let amicables = List.filter (IsAmicable) [ 2 .. max ] in
    List.fold (+) 0 amicables
    
// EulerProblem232

let memoizeWithDictionary f =
  let cache = Dictionary<_, _>()
  fun x ->
    let (found,result) = cache.TryGetValue(x)
    if found then
      result
    else
      let res = f x
      cache.[x] <- res
      res
      
let PowerOfTwo n =
    match n with
    | 0 -> 1
    | 1 -> 2
    | 2 -> 4
    | 3 -> 8
    | 4 -> 16
    | 5 -> 32
    | 6 -> 64
    | _ -> 0
    
    
let rec P1 a b =
    match (a, b) with
    | (x, _) when x >= 100 -> 0.0
    | (_, y) when y >= 100 -> 1.0
    | (x, y) -> 0.5 * P2 (a + 1) b + 0.5 * P2 a b
    
and tryP2 a b c =
    match (a, b) with
    | (x, _) when x >= 100 -> 0.0
    | (_, y) when y >= 100 -> 1.0
    | (x, y) -> (P1 a (b +  PowerOfTwo (c - 1)) * 1.0 / float (PowerOfTwo c) + 0.5 * (1.0 - 1.0 / float (PowerOfTwo c)) * P2 (a+1) b) / (1.0 - 0.5 * (1.0 - 1.0 / float (PowerOfTwo c)))

and P2 a b =
    tryP2 a b (T a b)

and T a b =
    let possibles = [1; 2; 3; 4; 5; 6] in
    let results = List.map (fun x -> (x, tryP2 a b x)) possibles in
    let best = List.sortWith (fun (p,q) (r,s) -> compare s q) results in
    let choice = List.head best in
    let first (x,y) = x in
    first choice

and fP1 = P1 |> memoizeWithDictionary
and fP2 = P2 |> memoizeWithDictionary
and ftryP2 = tryP2 |> memoizeWithDictionary
and fT = T |> memoizeWithDictionary

let EulerProblem232 a b =
    P1 a b



let IsPerfect n =
    n = SumDivisors n

let IsAbundant n =
    n < SumDivisors n

let AbundantNumbers upto =
    List.filter (IsAbundant) [ 1 .. upto ]

//let IsSumOfTwoAbundantNumbers n =
    //match n with
    //| x when x < 24 -> false
    //| x when x > 28123 -> true
    //| _ ->
        
        
        