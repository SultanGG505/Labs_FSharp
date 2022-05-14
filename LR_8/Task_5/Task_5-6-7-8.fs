// Создать класс, содержащий информацию о правах на вождение
open System.Text.RegularExpressions
open System
open System.Diagnostics


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
            if (Regex.IsMatch (newValue.ToString(), @"[0-9]{2}.[0-9]{2}.[0-9]{4}"))
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

    interface IComparable with
        member this.CompareTo obj =
            match obj with
            | :? License as Lc -> this.id_num.CompareTo(Lc.id_num)
            | _ -> 1
        end
    override this.GetHashCode() = this.id_num.GetHashCode()


[<AbstractClass>]
type DocumentCollection() =
    abstract member searchDocument: License -> Boolean

type DocumentList(l: License list) =
    inherit DocumentCollection()
    member this.list: (License list) = l
    override this.searchDocument (doc: License) = 
        (this.list |> List.filter (fun x -> x = doc)).Length > 0

type DocumentArray(l: License list) =
    inherit DocumentCollection()
    member this.array: (License array) = Array.ofList l
    override this.searchDocument (doc: License) = 
        Array.exists (fun x -> x = doc) this.array

type DocumentSet(l: License list) =
    inherit DocumentCollection()
    member this.set: (Set<License>) = Set.ofList l
    override this.searchDocument (doc: License) = 
        Set.contains doc this.set

type DocumentBynary(l: License list) =
    inherit DocumentCollection()
    let rec binarySearch (l:License list) (el:License) =
        match (List.length l) with
        |0->false
        |i->
            let mid = i/2
            match sign <| compare el l.[mid] with
            |0->true
            |1->binarySearch l.[..mid - 1] el
            |_->binarySearch l.[mid + 1..] el    
            
    member this.list: (License list) = l |> List.sortBy (fun x -> x.id_num)
    override this.searchDocument (doc: License) = binarySearch this.list doc





[<EntryPoint>]
let main argv =    
    let random = System.Random()
    let listOfDocs = [ for i in 1 .. 1000000 -> License(1433,105050,"Гордов", "Султан","Николаевич",random.Next(100000,999999).ToString(),"01.12.2043","A")]
    
    let randDoc = License(1433,105050,"Гордов", "Султан","Николаевич",random.Next(100000,999999).ToString(),"01.12.2043","A")
    let arr = DocumentArray(listOfDocs)
    let ls = DocumentList(listOfDocs)
    let set = DocumentSet(listOfDocs)
    let bynary = DocumentBynary(listOfDocs)

    let watch = new Stopwatch()
    watch.Start()
    ls.searchDocument(randDoc)
    watch.Stop()
    Console.WriteLine("Список: {0}", watch.Elapsed)
    watch.Restart()

    let watch = new Stopwatch()
    watch.Start()
    arr.searchDocument(randDoc)
    watch.Stop()
    Console.WriteLine("Массив: {0}", watch.Elapsed)
    watch.Restart()

    let watch = new Stopwatch()
    watch.Start()
    set.searchDocument(randDoc)
    watch.Stop()
    Console.WriteLine("Множество: {0}", watch.Elapsed)
    watch.Restart()
    
    let watch = new Stopwatch()
    watch.Start()
    bynary.searchDocument(randDoc)
    watch.Stop()
    Console.WriteLine("Бинарный поиск: {0}", watch.Elapsed)
    watch.Restart()
    0