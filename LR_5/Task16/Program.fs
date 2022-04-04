open System
 
let rec NOD a b =
    if a=b then a
    else 
        if a>b then NOD (a-b) b 
        else NOD a (b-a) 

let Eiler n func init =
    let rec Eiler_ n func init a=
        if a<=0 then init
          else 
          let newInit=if NOD n a=1 then func init else init 
          let new_a=a-1
          Eiler_ n func newInit new_a
    Eiler_ n func init n
 
let GO x F init =
    let rec GO_ x F init number =
        if number = 0 then init
        else 
            let new_init = if (NOD x number) = 1 then F init number else init
            let new_number = number - 1
            GO_ x F new_init new_number
    GO_ x F init x
 
 
[<EntryPoint>]
let main argv =
    System.Console.WriteLine("Введите число:")
    let x = System.Convert.ToInt32(System.Console.ReadLine())
    System.Console.WriteLine("Сумма:{0}", GO x (fun x y -> x+y) 0)
    System.Console.WriteLine("Функция Эйлера от числа:{0}", Eiler x (fun x  -> x + 1) 0) //36->12
    0 
    