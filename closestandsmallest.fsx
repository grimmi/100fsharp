(*
    Input
    a string strng of n positive numbers (n = 0 or n >= 2)

    Let us call weight of a number the sum of its digits. For example 99 will have "weight" 18, 100 will have "weight" 1.
    Two numbers are "close" if the difference of their weights is small.
    Task:
    For each number in strng calculate its "weight" and then find two numbers of strng that have:

    the smallest difference of weights ie that are the closest
    with the smallest weights
    and with the smallest indices (or ranks, numbered from 0) in strng

    Output:
    an array of two arrays, each subarray in the following format:
    [number-weight, index in strng of the corresponding number, original corresponding number instrng]
    or a pair of two subarrays (Haskell, Clojure, FSharp) or an array of tuples (Elixir, C++) mimicking an array of two subarrays.

    The two subarrays are sorted in ascending order by their number weights if these weights are different, by their indexes in the string if they have the same weights.

    strng = "103 123 4444 99 2000"
    the weights are 4, 6, 16, 18, 2 (ie 2, 4, 6, 16, 18)

    closest should return [[2, 4, 2000], [4, 0, 103]] (or ([2, 4, 2000], [4, 0, 103])
    or [{2, 4, 2000}, {4, 0, 103}] or ... depending on the language)
    because 2000 and 103 have for weight 2 and 4, ther indexes in strng are 4 and 0.
    The smallest difference is 2.
    4 (for 103) and 6 (for 123) have a difference of 2 too but they are not 
    the smallest ones with a difference of 2 between their weights.

    taken from: https://www.codewars.com/kata/5868b2de442e3fb2bb000119/train/fsharp
*)

open System

let digitSum s =
    s |> string |> Seq.fold(fun sum c -> sum + (c |> string |> int)) 0

let digitSums (ns: int seq) =
    ns
    |> Seq.mapi(fun idx n -> (idx, n))
    |> Seq.map(fun (idx, n) -> ((n |> digitSum), idx, n))

let mindiff (tup: int*int*int) sums =
    let tupSum, tupIdx, tupN = tup
    let minDiff = sums
                  |> Seq.minBy(fun (sum, idx, n) -> Math.Abs(sum - tupSum))
    (tup, minDiff)

let getminPair tups =

    tups
    |> Seq.map(fun tup -> mindiff tup (tups |> Seq.filter(fun t -> t <> tup)))

let closest (ns: int seq) =
    ns |> digitSums |> getminPair

let xs = closest [123;234;345];

xs |> Seq.iter(fun ((w1, idx1, n1),(w2, idx2, n2)) -> printfn "weight1: %d, idx1: %d, n1: %d | weight2: %d, idx2: %d, n2: %d" w1 idx1 n1 w2 idx2 n2)