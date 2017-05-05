(*
    Write function toInitials returs initials for a given person name. E.g: "Bill Gates" -> "B. G."
    taken from: https://www.codewars.com/kata/57b56af6b69bfcffb80000d7/train/fsharp
*)

let toInitials (name:string) =
    match name.Split ' ' |> Seq.take 2 |> List.ofSeq with
    | [first;second] -> [first.[0];'.';' ';second.[0];'.'] |> List.map (string) |> String.concat ""
    | _ -> ""

let i = "Jack Bauer" |> toInitials
    