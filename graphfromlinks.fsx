(*
    Graph from links - Create a program that will create a graph or network from a series of links.
*)

// let's assume an undirected graph at first

open System.Collections.Generic

type Node = { Id : int; Nodes : Node list }

type Link = { Node1 : Node; Node2 : Node }

let isLinkedTo n m =
    match n.Nodes |> Seq.exists (fun node -> node.Id = m.Id) with
    |true -> true
    |false -> m.Nodes |> Seq.exists (fun node -> node.Id = n.Id)

let addLink (n:Node) (m:Node) = 
    if isLinkedTo n m then
        m
    else
        { m with Nodes = (m.Nodes |> List.append [n]) }

let addNodes (nodes: Node seq) (graph:Dictionary<int,Node>) =
    Seq.fold (fun (g:Dictionary<int,Node>) (n: Node) -> 
        match g.TryGetValue n.Id with
        |true, _ -> g
        |false, _ -> 
            g.Add(n.Id, n)
            g) graph nodes

let tryGetNode (graph:Dictionary<int,Node>) id =
    graph.TryGetValue id

let graphFromLinks links =
    let graph = Dictionary<int, Node>()
    
    let nodes = links
                |> Seq.collect (fun l -> [l.Node1;l.Node2])
    
    let graphWithNodes = graph |> addNodes nodes

    links
    |> Seq.map (fun l ->
        printfn "matching %d" l.Node1.Id
        match tryGetNode graphWithNodes l.Node1.Id with
        |true, node -> 
            let newNodeWithLinks = node |> addLink l.Node2
            printfn "new node: %A" newNodeWithLinks
            graphWithNodes.[l.Node1.Id] <- newNodeWithLinks
            graphWithNodes
        |false, _ -> 
            printfn "FALSE!!!!"
            graphWithNodes)
    |> ignore

    graphWithNodes

let myLinks = [{Node1 = {Id = 1; Nodes = []}; Node2 = {Id = 2; Nodes=[]}}]

let g = graphFromLinks myLinks

let n1 = { Id = 1; Nodes = [] }
let n2 = { Id = 2; Nodes = [] }

let nx = n1 |> addLink n2