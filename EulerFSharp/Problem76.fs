module ProjectEuler.EulerFSharp.Problem76

open System.Collections.Generic

// slow

let memoize f =
    let cache = Dictionary<_, _>()
    fun x ->
        if cache.ContainsKey(x) then cache.[x]
        else let res = f x
             cache.[x] <- res
             res

let rec numberOfSummations (n, max) =
    match (n, max) with
    | (0, _) -> 1
    | (1, _) -> 1
    | (m, 1) -> 1
    | _ ->
        let upTo = min n max
        [1 .. upTo] |> List.map (fun x -> numberOfSummations (n - x, x)) |> List.sum

let Problem76 n =
    let memoized = memoize numberOfSummations
    memoized (n, n - 1)

let solution = Problem76 100

