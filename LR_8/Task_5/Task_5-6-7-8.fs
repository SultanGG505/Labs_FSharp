// Создать класс, содержащий информацию о правах на вождение
open System.Text.RegularExpressions
open System

type License(i_n: int,i_s: int, LN: string, FN: string, P: string, bD: string, eAD: string, Cat: string) = 
    member this.id_num 
       with get() = i_n
        and set(newValue: int) =
            if (Regex.IsMatch (newValue.ToString(), @"[0-9]{4}"))
            then this.id_num <- newValue
            else failwith "error"


    member this.id_ser
        with get() = i_s
            and set(newValue: int) =
                if (Regex.IsMatch (newValue.ToString(), @"[0-9]{6}"))
                then this.id_ser <- newValue
                else failwith "error"


    member this.LastName
        with get() = LN
        and set(newValue: string) =
            if (Regex.IsMatch (newValue, @"[а-яА-Я]"))
            then this.LastName <- newValue
            else failwith "error"


    member this.FirstName
        with get() = FN
        and set(newValue: string) =
            if (Regex.IsMatch (newValue, @"[а-яА-Я]"))
            then this.FirstName <- newValue
            else failwith "error"


    member this.Patronymic
        with get() = P
        and set(newValue: string) =
            if (Regex.IsMatch (newValue, @"[а-яА-Я]"))
            then this.Patronymic <- newValue
            else failwith "error"
    member this.birthDay
        with get() = bD
        and set(newValue: string) =
            if (Regex.IsMatch (newValue, @"[0-9]{2}.[0-9]{2}.[0-9]{4}"))
            then this.birthDay <- newValue
            else failwith "error"


    member this.endActiveDay
        with get() = eAD
            and set(newValue: string) =
                if (Regex.IsMatch (newValue, @"[0-9]{2}.[0-9]{2}.[0-9]{4}"))
                then this.endActiveDay <- newValue
                else failwith "error"


    member this.category
        with get() = Cat
        and set(newValue: string) =
            if (Regex.IsMatch (newValue, @"(A|B|C|D|E)"))
            then this.category <- newValue
            else failwith "error"
    
    override this.ToString() = 
        $"Права номер:{this.id_num}, серия:{this.id_ser}\nФИО: {this.LastName} {this.FirstName} {this.Patronymic}\nДата рождения: {this.birthDay}\nКатегория: {this.category}\nДата окончания действительности прав: {this.endActiveDay}"


    override this.Equals(obj1) = 
        match obj1 with
        | :? License as license ->
            license.id_num = this.id_num && license.id_ser = this.id_ser // проверка по номеру и серии прав
        | _ -> false


[<EntryPoint>]
let main argv =
    let licenseF1 = License(1433,105050,"Гордов", "Султан","Николаевич","01.12.2002","01.12.2043","A")
    let licenseF2 = License(1311,105050,(*пример работы failwith, поменять на имя*)"1319309d0a9wdju91jh0","Андрей","Егорович","12.01.2002","01.12.2022","B")
    
    Console.WriteLine(licenseF1.ToString())
    Console.WriteLine(licenseF2.ToString())

    //licenseF1.FirstName <- "1319309d0a9wdju91jh0"
    
    printfn "%A"((licenseF1 = licenseF2))
   
   
    0 
