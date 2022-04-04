open System
// максимальный простой делитель числа
let ober_simple a=
    let rec simple a cand=
      if cand=0 then false
         else 
         if cand=1 then true else
            if a%cand=0 then false
             else
             let newcand=cand-1
             simple a newcand
    simple a (a-1)

let MaxDel a init =
    let rec max_ a init cand=
        if cand<=0 then init else
           let newInit= if ober_simple cand && a%cand=0 && cand>init then cand else init
           let newCand=cand-1
           max_ a newInit newCand
    max_ a init a

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите число")
    let a=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Максимальный простой делитель числа:{0}",MaxDel a 0)
    0 