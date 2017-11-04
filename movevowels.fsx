(*
Given a string as input, move all of its vowels to the end of the string, in the same order as they were before.

Vowels are (in this kata): a, e, i, o, u

Note: all provided input strings are lowercase.

Examples

"day"    ==>  "dya"
"apple"  ==>  "pplae"

taken from: https://www.codewars.com/kata/56bf3287b5106eb10f000899/train/fsharp

*)

open System
let moveVowel(input:string) = 

    let isVowel c =
        ['a';'e';'i';'o';'u'] |> Seq.exists(fun v -> v = c)

    let consonants = input |> String.filter(isVowel >> not)
    let vowels = input |> String.filter(isVowel)

    sprintf "%s%s" consonants vowels

let result = moveVowel("day")
printfn "%s" result