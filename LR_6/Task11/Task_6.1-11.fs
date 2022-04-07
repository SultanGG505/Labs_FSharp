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

let rec change list (func: int -> int -> int -> int) =
    match list with 
    | a::b::c::t -> (func a b c) :: (change t func)
    | a::b::[] -> (func a b 1) :: (change [] func)
    | a::[] -> (func a 1 1) :: (change [] func)
    | [] -> []


[<EntryPoint>]
let main argv =
    (* Console.WriteLine("Ввод n")
    let n = Convert.ToInt32(Console.ReadLine()) *)
    let list = readData
    Console.WriteLine("text")
    change list (fun x y z -> x+y+z) |> writeList
    0