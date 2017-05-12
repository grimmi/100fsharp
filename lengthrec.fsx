(*
    Write funcion lenR which returns the length of a given list. Try no to cheat and provide recursive solution.
*)

let lenR list = 
    let rec len l =
        match l with
        |[] -> 0
        |[x] -> 1
        |head::tail -> (len tail) + 1
    
    let rec lenacc acc l =
        match l with
        |[] -> acc
        |head::tail -> lenacc (acc+1) tail

    lenacc 0 list



let x = [1;2;3;4] |> lenR