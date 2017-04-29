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