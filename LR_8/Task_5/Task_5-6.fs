// Создать класс, содержащий информацию о правах на вождение
open System

type License(i: int, LN: string, FN: string, P: string, bD: string, eAD: string, Cat: string) = 
    let mutable id = i
    let mutable LastName = LN
    let mutable FirstName = FN
    let mutable Patronymic = P
    let mutable birthDay = bD
    let mutable endActiveDay = eAD
    let mutable category = Cat
    
    override this.ToString() = 
        $"Права номер:{id}\nФИО: {LastName} {FirstName} {Patronymic}\nДата рождения: {birthDay}\nКатегория: {category}\nДата окончания действительности прав: {endActiveDay}"

[<EntryPoint>]
let main argv =
    let license = License(1433,"Гордов","Султан","Николаевич","01.12.2002","01.12.2043","A")
    Console.WriteLine(license.ToString())
    0 
