let primefactors x = 
    let nextfactor y = 
        if y % 2 = 0 then
            2
        else
            let factor = [ 3 .. 2 .. int(ceil(sqrt(float(y)))) ]
                         |> Seq.skipWhile(fun idx -> y % idx <> 0)
                         |> Seq.truncate 1
            match factor |> Seq.length with
            | 1 -> factor |> Seq.head
            | _ -> y
    
    let rec getfactors x fs =
        match nextfactor x with
        |0|1 -> fs
        |f -> (fs |> List.append [f]) |> getfactors (x / f)
        
    [] |> getfactors x

let z6 = primefactors 656317973