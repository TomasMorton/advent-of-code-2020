module DayTwo.PartOne

type PasswordValidation = {
    Range: int * int
    RestrictedCharacter: char
    Password: string
}

let split (separator:string) (s:string) =
    s.Split separator

//Format: x-y
let getRange s =
    let values = split "-" s
    (int values.[0], int values.[1])

//Format: c:
let getLetter (s:string) =
    s.TrimEnd(':')
    |> char

let parse s =
     let values = split " " s
     let range = getRange values.[0]
     let letter = getLetter values.[1]
     let password = values.[2]
     
     {Range=range; RestrictedCharacter=letter; Password=password}

let isValidPassword (validation:PasswordValidation) =
    let numberOfMatchingChars =
        validation.Password
        |> Seq.filter (fun c -> c = validation.RestrictedCharacter)
        |> Seq.length
        
    fst validation.Range <= numberOfMatchingChars  && numberOfMatchingChars <= snd validation.Range

let numberOfValidPasswords input =
    let validPasswords =
        input
        |> Seq.map parse
        |> Seq.filter isValidPassword
    
    Seq.length validPasswords