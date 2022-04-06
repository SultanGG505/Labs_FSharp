open System

// максимальный простой делитель числа
let check_simple a=
    let rec simple a cand=
      if cand=0 then false
         else 
         if cand=1 then true else
            if a%cand=0 then false
             else
             let newcand=cand-1
             simple a newcand
    simple a (a-1)

let MAX_SIMPLE_DEL a  =
    let rec max_ a init cand=
        if cand<=0 then init else
           let newInit= if check_simple cand && a%cand=0 && cand>init then cand else init
           let newCand=cand-1
           max_ a newInit newCand
    max_ a 1 a
//произведение цифр числа, не делящихся на 5
let PR_NO_MOD_5 a =
    let rec PR_ a init =
        if a=0 then init else
           let newInit = if (a%10)%5<>0 then init*(a%10) else init
           let newCand=a/10
           PR_ newCand newInit 
    PR_ a 1 
//Найти НОД максимального нечетного непростого делителя
//числа и прозведения цифр данного числа.
let rec NOD n m=
    if n=0||m=0 then n+m 
    else
    let newn=if n>m then n%m else n
    let newm=if n<=m then m%n else m
    NOD newn newm

let PR a =
    let rec P_ a init=
        if a=0 then init else
           let newinit=init*(a%10)
           let newa=a/10
           P_ newa newinit
    P_ a 1

let MAX_Nechet_Simple a =
    let rec MAX_ a init cand=
        if cand=0 then init else
           let newInit=if a%cand=0 && cand%2=1 && not(check_simple a) && cand>init then cand else init
           let newCand=cand-1
           MAX_ a newInit newCand
    MAX_ a 0 a

let SBEU_NOD a = NOD (PR a) (MAX_Nechet_Simple a)

let select =function
    | 1-> MAX_SIMPLE_DEL
    | 2-> PR_NO_MOD_5
    | 3-> SBEU_NOD
    | _-> SBEU_NOD
    
[<EntryPoint>]
let main argv =
    let a = (Console.ReadLine() |> Int32.Parse, Console.ReadLine() |> Int32.Parse)
    let result = select (fst a) (snd a)
    System.Console.WriteLine(result)
    0 // return an integer exit code