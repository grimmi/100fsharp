(*
    You have a positive number n consisting of digits. 
    You can do at most one operation: Choosing the index of a digit in the number, remove this digit at that index and insert it back to another place in the number.

    Doing so, find the smallest number you can get.
    #Task: Return an array or a tuple depending on the language (see "Your Test Cases" Haskell) with
        1) the smallest number you got
        2) the index i of the digit d you took, i as small as possible
        3) the index j (as small as possible) where you insert this digit d to have the smallest number.

    Example:
    smallest(261235) --> [126235, 2, 0]
    126235 is the smallest number gotten by taking 1 at index 2 and putting it at index 0

    smallest(209917) --> [29917, 0, 1]
    [29917, 1, 0] could be a solution too but index `i` in [29917, 1, 0] is greater than 
    index `i` in [29917, 0, 1].
    29917 is the smallest number gotten by taking 2 at index 0 and putting it at index 1 which gave 029917 which is the number 29917.

    smallest(1000000) --> [1, 0, 6]

    taken from: https://www.codewars.com/kata/573992c724fc289553000e95/train/fsharp
*)
open System

let insertAt idx insert target =     

    let firstPart = target |> string |> Seq.take idx |> System.String.Concat
    let secondPart = target |> string |> Seq.skip idx |> System.String.Concat

    firstPart + (insert |> string) + secondPart |> int

let popIndex (idx:int) (number:int) = 
    let indexed = number |> string |> Seq.mapi(fun i c -> (c, i))

    let without = indexed
                  |> Seq.filter(fun (c, i) -> i <> idx) |> Seq.map(fun (c, i) -> c) |> System.String.Concat |> int
    let popped, _ = indexed |> Seq.item idx     

    (popped |> string |> int, without)               

let smallest n = 
    let popped = [ 0 .. (n |> string |> String.length) - 1]
                 |> Seq.map(fun idx -> (idx, popIndex idx n))

    let getsmallest pl =    
        let i, (p, r) = pl

        let smallest = [0 .. (r |> string |> String.length)]
                    |> Seq.map(fun j -> (j, i, p, r, insertAt j p r))
                    |> Seq.sortBy(fun (j, i, p, r, n) -> (n, j))
                    |> Seq.head
        smallest

    let small = popped |> Seq.map getsmallest
    small |> Seq.map(fun (j, i, p, r, n) -> (n, i, j)) |> Seq.sortBy id |> Seq.head

let s = (smallest 261235)
printfn "%A" s