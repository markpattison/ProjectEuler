module ProjectEuler.EulerFSharp.Util

type EulerFSharpType() = member _x.x = 1

let dataPath =
    let path = System.Environment.GetEnvironmentVariable "EulerData"
    match path with
    | null | "" ->
        let codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase
        let uri = new System.UriBuilder(codeBase)
        let assemblyPath = System.Uri.UnescapeDataString uri.Path
        let assemblyDir = System.IO.Path.GetDirectoryName assemblyPath
        let data = System.IO.Path.Combine(assemblyDir, @"..\..\..\Data")
        data
    | _ -> path

