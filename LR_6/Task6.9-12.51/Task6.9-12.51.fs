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

let rec frequency list elem count =
    match list with
    |[] -> count
    | h::t -> 
                    let count1 = count + 1
                    if h = elem then frequency t elem count1 
                    else frequency t elem count

let list1 list =
    let rec l1_ list newList=
        match list with
        |[] -> newList
        |h::t ->
              if frequency list h 0 = 1 then 
                let newList1=newList@[h]
                l1_ t newList1
              else l1_ t newList         
    l1_ list []
    
let list2 list listCol=
    let rec l2_ list listCol list2=
        match listCol with
             |[]-> list2
             |h::t ->
                 let newE= frequency list h 0
                 let newlist=list2@[newE]
                 l2_ list t newlist
    l2_ list listCol []

[<EntryPoint>]
let main argv =
    printfn "Введите количество элементов списка:"
    let n = System.Convert.ToInt32(System.Console.ReadLine())
    printfn "Введите элементы списка:"
    let l= readList n
    printfn" L1 "
    let k= list1 l
    writeList k
    printfn" L2 "
    list2 l k|>writeList
    0 // return an integer exit code