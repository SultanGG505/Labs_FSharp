open System

(*
Дан целочисленный массив и натуральный индекс (число, меньшее
размера массива). Необходимо определить является ли элемент по
указанному индексу глобальным максимумом
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

let Check list n =
    if List.item n list = List.max list then true else false

[<EntryPoint>]
let main argv =
    let list = readData
    Console.WriteLine("Введите индекс:")
    let num = Convert.ToInt32(Console.ReadLine())
    Check list num|>Console.WriteLine
    0 