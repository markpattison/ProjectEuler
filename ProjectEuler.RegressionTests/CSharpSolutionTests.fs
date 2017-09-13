namespace ProjectEuler.RegressionTests

open FsUnit
open NUnit.Framework

[<TestFixture>]
type CSharpSolutions() =

    static member solutions =
        [|
            1,   box 233168
            2,   box 4613732
            3,   box 6857
            4,   box 906609
            5,   box 232792560
            6,   box 25164150
            7,   box 104743
            8,   box 40824
            9,   box 31875000
            10,  box 142913828922L
            11,  box 70600674
            12,  box 76576500
            13,  box 5537376230L
            14,  box 837799
            15,  box 137846528820L
            16,  box 1366
            17,  box 21124
            18,  box 1074
            19,  box 171
            20,  box 648
            22,  box 871198282
            23,  box 4179871
            24,  box 2783915460L
            25,  box 4782
            26,  box 983
            27,  box -59231
            28,  box 669171001
            29,  box 9183
            30,  box 443839
            32,  box 45228
            33,  box 100
            34,  box 40730
            35,  box 55
            36,  box 872187
            37,  box 748317
            38,  box 932718654
            39,  box 840
            40,  box 210
            41,  box 7652413
            42,  box 162
            43,  box 16695334890L
            44,  box 5482660
            45,  box 1533776805
            46,  box 5777
            47,  box 134043
            48,  box 9110846700L
            49,  box 296962999629L
            50,  box 997651
            51,  box 121313
            52,  box 142857
            53,  box 4075
            54,  box 376
            55,  box 249
            56,  box 972
            57,  box 153
            59,  box 107359
            63,  box 49
            65,  box 272
            67,  box 7273
            69,  box 510510
            70,  box 8319823
            72,  box 303963552391L
            74,  box 402
            79,  box 73162890
            89,  box 743
            92,  box 8581146
            97,  box 8739992577L
            112, box 1587000
            144, box 354
            202, box 1209002624
            206, box 1389019170
            235, box 1.002322108633
            243, box 892371480
        |]
        |> Array.map (fun (problem, expected) ->
            let name = sprintf "Problem%i" problem
            let problemType = System.Reflection.Assembly.GetAssembly(typeof<ProjectEuler.EulerCSharp.Problems>).GetTypes() |> Seq.find (fun t -> t.Name = "Problems")
            let problemMethod = problemType.GetMethods() |> Seq.find (fun m -> m.Name = name)

            let tcd = new TestCaseData(problemMethod, expected)
            tcd.SetName(sprintf "C# problem %i" problem))

    [<TestCaseSource("solutions")>]
    member _x.test (method: System.Reflection.MethodInfo) expected =
        
        let problems = new ProjectEuler.EulerCSharp.Problems()

        let actual = method.Invoke(problems, [||])

        actual |> should equal expected
