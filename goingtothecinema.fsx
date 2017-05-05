(*
    My friend John likes to go to the cinema. He can choose between system A and system B.

    System A : buy a ticket (15 dollars) every time
    System B : buy a card (500 dollars) and every time 
        buy a ticket the price of which is 0.90 times the price he paid for the previous one.

    #Example: If John goes to the cinema 3 times:
    System A : 15 * 3 = 45
    System B : 500 + 15 * 0.90 + (15 * 0.90) * 0.90 + (15 * 0.90 * 0.90) * 0.90 ( = 536.5849999999999, no rounding for each ticket)

    John wants to know how many times he must go to the cinema so that the final result of System B, when rounded up to the next dollar, will be cheaper than System A.
    The function movie has 3 parameters: card (price of the card), ticket (normal price of a ticket), perc (fraction of what he paid for the previous ticket) and returns the first n such that
    ceil(price of System B) < price of System A.

    taken from: https://www.codewars.com/kata/going-to-the-cinema/train/fsharp
*)
let calcCard start ticket perc n = 
    [1 .. n]
    |> Seq.fold(fun sum idx -> sum + (float(ticket) * (pown perc idx))) (float(start))

let movie (card:int) (ticket:int) (perc:float) : int = 
    let idx, maxcard, maxticket = [ 1 .. 1000 ]
                                    |> Seq.map(fun idx -> ((idx, calcCard card ticket perc idx, ticket * idx)))
                                    |> Seq.skipWhile(fun (idx, sumcard, sumticket) -> ceil(sumcard) >= float(sumticket))
                                    |> Seq.take 1 |> Seq.head
    idx

let m = movie 0 10 0.95