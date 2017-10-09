(*
You are given two arrays a1 and a2 of strings. Each string is composed with letters from a to z.
Let x be any string in the first array and y be any string in the second array.

Find max(abs(length(x) − length(y)))

If a1 or a2 are empty return -1 in each language except in Haskell (F#) where you will return Nothing (None).

#Example:

s1 = ["hoqq", "bbllkw", "oox", "ejjuyyy", "plmiis", "xxxzgpsssa", "xxwwkktt", "znnnnfqknaz", "qqquuhii", "dvvvwz"]
s2 = ["cccooommaaqqoxii", "gggqaffhhh", "tttoowwwmmww"]
mxdiflg(s1, s2) --> 13


taken from: https://www.codewars.com/kata/5663f5305102699bad000056/train/fsharp
*)

let mxdiflg(a1: string[]) (a2: string[]) =

    match (a1, a2) with
    |([||], _) | (_, [||]) -> None
    |_ -> a1 
          |> Seq.collect(fun s1 -> a2 |> Seq.map(fun s2 -> (s1, s2)))    
          |> Seq.map(fun (s1, s2) -> abs(s1.Length - s2.Length))
          |> Seq.max |> Some

let s1 = [|"hoqq"; "bbllkw"; "oox"; "ejjuyyy"; "plmiis"; "xxxzgpsssa"; "xxwwkktt"; "znnnnfqknaz"; "qqquuhii"; "dvvvwz"|]
let s2 = [|"cccooommaaqqoxii"; "gggqaffhhh"; "tttoowwwmmww"|]

let maxdiff = mxdiflg s1 s2