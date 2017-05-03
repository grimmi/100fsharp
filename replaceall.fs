(*
    Write function replaceAll that will replace all occurences of an item with another

    Example: replaceAll [1,2,2] 1 2 -> [2,2,2]

    taken from: https://www.codewars.com/kata/replace-all-items/train/fsharp
*)

let replaceAll list a b =
  list
  |> List.map (fun i -> match i with
                        | x when (i = a) -> b
                        | _ -> i)

let z = replaceAll [1;2;2] 1 2                    