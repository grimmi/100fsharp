(*
    Given and array of integers (x), return the array with each value doubled. Example:
    [1, 2, 3] --> [2, 4, 6]

    For the beginner, try to use the map method - it comes in very handy quite a lot so is a good one to know.

    taken from: https://www.codewars.com/kata/57f781872e3d8ca2a000007e/train/fsharp
*)

let maps (x:int[]) = 
    x |> Array.map (fun y -> y * 2)