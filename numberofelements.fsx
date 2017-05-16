(*
    Problem 4

    Find the number of elements of a list.
    Example in Haskell:
    Prelude> myLength [123, 456, 789]
    3
    Prelude> myLength "Hello, world!"
    13

    taken from: https://wiki.haskell.org/99_questions/1_to_10
*)

let myLength l = 

    let rec loop acc tail =
        match tail with
        |_ when Seq.isEmpty tail -> acc
        |_ -> loop (acc + 1) (tail |> Seq.skip 1)
    loop 0 l

let x = "HelloWorld" |> myLength