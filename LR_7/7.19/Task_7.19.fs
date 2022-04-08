open System

(*
3 Дана строка в которой слова записаны через пробел. Необходимо
перемешать все слова этой строки в случайном порядке.
*)

let rec writeString = function
    |[]-> let z =System.Console.ReadKey()
          0
    |(head:string)::tail ->
                    System.Console.WriteLine(head)
                    writeString tail
// найти следующий пробел 
let space n=
    let rec p n init s = 
        match n with 
        |""| " "-> init+1
        |_->
            match s with 
            |' '-> init
            |_ ->
                let newi= init+1
                let news = n.[0]
                let newn = n.[1..String.length n]
                p newn newi news
    p n 0 'a'
//  строки делим на слова
let drop (s:string) = 
    let rec raz (s:string) (words : 'string list)  =
        match s with
        |""->words
        |_->
            let newWord = s.[0 .. (space s-1)]
            let newS= s.[(space s).. String.length s]
            raz newS (words@[newWord])
    raz s []

// перемешивание по длине слов
let RND s =
    let newS = drop s 
    let rnd = System.Random()
    let pers= List.permute (fun x->(x+5)%List.length newS)newS 
    pers
// сборка списка слов в строку
let ToString (list: 'string list) = 
    let rec r list (str : string) =
        match list with
        |[]->
            let newS = str.[1..(String.length str - 1)]
            newS
        | h::tail->
            let newS = str + " " + h
            r tail newS
    r list ""

[<EntryPoint>]
let main argv =
    Console.WriteLine "Введите строку, которую хотите перемешать"
    let (s:string) = Console.ReadLine()
    Console.WriteLine (ToString(RND s))
    0