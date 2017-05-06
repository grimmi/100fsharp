let primefactors x = 
    let nextfactor y = 
        if y % 2UL = 0UL then
            2UL
        else
            let factor = [ 3UL .. 2UL .. uint64(ceil(sqrt(float(y)))) ]
                         |> List.skipWhile(fun idx -> y % idx <> 0UL)
                         |> List.truncate 1
            match factor |> List.length with
            | 1 -> factor |> List.head
            | _ -> y
    
    let rec getfactors x fs =
        match nextfactor x with
        |0UL|1UL -> fs
        |f -> (fs |> List.append [f]) |> getfactors (x / f)
        
    [] |> getfactors x

#time
let z6 = primefactors 167942357145896574UL
#time