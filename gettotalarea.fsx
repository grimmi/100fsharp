(*
    Finish this kata with the unit tests as your only help!

    Task:
    Implement:
    getTotalArea
    Define the different shapes: Square, Rectangle, Circle and Triangle

    taken from: https://www.codewars.com/kata/5702e2f380b8c86df3000003/train/fsharp
*)

type Shape =
|Triangle of double * double
|Square of double
|Rectangle of double * double
|Circle of double

let getTotalArea shapes =
    let areaSum = shapes
                  |> Seq.sumBy(fun shape -> match shape with
                                            |Triangle(baseLength, height) -> 0.5 * (baseLength * height)
                                            |Square(side) -> side * side
                                            |Rectangle(height, width) -> height * width
                                            |Circle(radius) -> (pown radius 2) * System.Math.PI)
    System.Math.Round(areaSum, 2)


// let triangleBase = 4.
// let height = 6.
// let triangle = Triangle(triangleBase, height)
// Assert.Equal("", 12.00, getTotalArea [triangle])

// Assert.Equal("", 49.14, getTotalArea [Rectangle(4., 2.); Rectangle(3., 4.); Circle(1.); Square(1.); Triangle(10., 5.)])