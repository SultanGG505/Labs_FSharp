open System

let printerAgent = MailboxProcessor.Start(fun inbox->
    let rec messageLoop() = async{
        let! msg = inbox.Receive()        
        match msg with
        | "F#"|"Prolog" -> Console.WriteLine("Подлиза") 
        | "c++" -> Console.WriteLine("based") 
        | "c#" -> Console.WriteLine("based++") 
        | "assembler" -> Console.WriteLine("ладно") 
        |_ -> Console.WriteLine("ну ты выдал!") 
        return! messageLoop()
        }
    messageLoop()
 )
[<EntryPoint>]
let main argv =
    let arg1 = printerAgent.Post("c++")
    let arg2 = printerAgent.Post("assembler")
    let arg2 = printerAgent.Post("Prolog")    
    Console.ReadKey()
    0 