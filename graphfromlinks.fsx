(*
    Graph from links - Create a program that will create a graph or network from a series of links.
*)

// let's assume a directed graph at first

open System.Collections.Generic

type Node = { Id : int; Nodes : int list }

type Link = { From : int; To : int }

let isLinkedTo id node =
    node.Nodes
    |> Seq.exists (fun node -> node = id)

let addLink (id:int) (m:Node) = 
    match m |> isLinkedTo id with
    | true -> m
    | false -> { m with Nodes = (m.Nodes |> List.append [id])}

let addNodes nodes graph =
    Seq.fold (fun (g:Dictionary<int,Node>) (id: int) -> 
        match g.TryGetValue id with
        |true, _ -> g
        |false, _ -> 
            g.Add(id, {Id = id; Nodes = [] })
            g) graph nodes

let tryGetNode id (graph:Dictionary<int,Node>) =
    graph.TryGetValue id

let graphFromLinks links =
    
    let graphWithNodes = 
        Dictionary<int,Node>() 
        |> addNodes (links |> Seq.collect (fun link -> [link.From; link.To]))

    List.fold (fun graph link ->
        match graph |> tryGetNode link.From with
        |true, node -> 
            graph.[link.From] <- node |> addLink link.To
            graph
        |false, _ -> graph) graphWithNodes links

let myLinks = [{From = 1; To = 2;};{From = 3; To = 2};{From = 1; To = 3};{From = 3; To = 1}]

let g = graphFromLinks myLinks