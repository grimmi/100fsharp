let primefactors x = 
    let nextfactor y = 
        if y % 2UL = 0UL then
            2UL
        else
            let factor = [ 3UL .. 2UL .. uint64(ceil(sqrt(float(y)))) ]
                         |> Seq.skipWhile(fun idx -> y % idx <> 0UL)
                         |> Seq.truncate 1
            match factor |> Seq.length with
            | 1 -> factor |> Seq.head
            | _ -> y
    
    let rec getfactors x fs =
        match nextfactor x with
        |0UL|1UL -> fs
        |f -> (fs |> List.append [f]) |> getfactors (x / f)
        
    [] |> getfactors x

let z6 = primefactors 3246855154891515UL