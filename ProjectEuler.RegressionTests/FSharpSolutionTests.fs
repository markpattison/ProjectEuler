namespace ProjectEuler.RegressionTests

open FsUnit
open NUnit.Framework

open ProjectEuler.EulerFSharp

[<TestFixture>]
type FSharpSolutions() =

    [<Test>]
    member _x.problem1 () = Problem1.solution |> should equal 233168

    [<Test>]
    member _x.problem2 () = Problem2.solution |> should equal 4613732

    [<Test>]
    member _x.problem3 () = Problem3.solution |> should equal 6857

    [<Test>]
    member _x.problem21 () = Problem21.solution |> should equal 31626

    [<Test>]
    member _x.problem31 () = Problem31.solution |> should equal 73682

    [<Test>]
    member _x.problem76 () = Problem76.solution |> should equal 190569291

    [<Test>]
    member _x.problem81 () = Problem81.solution |> should equal 427337

    [<Test>]
    member _x.problem85 () = Problem85.solution |> should equal 2772

    [<Test>]
    member _x.problem99 () = Problem99.solution |> should equal 709
