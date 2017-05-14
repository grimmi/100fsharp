(*
    Write funcion maxR which returns maximum value of a given List Try no to cheat and provide recursive solution.

    taken from https://www.codewars.com/kata/57a8873cbb99449e300000ba/train/fsharp
*)

let maxR list =
    let rec max mx (ns: 'a seq) =
        match ns with
        |_ when ns |> Seq.isEmpty -> mx
        |_ -> match ns |> Seq.head with
                 |h when h > mx -> max h (ns |> Seq.skip 1)
                 |_ -> max mx (ns |> Seq.skip 1)

    match list with
    |_ when list |> Seq.isEmpty -> None
    |_ -> Some(max (list |> Seq.head) list)

let m0:int option = maxR []
let m1 = maxR [1;2;51;8;3;9]

let m2 = maxR [|4;5;5;6;|]