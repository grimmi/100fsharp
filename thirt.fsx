(*

    When you divide the successive powers of 10 by 13 you get the following remainders of the integer divisions:

        1, 10, 9, 12, 3, 4.

    Then the whole pattern repeats.

    Hence the following method: Multiply the right most digit of the number with the left most number in the sequence shown above, the second right most digit to the second left most digit of the number in the sequence. The cycle goes on and you sum all these products. Repeat this process until the sequence of sums is stationary.

    Example: What is the remainder when 1234567 is divided by 13?

    7×1 + 6×10 + 5×9 + 4×12 + 3×3 + 2×4 + 1×1 = 178

    We repeat the process with 178:

    8x1 + 7x10 + 1x9 = 87

    and again with 87:

    7x1 + 8x10 = 87

    taken from https://www.codewars.com/kata/564057bc348c7200bd0000ff/train/fsharp
*)

let rec thirt m =
    let remainderSeq = seq { while true do yield! [|1; 10; 9; 12; 3; 4|] }
    let newRemainder = m 
                       |> string 
                       |> Seq.rev 
                       |> Seq.map(string >> int) 
                       |> Seq.zip remainderSeq 
                       |> Seq.sumBy(fun (r, d) -> r * d)
    
    match newRemainder = m with
    |true -> newRemainder
    |false -> thirt newRemainder

let x = thirt 1234567