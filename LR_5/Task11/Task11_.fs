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
    Console.WriteLine("Любимый ЯП?")
    Console.WriteLine(answer (Console.ReadLine()))
    0