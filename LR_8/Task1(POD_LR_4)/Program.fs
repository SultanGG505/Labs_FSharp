open System

type IPrint = interface
    abstract member Print: unit -> unit
    end

[<AbstractClass>]
type Shape() = 
    abstract member square: unit -> double

type Rectangle(w: double, h: double) = 
    inherit Shape()
    let mutable width = w
    let mutable height = h
    override this.square() = width * height
    override this.ToString() = 
        $"Прямоугольник с шириной {width}, высотой {height} и площадью {width*height}"
    interface IPrint with
           member this.Print(): unit = printfn "%s"(this.ToString())
           end

type Square(s: double) =
    inherit Rectangle(s,s)
    let mutable side = s
    override this.square() = side * side
    override this.ToString() = 
           $"Квадрат со стороной {side} и площадью {side*side}"
    interface IPrint with
           member this.Print(): unit = printfn "%s"(this.ToString())
           end

type Circle(r: double) =
    inherit Shape()
    let mutable radius = r
    override this.square() = Math.PI * r * r
    override this.ToString() = 
        $"Окружность с радиусом {radius} и площадью {Math.PI * radius * radius}"
    interface IPrint with
           member this.Print(): unit = printfn "%s"(this.ToString())
           end

[<EntryPoint>]
let main argv =
    let rect = Rectangle(10.0,20.0)
    (rect :> IPrint).Print()

    let squr = Square(10.0)
    (squr :> IPrint).Print()

    let circ = Circle(10.0)
    (circ :> IPrint).Print()
    
    0