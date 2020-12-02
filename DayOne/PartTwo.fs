module DayOne.PartTwo

let findTripleThatSumsTo sum input =
    input
    |> Seq.collect (fun x ->
        input
        |> Seq.collect (fun y ->
            input |> Seq.map (fun z -> x, y, z)))
    |> Seq.find (fun (x, y, z) -> x + y + z = sum)
