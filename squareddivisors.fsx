(*
    Divisors of 42 are : 1, 2, 3, 6, 7, 14, 21, 42. These divisors squared are: 1, 4, 9, 36, 49, 196, 441, 1764. 
    The sum of the squared divisors is 2500 which is 50 * 50, a square!
    
    Given two integers m, n (1 <= m <= n) we want to find all integers between m and n whose sum of squared divisors is itself a square. 
    42 is such a number. The result will be an array of arrays(in C an array of Pair), each subarray having two elements, 
    first the number whose squared divisors is a square and then the sum of the squared divisors.

    #Examples:

    list_squared(1, 250) --> [(1, 1), (42, 2500), (246, 84100)]
    list_squared(42, 250) --> [(42, 2500), (246, 84100)]

    taken from: https://www.codewars.com/kata/55aa075506463dac6600010d/train/fsharp
*)

let getDivisors n =

    let belowRoot = 
        [ 1 .. int(sqrt(float(n))) + 1]
        |>List.filter(fun x -> n % x = 0)

    let divisors = [ 0 .. belowRoot.Length - 1]
                   |>Seq.collect(fun x -> 
                       let item = belowRoot.[x]
                       [0 .. belowRoot.Length - 1]
                       |> Seq.map(fun y -> item * belowRoot.[y])
                       |> Seq.filter(fun p -> n % p = 0))
                   |>List.ofSeq 

    [n] |> List.append divisors |> List.distinct

let ds = getDivisors 42

let isSquare x =
    let r = sqrt(float(x))
    r = (float(r |> int))

let listSquared n m =
    [ n .. m ]
    |>Seq.map(fun x -> (x, getDivisors x |> Seq.sumBy(fun d -> d*d)))
    |>Seq.filter(fun (x, s) -> isSquare s)
    |>List.ofSeq

let x = listSquared 1 250
printfn "%A" x
// let x1 = listSquared 42 250
// printfn "%A" x1
// let x2 = listSquared 250 500
// printfn "%A" x2
// let x3 = listSquared 300 600
// printfn "%A" x3
// let x4 = listSquared 1 10000