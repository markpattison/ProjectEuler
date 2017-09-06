module ProjectEuler.EulerFSharp.Problem76

open System.Collections.Generic

let Problem76 n =
    let cache = Dictionary<_, _>()
    let rec numberOfSummations (n, max) =
        match (n, max) with
        | (0, _) -> 1
        | (1, _) -> 1
        | (_, 1) -> 1
        | _ ->
            if cache.ContainsKey(n, max) then
                cache.[(n, max)]
            else
                let upTo = min n max
                let res = [1 .. upTo] |> List.map (fun x -> numberOfSummations (n - x, min x (n - x))) |> List.sum
                cache.[(n, max)] <- res
                res

    numberOfSummations (n, n - 1)

let solution = Problem76 100

