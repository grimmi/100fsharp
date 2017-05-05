(*
    Write function toInitials returs initials for a given person name. E.g: "Bill Gates" -> "B. G."
    taken from: https://www.codewars.com/kata/57b56af6b69bfcffb80000d7/train/fsharp
*)

let toInitials (name:string) =
    (name.Split ' ')
    |> Seq.map(fun part -> (part.[0] |> string) + ".")
    |> String.concat " "

    // let initials = Seq.fold (fun initials n -> initials + " " + (n |> Seq.head |> string) + ".") "" (name.Split ' ')
    // initials.Trim()

let i = "Jack Bauer" |> toInitials
let r = "Robert C. Martin" |> toInitials    