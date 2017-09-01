module ProjectEuler.EulerFSharp.Problem99

open System
open System.IO

let readLines (filePath:string) =
    seq {
    use sr = new StreamReader (filePath)
    while not sr.EndOfStream do
        yield sr.ReadLine ()
    }

let solution =
    let lines = readLines (Util.dataPath + @"\base_exp.txt")
    let lineToBaseExpN n (s: string) =
        let values = s.Split(',')
        (Int32.Parse(values.[0]), Int32.Parse(values.[1]), n+1)
    let baseExp = Seq.mapi lineToBaseExpN lines
    let size (baseValue, expValue, n) = (float expValue) * log (float baseValue)
    let (_, _, biggest) = Seq.maxBy size baseExp
    biggest



