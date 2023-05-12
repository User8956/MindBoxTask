namespace ShapesLibTests;

public class CircleTests
{
    private const int PRECISION = 4;

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(4.7213)]
    public void Circle_Creation_Success(double radius) => Assert.IsType<Circle>(new Circle(radius));

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-3.421)]
    public void Circle_Creation_Fail_Non_Positive_Radius(double radius) => Assert.Throws<ShapeCreationException>(() => new Circle(radius));

    [Theory]
    [InlineData(1, 3.1416)]
    [InlineData(2, 12.5664)]
    [InlineData(4.7213, 70.0282)]
    public void Circle_Area(double radius, double expectedArea)
    {
        // Arrange
        var circle = new Circle(radius);

        // Act
        var area = circle.Area();

        // Assert
        Assert.Equal(expectedArea, area, PRECISION);
    }
}