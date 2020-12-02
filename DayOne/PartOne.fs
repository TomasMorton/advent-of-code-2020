module DayOne.PartOne

let findPairThatSumsTo sum input =
    Seq.allPairs input input
    |> Seq.find (fun (x, y) -> x + y = sum)
