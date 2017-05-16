(*
     Problem 3

    Find the K'th element of a list. The first element in the list is number 1.
    Example:
    * (element-at '(a b c d e) 3)
    c
    Example in Haskell:
    Prelude> elementAt [1,2,3] 2
    2
    Prelude> elementAt "haskell" 5
    'e'

    taken from: https://wiki.haskell.org/99_questions/1_to_10
*)

let elementAt x l = 
    let s = l
            |> Seq.mapi(fun idx e -> (idx + 1, e))
            |> Seq.skipWhile(fun (idx, e) -> idx < x)
    match s with
    |_ when s |> Seq.isEmpty -> None
    |_ -> let (idx, el) = s |> Seq.head
          Some el

let e = elementAt 3 [1;2;3]