(*
    Problem 2 
    Find the last but one element of a list. 
    (Note that the Lisp transcription of this problem is incorrect.) 
    Example in Haskell: 
    Prelude> myButLast [1,2,3,4]
    3
    Prelude> myButLast ['a'..'z']
    'y'

    taken from: https://wiki.haskell.org/99_questions/1_to_10
*)

let myButLast l =

    let rec loop tail =
        match tail with
        |[x;y] -> Some x
        |head::tail -> loop tail
        |_ -> None

    loop (l |> List.ofSeq)

let s = "hello world" |> myButLast