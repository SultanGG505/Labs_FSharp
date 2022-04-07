open System

let Search list=
    let rec S_ list  =
        match list with
        |[]-> list.Head
        |h::t->
        if list.Head<>list.Tail.Head then list.Tail.Head else S_ list.Tail
    S_ list 
let rec readList n = 
    if n=0 then []
    else
    let Head = Convert.ToInt32(Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    Console.WriteLine("Введите размерность списка:  ")
    let n= Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Введите список: ")
    readList n

[<EntryPoint>]
let main argv =
    let list= readData 
    Console.WriteLine(Search list)
    0 // return an integer exit code