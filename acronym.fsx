(*
    Write function toAcronym which takes a string and make an acronym of it.

    Rule of making acronym in this kata:

    split string to words by space char
    take every first letter from word in given string
    uppercase it
    join them toghether

    Eg:

    Code wars -> C, w -> C W -> CW

    taken from: https://www.codewars.com/kata/make-acronym/train/fsharp
*)

open System

let toAcronym (s:string) =
    s.Split ' '
    |> Seq.map (Seq.head >> Char.ToUpper >> string)
    |> String.concat ""