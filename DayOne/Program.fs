open System.IO
open DayOne

let readLines (filePath : string) =
    seq {
        use sr = new StreamReader(filePath)
        while not sr.EndOfStream do
            yield sr.ReadLine()
    }

let executePartOne goal input =
    let (first, second) = PartOne.findPairThatSumsTo goal input
    let product = first * second
    printfn "The product of the two values summing to %d is %d" goal product

let executePartTwo goal input =
    let (first, second, third) = PartTwo.findTripleThatSumsTo goal input
    let product = first * second * third
    printfn "The product of the three values summing to %d is %d" goal product

[<EntryPoint>]
let main argv =
    let goal = 2020

    let input =
        readLines "input.txt"
        |> Seq.map int
        |> Seq.toList

    executePartOne goal input
    executePartTwo goal input
    
    0 // return an integer exit code
