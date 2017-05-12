(*
    Write a function getNumberOfSquares that will return how many integer (starting from 1, 2...) numbers 
    raised to power of 2 and then summed up are less than some number given as a parameter.
    E.g 1: For n = 6 result should be 2 because 1^2 + 2^2 = 1 + 4 = 5 and 5 < 6 
    E.g 2: For n = 15 result should be 3 because 1^2 + 2^2 + 3^2 = 1 + 4 + 9 = 14 and 14 < 15

    taken from: https://www.codewars.com/kata/57b71a89b69bfc92c7000170/train/fsharp
*)

let getNumberOfSquares n = 
    (Seq.initInfinite(fun idx -> idx + 1)
    |> Seq.scan(fun sum idx -> sum + (pown idx 2)) 0
    |> Seq.takeWhile(fun sum -> sum < n)
    |> Seq.length) - 1

let getNumberOfSquaresRec n =
    let rec numberOfSquares sum x =
        let newSum = sum + (pown x 2)
        match newSum with
        |s when s < n -> numberOfSquares newSum (x+1)
        |_ -> x - 1

    numberOfSquares 0 n

let x = getNumberOfSquaresRec 2