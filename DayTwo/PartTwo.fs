module DayTwo.PartTwo

type PasswordValidation = {
    FirstPosition: int
    SecondPosition: int
    MatchingCharacter: char
    Password: string
}

let split (separator:string) (s:string) =
    s.Split separator

//Format: x-y
let getPositions s =
    let convert c = int c - 1
    let values = split "-" s
    
    (convert values.[0], convert values.[1])

//Format: c:
let getLetter (s:string) =
    s.TrimEnd(':')
    |> char

let parse s =
     let values = split " " s
     let (first, second) = getPositions values.[0]
     let letter = getLetter values.[1]
     let password = values.[2]
     
     {FirstPosition=first; SecondPosition=second; MatchingCharacter=letter; Password=password}
     
let isValidPassword (validation:PasswordValidation) =
    let matchesPosition index (s:string) =
        s.[index] = validation.MatchingCharacter
    
    let firstMatch = validation.Password |> matchesPosition validation.FirstPosition
    let secondMatch = validation.Password |> matchesPosition validation.SecondPosition
    firstMatch <> secondMatch

    
let numberOfValidPasswords input =
    let validPasswords =
        input
        |> Seq.map parse
        |> Seq.filter isValidPassword
    
    Seq.length validPasswords