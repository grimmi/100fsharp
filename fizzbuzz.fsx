let buzzer n = 
    match n with
    | n when n % 3 = 0 && n % 5 = 0 -> printfn "fizzbuzz"
    | n when n % 3 = 0 -> printfn "fizz"
    | n when n % 5 = 0 -> printfn "buzz"
    | _ -> printfn "%d" n

let fizzbuzz n =
    let range = [ 1 .. n ]

    range
    |> List.map buzzer

fizzbuzz 30