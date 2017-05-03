(*
    Write a function last that accepts a list and returns the last element in the list
    If the list is empty:
        In languages that have a built-in option or result type (like OCaml or Haskell),
        return an empty option
        In languages that do not have an empty option, just return null

        taken from: https://www.codewars.com/kata/99-problems-number-1-last-in-list/train/fsharp
*)

let last xs = 
    match xs with
    |[] -> None
    |_ -> xs |> Seq.last |> Some

let x = [1;2;3]
let lx = x |> last