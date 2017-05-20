(*
    Write a function, downloadData, which takes in a single string url and asynchronously
    returns the number of bytes in the contents. It should have a signature of string ->
    Async<int>.
*)
open System
open System.Net


let downloadData url = 
    let client = new WebClient()
    let getLength = async {
                        let! response = client.AsyncDownloadData(Uri(url))
                        return response |> Seq.length
                    }
    getLength

let d = (downloadData "http://www.google.de") |> Async.RunSynchronously

printfn "länge: %d" d