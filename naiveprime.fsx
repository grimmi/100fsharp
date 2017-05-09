(*
    Write function isPrime that tells us if a given number is prime or not.
    taken from: https://www.codewars.com/kata/57a1a3f153ba3315140013d5/train/fsharp    
*)

let isPrime (n:int) =
    match n with
    |1 -> false
    |_ -> [ 2 .. n / 2 ]
          |>Seq.fold(fun prime idx -> (prime && (n % idx <> 0))) true

let ps =  [ 1 .. 10 ]
          |> List.map(fun x -> (x, isPrime x))
