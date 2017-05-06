(*
    List Replication
    Given a list, repeat each element in the list amount of times. 

    taken from: https://www.hackerrank.com/challenges/fp-list-replication
*)

(*
    input code for hackerrank:
    let inputs = 
        Seq.initInfinite (fun _ -> System.Console.ReadLine())
        |> Seq.takeWhile (fun s -> s <> null)
        |> Seq.map int
        |> List.ofSeq
    let s, xs = List.head inputs, List.tail inputs

    repeatList xs s
*)
let repeatList list n = 
    list
    |> Seq.iter(fun x -> [ 1 .. n]
                         |> Seq.iter(fun _ -> printfn "%d" x))

let r = repeatList [1;2;3] 4