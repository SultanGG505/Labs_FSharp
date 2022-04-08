open System

(*
Для введенного списка построить новый с элементами, большими, чем
среднее арифметическое списка, но меньшими, чем его максимальное
значение.
*)

let rec readList n =
   Console.WriteLine("Введите элементы:")
   List.init(n) (fun index->Console.ReadLine()|>Double.Parse)

let readData = 
   Console.WriteLine("Введите количество элементов:")
   let n = System.Convert.ToInt32(System.Console.ReadLine())
   readList n

let rec writelist list=
    List.iter(fun x->printfn "%O" x) list

[<EntryPoint>]
let main argv =
    let list = readData
    let sr_ = List.average list
    let max = List.max list
    Console.WriteLine("Answer is")
    writelist(List.filter (fun x -> x>sr_ && x<max) list)
    0 // return an integer exit code