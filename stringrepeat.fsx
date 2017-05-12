(*
    Write a function called repeatStr which repeats the given string string exactly n times.

    repeatStr(6, "I") // "IIIIII"
    repeatStr(5, "Hello") // "HelloHelloHelloHelloHello"

    taken from: https://www.codewars.com/kata/57a0e5c372292dd76d000d7e/train/fsharp
*)

let repeatStr n s = 
    [ 1 .. n ] |> Seq.map(fun x -> s) |> String.concat ""

let x = repeatStr 6 "I"
let h = repeatStr 5 "Hello"