namespace ShapesLib;

public class Triangle : Shape
{
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;

    private static bool AreSidesFormTriangle(double a, double b, double c)
    {
        var c_is_less_than_others_sum = a + b > c;
        var b_is_less_than_others_sum = a + c > b;
        var a_is_less_than_others_sum = b + c > a;

        return a_is_less_than_others_sum && b_is_less_than_others_sum && c_is_less_than_others_sum;
    }

    public Triangle(double a, double b, double c)
    {

        if (a <= 0 || b <= 0 || c <= 0)
            throw new ShapeCreationException("All triangle sides must be greater than zero!");


        if (!AreSidesFormTriangle(a, b, c))
            throw new ShapeCreationException($"Specified sides a = {a}, b = {b}, c = {c} don't form a triangle!");

        _a = a;
        _b = b;
        _c = c;
    }

    public override double Area()
    {
        var semi_perimeter = (_a + _b + _c) / 2;
        var product = semi_perimeter * (semi_perimeter - _a) * (semi_perimeter - _b) * (semi_perimeter - _c);
        return Math.Sqrt(product);
    }

    public bool IsRectangular()
    {
        var sides = new double[]{_a, _b, _c};
        sides.OrderBy(s => s);
        var max_side_square = Math.Pow(sides[2], 2);
        var other_sides_squares_sum = Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2);
        return max_side_square == other_sides_squares_sum;
    }
}