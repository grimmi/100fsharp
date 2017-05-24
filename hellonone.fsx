let hello name =
    match name with
    |None -> "Hello World"
    |Some s -> "Hello, " + s

let x = hello None
let y = hello (Some "Max")