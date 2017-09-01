module ProjectEuler.EulerFSharp.Problem2

let fibonacciUpTo max =
    let nextFib (state: int * int * int list) =
        let a, b, fibs = state
        let next = a + b
        match next with
            | x when x > max -> None
            | x -> Some (next, (b, x, x :: fibs))
    Seq.unfold nextFib (1, 1, [1; 1])

let solution =
    4000000
    |> fibonacciUpTo
    |> Seq.filter (fun x -> x % 2 = 0)
    |> Seq.sum


