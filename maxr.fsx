(*
    Write funcion maxR which returns maximum value of a given List Try no to cheat and provide recursive solution.

    taken from https://www.codewars.com/kata/57a8873cbb99449e300000ba/train/fsharp
*)

let maxR list =
    let rec max mx ns =
        match ns with
        |[] -> mx
        |h::t -> match h with
                 |_ when h > mx -> max h t
                 |_ -> max mx t

    match list with
    |[] -> None
    |_ -> Some(max (list |> List.head) list)

let m0:int option = maxR []
let m1 = maxR [1;2;51;8;3;9]