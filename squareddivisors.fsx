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
    let step = match n % 2 with
               |0 -> 1
               |_ -> 2
    [ 1 .. step .. n / 2 ]
    |> Seq.filter(fun x -> n % x = 0)
    |> Seq.append n

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
let x1 = listSquared 42 250
printfn "%A" x1
let x2 = listSquared 250 500
printfn "%A" x2
let x3 = listSquared 300 600
printfn "%A" x3
let x4 = listSquared 1 100000