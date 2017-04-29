(*
Product Inventory Project - 
Create an application which manages an inventory of products. Create a product class which has a price, id, and quantity on hand. 
Then create an inventory class which keeps track of various products and can sum up the inventory value.
*)

type Product = { Name : string; Quantity : int; Id : int; Price : decimal }

let tryGetItemById item inventory =
    inventory
    |> List.tryFind (fun i -> i.Id = item.Id)

let rec add item inventory =
    match inventory |> tryGetItemById item with
    |Some product -> 
        inventory
        |> List.filter (fun i -> i.Id <> item.Id)
        |> add { item with Quantity = item.Quantity + product.Quantity }
    |None -> inventory |> List.append [item]      

let productValue inventory = 
    inventory
    |> List.sumBy (fun i -> (decimal(i.Quantity) * i.Price))

let i = [{Name = "Hammer"; Quantity = 5; Id = 1; Price = 10m}; {Name = "Nail"; Quantity = 500; Id = 2; Price = 0.1m}]

let i2 = 
    i
    |> add {Name="Board"; Quantity = 10; Id = 3; Price = 3m}
    |> add {Name="Hammer"; Quantity = 3; Id = 1; Price = 10m}

let s = productValue i2