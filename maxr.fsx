(*
    Write funcion maxR which returns maximum value of a given List Try no to cheat and provide recursive solution.

    taken from https://www.codewars.com/kata/57a8873cbb99449e300000ba/train/fsharp
*)

let maxR list =
    let rec getmax (max, ns) =
        match ns with
        |e when Seq.isEmpty e -> max
        |_ -> match ns |> Seq.head with
              |m when m > max -> getmax (m, ns |> Seq.skip 1)
              |_ -> getmax (max, ns |> Seq.skip 1)

    getmax ((list |> Seq.head), list)

let m1 = maxR [1;2;51;8;3;9]