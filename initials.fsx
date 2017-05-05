(*
    Write function toInitials returs initials for a given person name. E.g: "Bill Gates" -> "B. G."
    taken from: https://www.codewars.com/kata/57b56af6b69bfcffb80000d7/train/fsharp
*)

let toInitials (name:string) =
    // (name.Split ' ')
    // |> Seq.map(fun part -> sprintf "%c." part.[0])
    // |> String.concat " "

    (Seq.fold (fun initials n -> sprintf "%s %c." initials (n |> Seq.head)) "" (name.Split ' ')).Trim()

let i = "Jack Bauer" |> toInitials
let r = "Robert C. Martin" |> toInitials    