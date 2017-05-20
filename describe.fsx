(*
    Write function describeList which tells if the list is empty or contains only one element or more.

    taken from: https://www.codewars.com/kata/57a4a3e653ba3346bc000810/train/fsharp
*)

let describeList list = 
    match list with
    |[] -> "empty"
    |[x] -> "singleton"
    |_ -> "longer"