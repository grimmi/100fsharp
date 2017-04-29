(*
    Fizz Buzz - 
    Write a program that prints the numbers from 1 to 100. 
    But for multiples of three print “Fizz” instead of the number and for the multiples of five print “Buzz”. 
    For numbers which are multiples of both three and five print “FizzBuzz”.
*)
let buzzer n = 
    match (n % 3, n % 5) with
    | (0,0) -> printfn "fizzbuzz"
    | (0,_) -> printfn "fizz"
    | (_,0) -> printfn "buzz"
    | _ -> printfn "%d" n

let fizzbuzz n =
    [ 1 .. n ]
    |> List.map buzzer

fizzbuzz 30