(*
Fibonacci Sequence - Enter a number and have the program generate the Fibonacci sequence to that number or to the Nth number.
*)

let rec fib x = 
    match x with
    | 0 | 1 | 2 -> 1
    | _ -> fib (x-1) + fib (x-2)

let x = fib 8