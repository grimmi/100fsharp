let primefactors x = 
    let nextfactor y = 
        let factor = [ 2 .. (y/2) ]
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

// let z = primefactors 7
// let z1 = primefactors 9
// let z2 = primefactors 21
// let z3 = primefactors 2
// let z4 = primefactors 49
// let z5 = primefactors 1

let z6 = primefactors 65987