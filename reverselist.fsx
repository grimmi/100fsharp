(*
    Write a function that reverses a list, without using any built-in reverse functions.

    taken from: https://www.codewars.com/kata/57d993083c3f960c71000005/train/fsharp
*)

let rev (list : int list) = 
    list
    |> Seq.fold(fun rev n -> n :: rev) []

let r = [1;2;3] |> rev