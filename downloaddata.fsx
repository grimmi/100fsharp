(*
    Write a function, downloadData, which takes in a single string url and asynchronously
    returns the number of bytes in the contents. It should have a signature of string ->
    Async<int>.
*)
open System
open System.Net

let urls = [|"http://www.fsharp.org";"http://microsoft.com";"http://fsharpforfunandprofit.com"|]

let downloadData url = async {
        use client = new WebClient()
        let! response = client.AsyncDownloadData(Uri(url))
        return response.Length
    }

let downloadDataTask url = async{
        use client = new WebClient()
        let! response = client.DownloadDataTaskAsync(Uri(url)) |> Async.AwaitTask
        return response.Length
    }

let lengthsTask = urls |> Seq.map downloadDataTask |> Async.Parallel |> Async.StartAsTask
let lengthsAsync = urls |> Seq.map downloadData |> Async.Parallel |> Async.RunSynchronously

printfn "the lengths are: %A" lengthsTask.Result
printfn "the lengths are: %A" lengthsAsync