(*

    Your granny, who lives in town X0, has friends. These friends are given in an array, for example: array of friends is

    [ "A1", "A2", "A3", "A4", "A5" ].

    The order of friends is this array must not be changed since this order gives the order in which they will be visited.

    These friends inhabit towns and you have an array with friends and towns, for example:

    [ ["A1", "X1"], ["A2", "X2"], ["A3", "X3"], ["A4", "X4"] ]
    or
    (C)
    {"A1", "X1", "A2", "X2", "A3", "X3", "A4", "X4"}

    which means A1 is in town X1, A2 in town X2... It can happen that we don't know the town of one of the friends.

    Your granny wants to visit her friends and to know how many miles she will have to travel.

    You will make the circuit that permits her to visit her friends. For example here the circuit will contain:

    X0, X1, X2, X3, X4, X0

    and you must compute the total distance

    X0X1 + X1X2 + .. + X4X0.

    For the distance, fortunately, you have a map (and a hashmap) that gives each distance X0X1, X0X2 and so on. For example:

    [ ["X1", 100.0], ["X2", 200.0], ["X3", 250.0], ["X4", 300.0] ]
    or (Coffeescript, Javascript)
    ['X1',100.0, 'X2',200.0, 'X3',250.0, 'X4',300.0 ]
    or
    (C)
    {"X1", "100.0", "X2", "200.0", "X3", "250.0", "X4", "300.0"}

    which means that X1 is at 100.0 miles from X0, X2 at 200.0 miles from X0, etc...

    More fortunately (it's not real life, it's a story...), the towns X0, X1, ..Xn are placed in the following manner:

    X0X1X2 is a right triangle with the right angle in X1, X0X2X3 is a right triangle with the right angle in X2, etc...

    If a town Xi is not visited you will suppose that the triangle

    X0Xi-1Xi+1 is still a right triangle.

    taken from https://www.codewars.com/kata/help-your-granny
*)

open System

let distance x1 x2 =
    //x1 and x2 are two sides of a right triangle, one of them the hypotenuse
    sqrt(abs((pown x1 2) - (pown x2 2)))

let tryFindTown (friendTowns: string[] seq) friend =
    match (friendTowns |> Seq.tryFind(fun f -> f.[0] = friend)) with
    |Some([|f; t|]) -> Some(t)
    |_ -> None

let distanceBetween (distances: Map<string, float>) start destination =
    match (start, destination) with
    |(Some(s), (Some(d))) -> distance distances.[s] distances.[d]
    |_ -> 0.0

let tour(friends: string[]) (friendTowns: string[][]) (distances: Map<string, float>): int =
   let towns = seq{ yield [|"A0"; "X0"|]; yield! friendTowns }
   let townOfFriend = tryFindTown towns
   let completeTour = seq { yield "A0"; yield! friends |> Seq.filter(fun f -> match townOfFriend f with
                                                                              |None -> false
                                                                              |Some(town) -> distances.ContainsKey town); yield "A0" }
   let getDistance = distanceBetween (distances.Add("X0", 0.))
   completeTour 
   |> Seq.pairwise 
   |> Seq.sumBy(fun (f1, f2) -> getDistance (townOfFriend f1) (townOfFriend f2))
   |> int

let friends1 = [|"A1"; "A2"; "A3"; "A4"; "A5"|]
let fTowns1 = [| [|"A1"; "X1"|]; [|"A2"; "X2"|]; [|"A3"; "X3"|]; [|"A4"; "X4"|] |]
let distTable1 = [("X1", 100.0); ("X2", 200.0); ("X3", 250.0); ("X4", 300.0)] |> Map.ofSeq
let t = tour friends1 fTowns1 distTable1