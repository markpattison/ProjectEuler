module ProjectEuler.EulerFSharp.Problem21

let divisors n = 
    match n with
    | x when x < 1 -> failwith "n must be greater than 1"
    | 2 -> [1]
    | _ ->
        List.filter (fun x -> n % x = 0) [ 1 .. n-1 ]

let sumDivisors n =
    n
    |> divisors
    |> List.sum

let isAmicable n =
    let sd = sumDivisors n in
    let sdsd = sumDivisors sd in
    n = sdsd && n <> sd

let problem21 max =
    List.filter isAmicable [ 2 .. max ]
    |> List.sum

let solution = problem21 10000

