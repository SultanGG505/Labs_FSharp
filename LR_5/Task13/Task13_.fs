open System
//Произведение цифр с помощью рекурсии вверх

let rec pr_up x =
    match x with
    | 0 -> 1
    | x -> (x % 10) * pr_up (x / 10)

 //поиск цифры с максимальным значением с помощью рекурсии вверх
let rec max_up x =
    match x with
    |x when x<10-> x
    |x->max (x % 10) (max_up (x/10))
 
//поиск цифры с минимальным значением с помощью рекурсии вверх
let rec min_up x =
    match x with
    |x when x<10-> x
    |x->min (x % 10) (min_up (x/10))
 
//Произведение цифр с помощью рекурсии вниз(+ хвостовая рекурсия)
let rec pr_down x a =
    match x with 
    | x when x=0 ->a
    | x->
        let b = x/10
        let c = x%10*a
        pr_down(b) c
 
//поиск максимальной цифры с помощью рекурсии вниз
let rec max_down x a =
     let x_1 = x % 10
     let x_2 = x / 10
     match x with 
    |x when (x_1)>a->max_down(x_2)(x_1)
    |x when x=0 ->a
    |x->max_down(x_2)a
 
//поиск минимальной цифры с помощью рекурсии вниз
let rec min_down x a =
     let x_1 = x % 10
     let x_2 = x / 10
     match x with 
    | x when (x<>0)&&((x_1)<a)->min_down(x_2)(x_1)
    | x when x=0 ->a
    | x->min_down(x_2)a
 
 
[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите число:")
    let x = System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Произведение рекурсией вверх:{0}", pr_up x)
    Console.WriteLine("Максимум рекурсией вверх:{0}", max_up x)
    Console.WriteLine("Минимум рекурсией вверх:{0}", min_up x)
    Console.WriteLine("Произведение рекурсией вниз:{0}", pr_down x 1)
    Console.WriteLine("Максимум рекурсией вниз:{0}", max_down x 0)
    Console.WriteLine("Минимум рекурсией вниз:{0}", min_down x 9)
    0 