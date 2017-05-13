(*
    **Binary to Decimal and Back Converter** - Develop a converter to convert a decimal number to binary or a binary number to its decimal equivalent.
*)

let binaryToDecimal (b:string) =
    b 
    |> Seq.rev
    |> Seq.filter(fun c -> ['0';'1'] |> Seq.contains c)
    |> Seq.mapi(fun idx c -> match c with
                             |'0' -> 0
                             |'1' -> pown 2 idx
                             |_ -> 0)
    |> Seq.sum

let b = "1010_0001" |> binaryToDecimal