open System.IO

let readLines (filePath:string) = seq {
    use sr = new StreamReader (filePath)
    while not sr.EndOfStream do
        yield sr.ReadLine ()
}

[<EntryPoint>]
let main argv =
    let goal = 2020
    
    let input =
        readLines "input.txt"
        |> Seq.map int
        |> Seq.toList
    
    Seq.allPairs input input
    |> Seq.find (fun (x, y) -> x + y = goal)
    |> fun (x, y) -> x * y
    |> printfn "%d" 
    0 // return an integer exit code
