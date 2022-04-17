// Создать класс, содержащий информацию о правах на вождение
open System

type License(i_n: int,i_s: int, LN: string, FN: string, P: string, bD: string, eAD: string, Cat: string) = 
    member this.id_num = i_n
    member this.id_ser = i_s
    member this.LastName = LN
    member this.FirstName = FN
    member this.Patronymic = P
    member this.birthDay = bD
    member this.endActiveDay = eAD
    member this.category = Cat
    
    override this.ToString() = 
        $"Права номер:{this.id_num}, серия:{this.id_ser}\nФИО: {this.LastName} {this.FirstName} {this.Patronymic}\nДата рождения: {this.birthDay}\nКатегория: {this.category}\nДата окончания действительности прав: {this.endActiveDay}"
    override this.Equals(obj1) = 
        match obj1 with
        | :? License as license ->
            license.id_num = this.id_num && license.id_ser = this.id_ser // проверка по номеру и серии прав
        | _ -> false
[<EntryPoint>]
let main argv =
    let licenseF1 = License(1433,105050 ,"Гордов","Султан","Николаевич","01.12.2002","01.12.2043","A")
    let licenseF2 = License(1311,105050,"Румянов","Андрей","Егорович","12.01.2002","01.12.2022","B")
    Console.WriteLine(licenseF1.ToString())
    Console.WriteLine(licenseF2.ToString())
    printfn "%A"((licenseF1 = licenseF2))
    0 
