(*
In the drawing below we have a part of the Pascal's triangle, lines are numbered from zero (top).

We want to calculate the sum of the squares of the binomial coefficients on a given line with a function called easyline (or easyLine or easy-line).

Can you write a program which calculate easyline(n) where n is the line number?

The function will take n (with: n>= 0) as parameter and will return the sum of the squares of the binomial coefficients on line n.

##Examples:

easyline(0) => 1
easyline(1) => 2
easyline(4) => 70
easyline(50) => 100891344545564193334812497256
*)

open System.Numerics

let easyline (n:int) = 
    
    let rec getpascal line no =
        match no with
        |_ when no = n -> line
        |_ -> getpascal ((line 
                          |> List.pairwise 
                          |> List.map(fun (x, y) -> x + y) 
                          |> List.append [line.Head]) 
                          @ [line.[line.Length - 1]]) (no + 1)

    getpascal [BigInteger 1] 0 |> List.sumBy(fun x -> pown x 2)

let p = easyline 50
printfn "%O" p
