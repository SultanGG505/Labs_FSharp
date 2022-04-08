open System

(*
Дан целочисленный массив. Необходимо вывести вначале его
элементы с четными индексами, а затем - с нечетными.
*)

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    printfn "Сколько элементов в списке?"
    let n = System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let rec writeList = function
|[] ->   let z = Console.ReadKey()
         0        
| (head : int)::tail -> 
                   Console.WriteLine(head)
                   writeList tail 

let writer list (list2:int list) p =
    let rec w_ list (list2: int list) p ind newlist=
        match list with 
        |[]->newlist
        |h::tail->
            if (p ind = true) 
            then 
                let newnewlist= newlist @ [list2.Item(ind)]
                let newind=ind+1
                w_ tail list2 p newind newnewlist
            else 
                w_ tail list2 p (ind+1) newlist
    w_ list list2 p 0 []

[<EntryPoint>]
let main argv =
    let list = readData  
    let chlist = writer list list (fun x-> x % 2 = 0)
    let nechlist= writer list list (fun x-> x % 2 = 1)
    let newl= chlist@nechlist
    Console.WriteLine("text")
    writeList newl