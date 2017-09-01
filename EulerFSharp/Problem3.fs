module ProjectEuler.EulerFSharp.Problem3

let primeFactors (n: int64) =
    let rec getNextPrimeFactor factors next remaining =
        match remaining with
            | 1L -> factors
            | _ ->
            match (remaining % next) with
                | 0L -> getNextPrimeFactor (next :: factors) next (remaining / next)
                | _ -> getNextPrimeFactor factors (next + 1L) remaining
    getNextPrimeFactor [] 2L n

let solution =
    600851475143L
    |> primeFactors
    |> List.max


