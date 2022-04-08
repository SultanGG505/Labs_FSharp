open System

(*
Объединить два произвольных массива в один.
*)

let readArray n =
    let rec read n cand =
      if n  = 0 then cand else
       let new_el = Convert.ToInt32(Console.ReadLine())
       let newCand = Array.append cand [|new_el|]
       let newn = n-1
       read newn newCand
    read n Array.empty

let printArray array =
    printf "%A" array
[<EntryPoint>]
let main argv =
    printf "Введите размер первого списка"
    let n = Convert.ToInt32(Console.ReadLine())
    printf "Введите первый список"
    let list1 = readArray n
    printf "Введите размер второго списка"
    let k = System.Convert.ToInt32(System.Console.ReadLine())
    printf "Введите второй список"
    let list2 = readArray k
    let list3 = Array.append list1 list2 
    printArray list3
    0 