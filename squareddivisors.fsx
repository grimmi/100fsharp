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

let smallDivisors x =
    let limit = int64(sqrt(float(x)))
    [ 1L .. limit ]
    |> List.filter(fun n -> x % n = 0L)
    |> List.distinct

let getDivisors x =
    let small = smallDivisors x
    List.concat[small; small |> List.map(fun d -> int64(x/d))] |> List.distinct |> List.sort

let isSquare x =
    let r = sqrt(float(x))
    r = (float(r |> int))

let listSquared n m =
    [ n .. m ]
    |>List.map(fun x -> (x, getDivisors x |> List.sumBy(fun d -> d*d)))
    |>List.filter(fun (x, s) -> isSquare s)

#time
let x = listSquared 1L 1000000L
#time
printfn "%A" x