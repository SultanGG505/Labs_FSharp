open System

let answer n =
    match n with
    | "F#"|"Prolog" -> "Подлиза"
    | "c++" -> "based"
    | "c#" -> "based++"
    | "assembler" -> "ладно"
    |_ -> "ну ты выдал!"

[<EntryPoint>]
let main argv =
   System.Console.WriteLine("Какой ваш любимый язык программирования?")
   //Случай суперпозиции
   (Console.ReadLine>>answer>>Console.WriteLine)()

   //----------------------------------------------------------------------//

   System.Console.WriteLine("Какой ваш любимый язык программирования?")
  // Случай каррирования
   let F y x z =z(x(y()))
   F Console.ReadLine answer Console.WriteLine
   0 