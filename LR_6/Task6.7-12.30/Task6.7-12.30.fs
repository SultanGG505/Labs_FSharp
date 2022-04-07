open System

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

let rec loc_max list index =
    match list with
    | a::b::c::t when index = 1 -> b > a && b > c
    | a::b::[] when index = 1 -> b > a
    | a::b::t when index = 0 -> a > b
    | _ -> 
        let newIndex = index - 1
        let newList = list.Tail
        loc_max newList newIndex

[<EntryPoint>]
let main argv =
    
    let list = readData
    Console.WriteLine("Индекс: ")
    let index = Convert.ToInt32(Console.ReadLine())

    printfn "%b"(loc_max list index)
    0

