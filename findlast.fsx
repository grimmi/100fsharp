(*
    Problem 1 
    Find the last element of a list. 
    (Note that the Lisp transcription of this problem is incorrect.) 
    Example in Haskell: 
    Prelude> myLast [1,2,3,4]
    4
    Prelude> myLast ['x','y','z']
    'z'
    taken from: https://wiki.haskell.org/99_questions/1_to_10
*)

let myLast l = 

    let rec loop tail =
        match tail with
        |_ when tail |> Seq.length = 1 -> Some(tail |> Seq.head)
        |head::tail -> loop tail
        |_ -> None
    
    loop l

let last = [1;2;3;4;] |> myLast