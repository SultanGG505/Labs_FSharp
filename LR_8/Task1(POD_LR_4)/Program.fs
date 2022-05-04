open System

[<AbstractClass>]
type Shape() = 
    abstract member square: unit -> double

type Rectangle(w: double, h: double) = 
    inherit Shape()
    let mutable width = w
    let mutable height = h
    override this.square() = width * height
    
type Square(s: double) =
    inherit Rectangle(s,s)
    let mutable side = s
    override this.square() = side * side

type Circle(r: double) =
    inherit Shape()
    let mutable radius = r
    override this.square() = Math.PI * r * r
    