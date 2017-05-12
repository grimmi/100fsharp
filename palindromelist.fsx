let is_palindrome (list:int list) = 
    match list with
    |[] -> true
    |_ -> [ 0 .. (list |> Seq.length) / 2]
          |> Seq.fold(fun palindrome idx -> 
                    palindrome && (list.[idx] = list.[(list |> Seq.length) - (idx + 1)]))true

let p = [] |> is_palindrome