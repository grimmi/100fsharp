(*
    Caesar cipher - 
    Implement a Caesar cipher, both encoding and decoding. 
    The key is an integer from 1 to 25. This cipher rotates the letters of the alphabet (A to Z). 
    The encoding replaces each letter with the 1st to 25th next letter in the alphabet (wrapping Z to A). 
    So key 2 encrypts "HI" to "JK", but key 20 encrypts "HI" to "BC". 
    This simple "monoalphabetic substitution cipher" provides almost no security, because an attacker who has the encoded message 
    can either use frequency analysis to guess the key, or just try all 25 keys.
*)

open System

let alphabet = [| 'A' .. 'Z' |]

let getIndex (c:char) =
    let idx =   alphabet
                |> Array.tryFindIndex (fun t -> t = (Char.ToUpper c))
    (c, idx)

// own modulo operation because f# % doesn't work right for us if we're handling negative numbers
// f#: -3 % 26 -> -3
// 'ours': modulo -3 26 -> 23
// taken from here: http://gettingsharper.de/2012/02/28/how-to-implement-a-mathematically-correct-modulus-operator-in-f/
let modulo (n:int) (m:int)= ((n % m) + m) % m

let encryptIdx idx shift =
    (idx + shift) % 26

let decryptIdx (idx:int) (shift:int) = 
    let newIdx = idx - shift
    modulo newIdx 26

let getShifted charIdx shift shiftOperation =
    match charIdx with
    | _, Some idx -> alphabet.[shiftOperation idx shift]
    | c, None -> c

let operateCaesar operation shift text =
    text
    |> Seq.map getIndex
    |> Seq.map (fun pair -> getShifted pair shift operation)
    |> Seq.map string
    |> String.concat ""

let encryptcaesar shift text = operateCaesar encryptIdx shift text
let decryptcaesar shift text = operateCaesar decryptIdx shift text

let enc = "hello world" |> encryptcaesar 500

let dec = enc |> decryptcaesar 500