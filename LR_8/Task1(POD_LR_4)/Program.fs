open System

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
    
type Square(s: double) =
    inherit Rectangle(s,s)
    let mutable side = s
    override this.square() = side * side
    override this.ToString() = 
           $"Квадрат со стороной {side} и площадью {side*side}"

type Circle(r: double) =
    inherit Shape()
    let mutable radius = r
    override this.square() = Math.PI * r * r
    override this.ToString() = 
        $"Окружность с радиусом {radius} и площадью {Math.PI * radius * radius}"