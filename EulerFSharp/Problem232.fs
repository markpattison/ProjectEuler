module ProjectEuler.EulerFSharp.Problem232

open System
open System.Collections.Generic

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

let Problem232 a b =
    P1 a b

