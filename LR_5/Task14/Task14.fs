open System

let GO n func init =
   let rec GO_ n func init b =
       if b = 0 then init else
       let newInit = if n%b = 0 then func init b else init
       let newb = b-1
       GO_ n func newInit newb 
   GO_ n func init n

[<EntryPoint>]
let main argv =
   System.Console.WriteLine("Введите число:")
   let number = System.Convert.ToInt32(System.Console.ReadLine())
   System.Console.WriteLine("Произведение делителей числа:{0}", GO number (fun x y -> x*y ) 1)
   System.Console.WriteLine("Сумма делителей числа:{0}", GO number (fun x y -> x+y ) 0)
   0 