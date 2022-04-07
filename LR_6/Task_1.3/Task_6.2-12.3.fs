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

let glob_max list =
    let rec g_m list max= 
        match list with
        |[]->max
        |h::t-> 
               let newMax=if h>max then h else max
               let newList=t
               g_m newList newMax
    g_m list list.Head

let SearchByInd list n max=
    let rec p list n init=
        match list with
        |[]-> init
        |h::t ->
           if n<>1 then 
             let newList= t
             let newn=n-1
             p newList newn init
              else 
                   if h = max then init=true 
                   else init=false
    p list n true

[<EntryPoint>]
let main argv =
    let list = readData
    let max = glob_max list
    printfn "Введите индекс:"
    let k = Convert.ToInt32(Console.ReadLine())
    Console.WriteLine(SearchByInd list k max)
    0 