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

let tryGetIndex c =
    let idx =   alphabet
                |> Array.tryFindIndex (fun t -> t = (Char.ToUpper c))
    (c, idx)

// own modulo operation because f# % doesn't work right for us if we're handling negative numbers
// f#: -3 % 26 -> -3
// 'ours': modulo -3 26 -> 23
// taken from here: http://gettingsharper.de/2012/02/28/how-to-implement-a-mathematically-correct-modulus-operator-in-f/
let modulo n m = ((n % m) + m) % m

let shiftIdx idx shift = 
    let newIdx = idx + shift
    modulo newIdx alphabet.Length

let encryptIdx idx shift =
    shiftIdx idx shift

let decryptIdx idx shift = 
    shiftIdx idx (-shift)

let getShifted shift shiftOperation charIdx =
    match charIdx with
    | _, Some idx -> alphabet.[shiftOperation idx shift]
    | c, None -> c

let operateCaesar operation shift text =
    (Seq.map tryGetIndex 
    >> Seq.map (getShifted shift operation)
    >> Seq.map string) text
    |> String.concat ""    

let encryptcaesar shift text = operateCaesar encryptIdx shift text
let decryptcaesar shift text = operateCaesar decryptIdx shift text

let enc = "hello world" |> encryptcaesar 13
let dec = enc |> decryptcaesar 13