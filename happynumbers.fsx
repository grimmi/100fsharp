(*
    **Happy Numbers** - 
    A happy number is defined by the following process. 
    Starting with any positive integer, replace the number by the sum of the squares of its digits, 
    and repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1. 
    Those numbers for which this process ends in 1 are happy numbers, while those that do not end in 1 are unhappy numbers. 
    Display an example of your output here. Find first 8 happy numbers.
*)

let sumofsquareddigits number =
    number
    |> string
    |> Seq.fold(fun sum n -> sum + (pown (int n - int '0') 2)) 0

let ishappy n =
    let rec ishappynumber x ns =
        match sumofsquareddigits x with
        | n when ns |> Seq.contains n -> false
        | 1 -> true
        | n -> (ns |> List.append [n]) |> ishappynumber n
    
    [] |> ishappynumber n

Seq.initInfinite id
|> Seq.map(fun idx -> (idx,  ishappy idx))
|> Seq.filter(fun (n, happy) -> happy)
|> Seq.map(fun (n, happy) -> n)
|> Seq.take 8
|> Seq.iter(fun n -> printfn "%d" n)