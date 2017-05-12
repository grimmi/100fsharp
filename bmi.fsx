(*
    Write function bmi that calculates body mass index (bmi = weight / height ^ 2).
    if bmi <= 18.5 return "Underweight"
    if bmi <= 25.0 return "Normal"
    if bmi <= 30.0 return "Overweight"
    if bmi > 30 return "Obese"

    taken from: https://www.codewars.com/kata/57a429e253ba3381850000fb/train/fsharp
*)

let bmi weight height = 
  match weight / (pown height 2) with
  |i when i <= 18.5 -> "Underweight"
  |i when i <= 25.0 -> "Normal"
  |i when i <= 30.0 -> "Overweight"
  |_ -> "Obese"

let i = bmi 80.0 1.8