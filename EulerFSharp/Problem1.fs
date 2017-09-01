module ProjectEuler.EulerFSharp.Problem1

let solution =
    let numbers = [1 .. 999]
    let filter x =
        (x % 3 = 0) || (x % 5 = 0)
    numbers |> List.filter filter |> List.sum