open System

(*
Дан целочисленный массив. Необходимо найти два наименьших
элемента.
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
    Console.WriteLine(" ")
    Console.WriteLine(min)
    Console.WriteLine(" ")
    let newL= List.filter (fun x -> x<>min) list
    Console.WriteLine(List.min newL)
    0 