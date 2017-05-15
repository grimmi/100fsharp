(*
    **Check if Palindrome** - Checks if the string entered by the user is a palindrome. That is that it reads the same forwards as backwards like “racecar”
*)

let isPalindrome s =
    s = (s |> Seq.rev |> Seq.map string |> String.concat "")

let i = "racecar" |> isPalindrome