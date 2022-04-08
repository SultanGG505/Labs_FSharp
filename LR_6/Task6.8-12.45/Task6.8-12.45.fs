open System

(*
Дан целочисленный массив и интервал a..b. Необходимо найти
сумму элементов, значение которых попадает в этот интервал.
*)

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

let Adder (a,b) list init= 
    let rec A_ list (a,b) sum = 
        match list with
        |[]->sum
        |h::tail-> 
            let newSum = 
                if h>a && h<b then sum+h
                else sum
            A_ tail (a,b) newSum
    A_ list (a,b) 0
[<EntryPoint>]
let main argv =
    printfn "Введите количество элементов списка:"
    let n = System.Convert.ToInt32(System.Console.ReadLine())
    printfn "Введите элементы списка:"
    let list = readList n
    Console.WriteLine("Введите границы интервала")
    let interval = (Convert.ToInt32(Console.ReadLine()),Convert.ToInt32(Console.ReadLine()))
    printfn "Сумма элементов:"
    Console.WriteLine(Adder interval list 0)
    0