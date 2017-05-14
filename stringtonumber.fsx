(*
    We need a function that can transform a string into a number. What ways of achieving this do you know?
    taken from: https://www.codewars.com/kata/convert-a-string-to-a-number/train/fsharp
*)

// let stringToNumber = int

// let n = "12345" |> stringToNumber

open System

let stringToNumber str =
    let number, _ = str
                    |> Seq.rev
                    |> Seq.takeWhile Char.IsDigit
                    |> Seq.map string   // toString, because char |> int gives us the ascii code which we don't want
                    |> Seq.fold(fun (sum, factor) c -> (sum + (c |> int) * factor), factor * 10) (0, 1)
    
    match str |> Seq.head with
    |'-' -> number * (-1)
    |_ -> number

let n = "-1235" |> stringToNumber