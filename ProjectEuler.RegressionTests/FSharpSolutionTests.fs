namespace ProjectEuler.RegressionTests

open FsUnit
open NUnit.Framework

open ProjectEuler.EulerFSharp

[<TestFixture>]
type FSharpSolutions() =

    static member solutions =
        [|
            1,  box 233168
            2,  box 4613732
            3,  box 6857
            21, box 31626
            31, box 73682
            76, box 190569291
            81, box 427337
            85, box 2772
            99, box 709
        |]
        |> Array.map (fun (problem, expected) ->
            let name = sprintf "Problem%i" problem
            let problemType = System.Reflection.Assembly.GetAssembly(typeof<Util.EulerFSharpType>).GetTypes() |> Seq.find (fun t -> t.Name = name)
            let problemMethod = problemType.GetMethods() |> Seq.find (fun m -> m.Name = "get_solution")

            let tcd = new TestCaseData(problemMethod, expected)
            tcd.SetName(sprintf "F# problem %i" problem))

    [<TestCaseSource("solutions")>]
    member _x.test (method: System.Reflection.MethodInfo) expected =
        
        let actual = method.Invoke(null, [||])

        actual |> should equal expected
