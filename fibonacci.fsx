(*
Fibonacci Sequence - Enter a number and have the program generate the Fibonacci sequence to that number or to the Nth number.
*)

open System
open System.Collections.Generic

let cache = Dictionary<int64,int64>()
cache.Add(0L, 1L)
cache.Add(1L, 1L)
cache.Add(2L, 1L)

let rec fib x = 
    let cached = cache.TryGetValue x
    match cached with
    | true, v ->
        printfn "got cached result: %d" v
        v
    | false, _ -> 
        let computed = 
            match x with
            | 0L | 1L | 2L -> 1L
            | _ -> fib (x-1L) + fib (x-2L) 
        printfn "computed new value: %d" computed
        cache.Add(x, computed)
        computed

let numbers =
    [ 1L .. 75L ]
    |> Seq.map fib

printfn "%s" (numbers |> Seq.map string |> String.concat ", ")