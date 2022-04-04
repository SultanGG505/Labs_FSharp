open System

//обход делителей числа с условием
let GO n pred func init=
    let rec GO_ n func init b=
        if b=0 then init else
        let newInit= if n%b=0 && pred b then func init b else init
        let newb=b-1
        GO_ n func newInit newb 
    GO_ n func init n

let rec NOD a b =
    if a=b then a
    else 
        if a>b then NOD (a-b) b 
        else NOD a (b-a) 

//обход взаимно простых с условием 
let GO2 n pred func init=
    let rec GO2_ n func init a=
        if a<=0 then init else
        let newInit= if NOD n a=1 && pred a then func init a else init
        let newA=a-1
        GO2_ n func newInit newA
    GO2_ n func init n

[<EntryPoint>]
let main argv =
    System.Console.WriteLine("Введите число:")
    let a = System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Сумма нечётных делителей числа:{0}",GO a (fun x -> x%2=1) (fun x y ->x+y) 0)
    Console.WriteLine("Произведение чётных чисел, взаимно простых с данным:{0}", GO2 a (fun x->x%2=0) (fun x y->x*y) 1 )
    0