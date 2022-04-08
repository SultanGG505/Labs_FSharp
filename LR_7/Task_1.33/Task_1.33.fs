open System

(*
Дан целочисленный массив. Проверить, чередуются ли в нем
положительные и отрицательные числа.
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

let check list=
    let rec c_ list =
        if List.length list >2 then 
          if (List.item 0 list)*(List.item 1 list)<0 then true else false
          c_ list.[1..List.length list]
        else if (List.item 0 list)*(List.item 1 list)<0 then true else false
    c_ list 

[<EntryPoint>]
let main argv =
    readData|>check|>Console.WriteLine
    0 // return an integer exit code