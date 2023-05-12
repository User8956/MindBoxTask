namespace ShapesLibTests;

public class TriangleTests
{
    private const int PRECISION = 4;

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(10, 8, 5)]
    [InlineData(3.21, 4.212, 3.5)]
    public void Triangle_Creation_Success(double a, double b, double c) => Assert.IsType<Triangle>(new Triangle(a, b, c));

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(-3, 4, 5)]
    [InlineData(3, -4, 5)]
    [InlineData(3, 4, -5)]
    [InlineData(-3, -4, -5)]
    public void Triangle_Creation_Fail_Non_Positive_Sides(double a, double b, double c) => Assert.Throws<ShapeCreationException>(() => new Triangle(a, b, c));

    [Theory]
    [InlineData(7, 3, 4)]
    [InlineData(3, 7, 4)]
    [InlineData(3, 4, 7)]
    public void Triangle_Creation_Fail_Sides_Dont_Form_A_Triangle(double a, double b, double c) => Assert.Throws<ShapeCreationException>(() => new Triangle(a, b, c));


    [Theory]
    [InlineData(3, 4, 5, 6)]
    [InlineData(10, 8, 5, 19.81)]
    [InlineData(3.21, 4.212, 3.5, 5.4871)]
    public void Triangle_Area(double a, double b, double c, double expectedArea)
    {
        // Arrange
        var triangle = new Triangle(a, b, c);

        // Act
        var area = triangle.Area();

        // Assert
        Assert.Equal(expectedArea, area, PRECISION);
    }

    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(10, 8, 5, false)]
    [InlineData(3.21, 4.212, 3.5, false)]
    public void Is_Triangle_Rectangular(double a, double b, double c, bool expectedResult)
    {
        // Arrange
        var triangle = new Triangle(a, b, c);

        // Act
        var IsRectangular = triangle.IsRectangular();

        // Assert
        Assert.Equal(expectedResult, IsRectangular);
    }
}