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

let max_simple_del a init =
    let rec max_ a init cand=
        if cand<=0 then init else
           let newInit= if check_simple cand && a%cand=0 && cand>init then cand else init
           let newCand=cand-1
           max_ a newInit newCand
    max_ a init a
//произведение цифр числа, не делящихся на 5
let PR_NO_MOD_5 a init=
    let rec pr_ a init =
        if a=0 then init else
           let newInit = if (a%10)%5<>0 then init*(a%10) else init
           let newCand=a/10
           pr_ newCand newInit 
    pr_ a init 
//Найти НОД максимального нечетного непростого делителя
//числа и прозведения цифр данного числа.
let rec NOD n m=
    if n=0||m=0 then n+m 
    else
    let newn=if n>m then n%m else n
    let newm=if n<=m then m%n else m
    NOD newn newm

let PR a init=
    let rec PR_ a init=
        if a=0 then init else
           let newinit=init*(a%10)
           let newa=a/10
           PR_ newa newinit
    PR_ a init

let MAX_Nechet_Simple a init=
    let rec max1 a init cand=
        if cand=0 then init else
           let newInit=if a%cand=0 && cand%2=1 && not(check_simple a) && cand>init then cand else init
           let newCand=cand-1
           max1 a newInit newCand
    max1 a init a
[<EntryPoint>]
let main argv =
    let number =Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Максимальный простой делитель числа:{0}",max_simple_del number 0)
    Console.WriteLine("Произведение цифр числа, не кратных 5:{0}",PR_NO_MOD_5 number 1)
    Console.WriteLine("(1)Произведение цифр числа:{0}",PR number 1)
    Console.WriteLine("(2)Максимальный нечетный непростой делитель:{0}",MAX_Nechet_Simple number 1)
    Console.WriteLine("НОД (1) и (2):{0}",NOD (PR number 1) (MAX_Nechet_Simple number 1) )
    
    0 // return an integer exit code