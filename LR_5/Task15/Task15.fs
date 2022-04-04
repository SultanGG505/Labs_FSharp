open System
 
let rec NOD a b =
    if a=b then a
    else 
        if a>b then NOD (a-b) b 
        else NOD a (b-a) 
 
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
    0 
 