let random = System.Random()
let pickANumberAsync = async { return random.Next(10) }
let createFiftyNumbers = 
    let workflows = [ for i in 1 .. 50 -> pickANumberAsync ]
    async{
        let! numbers = workflows |> Async.Parallel
        printfn "Total is %d" (numbers |> Seq.sum)
    }

createFiftyNumbers |> Async.Start