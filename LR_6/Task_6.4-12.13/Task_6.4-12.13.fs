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

let min_el list =
    let rec m_ list init=
        match list with
        |[]->init
        |h::t ->
          let newInit =if h<init then h else init
          let newList=t
          m_ newList newInit          
    m_ list list.Head

let change list=
    let rec c_ list =
        match list with
        |[]->list
        |h::t -> 
           if min_el list = h then list
           else 
           let newList=t@[h]
           c_ newList
    c_ list

        
[<EntryPoint>]
let main argv =
    let l = readData
    let answ = change l
    Console.WriteLine("and")
    writeList answ


    