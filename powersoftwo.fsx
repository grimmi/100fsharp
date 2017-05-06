let powersOfTwo n = 
    [ 0 .. n ]
    |> List.map (fun idx -> pown 2 idx)