(*
    **Binary to Decimal and Back Converter** - Develop a converter to convert a decimal number to binary or a binary number to its decimal equivalent.
*)

type BinaryDigit =
|BinaryOne
|BinaryZero

let binaryToDecimal (b:string) =
    b 
    |> Seq.rev
    |> Seq.choose(fun c -> match c with
                           |'0' -> Some BinaryZero
                           |'1' -> Some BinaryOne
                           |_ -> None)
    |> Seq.mapi(fun idx d -> match d with
                             |BinaryZero -> 0
                             |BinaryOne -> pown 2 idx)
    |> Seq.sum

let b = "1010_0001" |> binaryToDecimal

open System

let decimalToBinary (c:int64) =
    let maxlen = int((Math.Log(float(c), 2.)) + 1.)

    let rec combineBinary acc pow current =
        let currentPow = pown 2L pow
        match pow with        
        |(-1) -> acc
        |_ when currentPow > current -> combineBinary (acc + "0") (pow - 1) current        
        |_ -> combineBinary (acc + "1") (pow - 1) (current - currentPow)
    
    combineBinary "" maxlen c
    |> Seq.skipWhile(fun c -> c = '0')
    |> Seq.map string
    |> String.concat ""

let x = decimalToBinary 129L

