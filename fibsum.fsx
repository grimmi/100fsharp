(*
    taken from https://www.codewars.com/kata/5541f58a944b85ce6d00006a/train/fsharp
    The Fibonacci numbers are the numbers in the following integer sequence (Fn):
    0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ...
    such as
    F(n) = F(n-1) + F(n-2) with F(0) = 0 and F(1) = 1.
    Given a number, say prod (for product), we search two Fibonacci numbers F(n) and F(n+1) verifying
    F(n) * F(n+1) = prod
    Your function productFib takes an integer (prod) and returns
    an array:
    [F(n), F(n+1), true] or {F(n), F(n+1), 1} or (F(n), F(n+1), True)
    depending on the language if F(n) * F(n+1) = prod.
    If you don't find two consecutive F(m) verifying F(m) * F(m+1) = prod you will return
    [F(m), F(m+1), false] or {F(n), F(n+1), 0} or (F(n), F(n+1), False)
    F(m) being the smallest one such as <code>F(m) * F(m+1) > prod
*)

#load "fibonacci.fsx"
open System
open System.Collections.Generic
open Fibonacci

let productFib (n:uint64) =

    let rec fibSum x = 
        let f1 = Fibonacci.fib x
        let f2 = Fibonacci.fib (x + 1UL)
        match (f1 * f2) with
        | prod when prod < n -> fibSum (x+1UL)
        | prod -> (f1, f2, prod = n)

    fibSum 1UL
let p1 = productFib 74049690UL