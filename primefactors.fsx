(*
    **Prime Factorization** - Have the user enter a number and find all Prime Factors (if there are any) and display them.
*)

let primefactors x = 
    let check = seq { let limit = uint64((ceil(sqrt(float(x)))));
                      for x in Seq.concat [seq { yield 2UL }; { 3UL .. 2UL .. limit }] do
                        yield x }

    let getFirstOrDefault def ns =
        if ns |> Seq.isEmpty then
            def
        else
            ns |> Seq.head

    let nextfactor x = 
        match x with
        |1UL -> x
        |_ -> check
              |> Seq.skipWhile(fun idx -> x % idx <> 0UL)
              |> getFirstOrDefault x
            
    
    let rec getfactors x factors =
        match nextfactor x  with
        |1UL -> factors
        |factor -> (factors |> List.append [factor]) |> getfactors (x / factor)
    
    [] |> getfactors x

#time
let smallFactors = primefactors 3672215407307975928UL
printfn "smallfactors: %A" smallFactors
#time
#time
let bigPrimeFactor = primefactors 18446744073709551556UL
printfn "bigfactors: %A" bigPrimeFactor
#time
#time
let biggestuint64Prime = primefactors 18446744073709551557UL
printfn "biggestprime: %A" biggestuint64Prime
#time

let ePrime = primefactors 600851475143UL