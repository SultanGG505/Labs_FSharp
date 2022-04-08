open System

(*
Дан целочисленный массив. Необходимо разместить элементы,
расположенные до минимального, в конце массива.
*)

let rec readList n =
    Console.WriteLine("Введите элементы:")
    List.init(n) (fun index->Console.ReadLine()|>Int32.Parse)

let readData = 
    Console.WriteLine("Введите количество элементов:")
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let rec writelist list=
    List.iter(fun x->printfn "%O" x) list

[<EntryPoint>]
let main argv =
    let list = readData
    let min = List.min list
    let ind= List.findIndex (fun x -> x=min) list
    let index = List.indexed list
    let List1= list.[0..(ind-1)]
    let List2=list.[ind..List.length list]
    Console.WriteLine("answer - ")
    writelist(List2@List1)
    0