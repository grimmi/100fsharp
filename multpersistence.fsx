(*
Write a function, persistence, that takes in a positive parameter num and returns its multiplicative persistence, which is the number of times you must multiply the digits in num until you reach a single digit.

For example:

persistence 39 = 3  // because 3*9 = 27, 2*7 = 14, 1*4=4
                    // and 4 has only one digit

persistence 999 = 4 // because 9*9*9 = 729, 7*2*9 = 126,
                    // 1*2*6 = 12, and finally 1*2 = 2

persistence 4 = 0   // because 4 is already a one-digit number

taken from: https://www.codewars.com/kata/persistent-bugger/train/fsharp

*)


let persistence n =
    let input = n |> string
    let product (s:string) =
        (s |> Seq.fold(fun c x -> c * (x |> string |> int)) 1) |> string

    if String.length input = 1 then 0
    else
        let rec per input =
            match product input with
            |prod when String.length prod = 1 -> 1
            |prod -> 1 + per prod 
        
        per input


printfn "product: %d" (persistence "4")