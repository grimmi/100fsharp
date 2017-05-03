(*
Fibonacci Sequence - Enter a number and have the program generate the Fibonacci sequence to that number or to the Nth number.
*)
module Fibonacci
open System
open System.Collections.Generic

let cache = Dictionary<uint64,uint64>()
cache.Add(0UL, 1UL)
cache.Add(1UL, 1UL)
cache.Add(2UL, 1UL)

let rec fib x = 
    let cached = cache.TryGetValue x
    match cached with
    | true, v -> v
    | false, _ -> 
        let computed = fib (x-1UL) + fib (x-2UL) 
        cache.Add(x, computed)
        computed

let fibiter n =
    [ 2 .. n ]
    |> Seq.fold (fun (a,b) _ -> (b, a+b)) (0, 1)
    |> snd

let numbers =
    [ 1UL .. 75UL ]
    |> Seq.map fib

printfn "%s" (numbers |> Seq.map string |> String.concat ", ")