(*
    We need a function that can transform a string into a number. What ways of achieving this do you know?
    taken from: https://www.codewars.com/kata/convert-a-string-to-a-number/train/fsharp
*)

// let stringToNumber = int

// let n = "12345" |> stringToNumber

open System
open System.Globalization

let stringToNumber (str:string) =
    let toNumber text = 
        let sum, _ = text
                     |> Seq.rev
                     |> Seq.takeWhile Char.IsDigit
                     |> Seq.map string   // toString, because char |> int gives us the ascii code which we don't want
                     |> Seq.fold(fun (sum, factor) c -> (sum + (c |> int) * factor), factor * 10) (0, 1)
        sum

    let numberParts = str.Split([|CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator|], StringSplitOptions.RemoveEmptyEntries)
    let number = match numberParts with
                 |[|f|] -> float(toNumber f)
                 |[|f;s|] -> 
                    let factor = pown 10. ((s |> Seq.length) * (-1))
                    float(toNumber f) + (factor * float(toNumber s))
                 |_ -> 0.


    match str |> Seq.head with
    |'-' -> number * (-1.)
    |_ -> number

let n = "-123,45" |> stringToNumber