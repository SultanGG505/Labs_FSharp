open System

let rec Search list =
    match list with
    | a::b::c::t -> 
        match a,b,c with
        | (x,y,z) | (y,x,z) | (y,z,x) when x <> y && y = z -> Some(x)
        | _ -> Search (b::c::t)
    | _ -> None
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
    Console.WriteLine("Answer is - ")
    Console.Write(Search list)
    0 // return an integer exit code