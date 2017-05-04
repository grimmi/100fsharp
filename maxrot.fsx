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

let maxrot (n:int) =
    let rot (x:int) (n:int) = 
        let s = n |> string

        let keep = s |> Seq.take x

        let mix = s 
                    |> Seq.skip x
                    |> Seq.mapi(fun idx t -> match idx with
                                             |0 -> (999, t |> string)
                                             |_ -> (idx, t |> string))
                    |> Seq.sortBy(fun (idx,t) -> idx)
                    |> Seq.map(fun (idx, t) -> t)
                    |> String.concat ""

        let combine = (keep |> Seq.map (string) |> String.concat "") + mix
        combine |> int

    let length = (n |> string |> String.length) - 1
    let numbers = 
        [ 0 .. length ]
        |> Seq.fold(fun (ns:int list) (idx:int) -> 
                                let (x:int) = rot idx (ns |> List.head)
                                ns |> List.append [x]) [n]

    numbers |> Seq.max


let m = maxrot 38458215
