open DayTwo
open Utils

[<EntryPoint>]
let main argv =
    let input =
        Files.readLines "input.txt"
        |> Seq.toList
    
    PartOne.numberOfValidPasswords input
    |> printfn "Number of valid passwords: %d"
    
    PartTwo.numberOfValidPasswords input
    |> printfn "Number of actually valid passwords: %d"
    
    0