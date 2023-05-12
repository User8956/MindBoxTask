namespace ShapesLib;

public class Circle : Shape
{
    private readonly double _radius;

    public Circle(double radius)
    {

        if (radius <= 0)
            throw new ShapeCreationException("Circle radius must be greater than zero!");

        _radius = radius;
    }

    public override double Area() => Math.PI * Math.Pow(_radius, 2);
}
