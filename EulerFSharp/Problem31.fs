module ProjectEuler.EulerFSharp.Problem31

let rec coinCombinations (coins : int list) value =
    match value with
    | 0 -> 1
    | _ ->    
        match coins with
        | [] -> 0
        | [a] -> if value % a = 0 then 1 else 0
        | a :: t ->
            if a > value then
                coinCombinations t value
            else
                let maxBiggest = value / a in
                let possibleBiggest = [ 0 .. maxBiggest ] in
                let possibleValues = List.map (fun x -> value - x*a) possibleBiggest in
                let possibleCombinations = List.map (coinCombinations t) possibleValues in
                List.sum possibleCombinations

let solution = coinCombinations [ 1; 2; 5; 10; 20; 50; 100; 200 ] 200