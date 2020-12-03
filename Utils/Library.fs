namespace Utils

open System.IO

module Files =
    let readLines (filePath : string) =
        seq {
            use sr = new StreamReader(filePath)
            while not sr.EndOfStream do
                yield sr.ReadLine()
        }
