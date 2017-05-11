(*
    The aim of the kata is to try to show how difficult it can be to calculate decimals of an irrational number with a certain precision. 
    We have chosen to get a few decimals of the number "pi" using the following infinite series (Leibniz 1646–1716):
    PI / 4 = 1 - 1/3 + 1/5 - 1/7 + ... which gives an approximation of PI / 4.
    http://en.wikipedia.org/wiki/Leibniz_formula_for_%CF%80

    To have a measure of the difficulty we will count how many iterations are needed to calculate PI with a given precision.

    There are several ways to determine the precision of the calculus but to keep things easy we will calculate to within epsilon of your language Math::PI constant. In other words we will stop the iterative process when the absolute value of the difference between our calculation and the Math::PI constant is less than epsilon.

    Your function

    iter_pi(epsilon) must return an array :
    [numberOfIterations, approximationOfPi]

    where approximation of PI has 10 decimals 

    taken from: https://www.codewars.com/kata/550527b108b86f700000073f/train/fsharp
*)

open System

let iterPi epsilon = 
    let quotients = Seq.initInfinite(fun idx -> idx + 1)
    let piRounded = Math.Round(Math.PI, 10)

    let myPi, _, iterations = quotients
                              |> Seq.scan(fun (pi, sign, _) idx -> 
                                    let quotient = float((idx * 2) - 1)
                                    let fsign = float(sign)
                                    (pi + fsign * (1. / quotient), sign * -1, idx)) (0., 1, 0)
                              |> Seq.skipWhile(fun (pi, _, idx) -> Math.Abs(piRounded - (pi*4.)) >= epsilon)
                              |> Seq.take 1
                              |> Seq.head
    (iterations, myPi * 4.)

let p = iterPi 0.0001
