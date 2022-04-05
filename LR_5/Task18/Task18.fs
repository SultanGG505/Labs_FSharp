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
//произведение цифр числа, не делящихся на 5
let proizved a init=
    let rec pr a init =
        if a=0 then init else
           let newInit = if (a%10)%5<>0 then init*(a%10) else init
           let newCand=a/10
           pr newCand newInit 
    pr a init 
//Найти НОД максимального нечетного непростого делителя
//числа и прозведения цифр данного числа.
let rec NOD a b =
    if a=b then a
    else 
        if a>b then NOD (a-b) b 
        else NOD a (b-a) 

let pr a init=
    let rec p a init=
        if a=0 then init else
           let newinit=init*(a%10)
           let newa=a/10
           p newa newinit
    p a init

let max a init=
    let rec max1 a init cand=
        if cand=0 then init else
           let newInit=if a%cand=0 && cand%2=1 && not(ober_simple a) && cand>init then cand else init
           let newCand=cand-1
           max1 a newInit newCand
    max1 a init a
[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите число")
    let a=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Максимальный простой делитель числа:{0}",MaxDel a 0)
    Console.WriteLine("Произведение цифр числа, не кратных 5:{0}",proizved a 1)
    Console.WriteLine("(1)Произведение цифр числа:{0}",pr a 1)
    Console.WriteLine("(2)Максимальный нечетный непростой делитель:{0}",max a 1)
    Console.WriteLine("НОД (1) и (2):{0}",NOD (pr a 1) (max a 1) )
    
    0 // return an integer exit code