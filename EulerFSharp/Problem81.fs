module ProjectEuler.EulerFSharp.Problem81

open System
open System.IO

let readLines (filePath:string) =
    seq {
    use sr = new StreamReader (filePath)
    while not sr.EndOfStream do
        yield sr.ReadLine ()
    }

let matrixValues (lines: string seq) (size: int) =
    let values : int[,] = Array2D.zeroCreate size size
    for row = 0 to size-1 do
        let line = Seq.item row lines
        let lineValues = line.Split(',')
        for column = 0 to size-1 do
            values.[row, column] <- Int32.Parse(lineValues.[column])
    values

let minPaths (matrix: int[,]) (size: int) =
    let maxRow = size-1
    let maxColumn = size-1
    let minPaths : int[,] = Array2D.zeroCreate size size
    for row = size-1 downto 0 do
        for column = size-1 downto 0 do
            let matrixValue = matrix.[row, column]
            minPaths.[row, column] <-
                match (row, column) with
                | (r, c) when r = maxRow && c = maxColumn -> matrixValue
                | (r, c) when r = maxRow -> matrixValue + minPaths.[row, column+1]
                | (r, c) when c = maxColumn -> matrixValue + minPaths.[row+1, column]
                | (r, c) -> matrixValue + min minPaths.[row, column+1] minPaths.[row+1, column]
    minPaths

let solution =
    let size = 80
    let lines = readLines (Util.dataPath + @"\matrix.txt")
    let matrix = matrixValues lines size
    let minPaths = minPaths matrix size
    minPaths.[0,0]



