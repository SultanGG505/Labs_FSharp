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

let rec writeList = function
    [] ->   let z = Console.ReadKey()
            0
    | (head : int)::tail -> 
                       Console.WriteLine(head)
                       writeList tail  

let rec makeMove (list: int list) = list.Tail@[list.Head]

[<EntryPoint>]
let main argv =
    let list = readData
    printfn "%A"(makeMove list)
    0