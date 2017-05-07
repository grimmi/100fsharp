(*
    **Sieve of Eratosthenes** - 
    The sieve of Eratosthenes is one of the most efficient ways to find all of the smaller primes (below 10 million or so). 
*)
let processSieve (x:int) (sieve: (int * bool)[]) = 
    let limit = (sieve |> Seq.length) - 1
    let xLimit = pown (x |> int64) 2
    let start = min (limit |> int64) xLimit
    if start > int64(System.Int32.MaxValue) then
        ()
    else
        [ int(start) .. x .. limit ]
        |>Seq.iter(fun n -> sieve.[n] <- (n, false))
        sieve.[x] <- (x, true)

let doSieve x =
    let sieve = [| 0 .. x |] |> Array.map(fun idx -> (idx, true))
    sieve.[0] <- (0, false)
    sieve.[1] <- (1, false)

    sieve
    |> Seq.iter(fun (idx, prime) -> 
        match prime with
        |true -> sieve |> processSieve idx
        |false -> ())

    sieve

#time
let sieved = doSieve 10000000
let primes = sieved |> Array.filter(fun (idx, prime) -> prime) |> Array.map(fun (idx, prime) -> idx)
#time

printfn "%d primzahlen gefunden" (primes |> Array.length)