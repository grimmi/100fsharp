(*
    Rotate for a Max
    Take a number: 56789. Rotate left, you get 67895.
    Keep the first digit in place and rotate left the other digits: 68957.
    Keep the first two digits in place and rotate the other ones: 68579.
    Keep the first three digits and rotate left the rest: 68597. Now it is over since keeping the first four it remains only one digit which rotated is itself.
    You have the following sequence of numbers:
    56789 -> 67895 -> 68957 -> 68579 -> 68597
    and you must return the greatest: 68957.

    taken from: https://www.codewars.com/kata/56a4872cbb65f3a610000026/train/fsharp
*)

let maxRot (n:int) =
    // we're treating all numbers as string so as to not having to specially handle numbers
    // that start with 0
    let rot shift number = 
        let keep, mix = (number |> Seq.take shift, number |> Seq.skip shift)
        let combined = Seq.concat [keep;  mix |> Seq.skip 1; seq { yield (mix |> Seq.head) }]
                       |> Seq.map (string)
                       |> String.concat ""
        printfn "combined: %s" combined
        combined

    let length = (n |> string |> String.length) - 1
    
    [ 0 .. length ]
    |> Seq.fold(fun ns idx -> ns |> List.append [rot idx (ns |> List.head)]) [n|>string]
    |> Seq.map (int)
    |> Seq.max    

let m = maxRot 56789