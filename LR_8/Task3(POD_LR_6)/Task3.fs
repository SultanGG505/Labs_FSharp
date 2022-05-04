open System
open FParsec


type Expr =
    | Number of float
    | Add of Expr * Expr
    | Sub of Expr * Expr


let pstring_trim s = spaces >>. pstring s .>> spaces

let float_ws = spaces >>. pfloat .>> spaces


let parser, parserRef = createParserForwardedToRef<Expr, unit>()


let parsePlusExpr = tuple2 (parser .>> pstring_trim "+") parser |>> Add 

let parseSubExpr = tuple2 (parser .>> pstring_trim "-") parser |>> Sub

let parseOp = between (pstring_trim "(") (pstring_trim ")") (attempt parsePlusExpr <|> parseSubExpr)

let parseNum = float_ws |>> Number

parserRef := parseNum <|> parseOp



let rec EvalExpr (e:Expr): float =
    match e with
    | Number(num) -> num
    | Add(a,b) ->
        let left = EvalExpr(a)
        let right = EvalExpr(b)
        let result = left + right
        result
    | Sub(a,b) ->
        let left = EvalExpr(a)
        let right = EvalExpr(b)
        let result = left - right
        result



[<EntryPoint>]
let main argv =
    printfn "Введите выражение в скобках"
    let input = Console.ReadLine() 
    let expr = run parser input

    match expr with
    | Success (result, _, _) -> printfn "Результат: %f" (EvalExpr result)
    | Failure (errorMsg, _, _) -> printfn "Еггог: %s" errorMsg

    0