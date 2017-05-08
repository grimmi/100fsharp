(*
    The prime numbers are not regularly spaced. 
    For example from 2 to 3 the step is 1. From 3 to 5 the step is 2. From 7 to 11 it is 4. Between 2 and 50 we have the following pairs of 2-steps primes:
    3, 5 - 5, 7, - 11, 13, - 17, 19, - 29, 31, - 41, 43
    We will write a function step with parameters:
    g (integer >= 2) which indicates the step we are looking for,
    m (integer >= 2) which gives the start of the search (m inclusive),
    n (integer >= m) which gives the end of the search (n inclusive)

    taken from: https://www.codewars.com/kata/5613d06cee1e7da6d5000055/train/fsharp
*)

#load "eratosthenes.fsx"
open Eratosthenes

let getpair n d ns =
    let deltas = ns 
                 |> Seq.map(fun x -> (abs(n - x), x))
                 |> Seq.filter(fun (delta, x) -> delta = d)
                 |> Seq.map(fun (delta, x) -> x)

    match deltas with
    |_ when deltas |> Seq.isEmpty -> [0L;0L]
    |_ -> [n; deltas |> Seq.head]

let step((g:int64),(m:int64),(n:int64)) = 
    let primes = 
        sieve (n |> int)        
        |> Seq.filter(fun (idx, prime) -> prime && idx >= (m |> int))
        |> Seq.map(fun (idx, prime) -> int64(idx))

    let differences = 
        primes
        |> Seq.map(fun p -> getpair p g primes)
        |> Seq.filter(fun pair -> pair <> [0L;0L])
    
    match differences with
    |_ when differences |> Seq.isEmpty -> [0L;0L]
    |_ -> differences |> Seq.head

#time        
let s = step(1564L, 5000L, 5000000L)
#time