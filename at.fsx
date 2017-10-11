(*
    Write a function that accepts a number k and a list and returns the kth element in that list.

    If there is no kth element in the list, return either null or None, depending on the language you're using.
*)

let at k list = 
  match list with
  |[] -> None
  |_ when k > ((list |> Seq.length) - 1) -> None
  |_ -> Some(list.[k])

let x = [1;2;3] |> at 3