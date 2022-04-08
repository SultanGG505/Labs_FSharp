open System

(*
Для введенного числа N построить список неповторяющихся кортежей
(a,b), таких, что существует пара (x,y): X*Y=N, НОД(X,Y)=d, a=X/d, b=Y/d.
*)

let rec NOD n m=
    if n=0||m=0 then n+m 
    else
    let newn = if n >m then n%m else n
    let newm = if n <= m then m%n else m
    NOD newn newm

let rec writelist list =
    match list with
    |[]->0
    |_-> Console.WriteLine("({0},{1})", fst list.Head, snd list.Head)
         writelist list.Tail


[<EntryPoint>]
let main argv =
    let n = Convert.ToInt32(Console.ReadLine())
    let n1 = n/2 
    let n2 = n1+1
    let l1 = [1..n]
    let l2 = [1..n]
    let New = List.allPairs l1 l2
    let filter = List.filter (fun x-> fst x * snd x=n) New
    let Answer = List.map (fun x->(fst x / NOD (fst x) (snd x)),(snd x /NOD (fst x) (snd x))) filter
    writelist Answer
    0