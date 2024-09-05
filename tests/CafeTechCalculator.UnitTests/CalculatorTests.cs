using CafeTechCalculator.Services;

namespace CafeTechCalculator.UnitTests;

public class CalculatorTests
{
    [Fact]
    public async Task Addition_WithValidParameters_ShouldReturnSum()
    {
        // Arrange
        var sut = new CalculatorService();
        var firstValue = 10;
        var secondValue = 20;

        // Act
        var result = await sut.Addition(firstValue, secondValue);

        // Assert
        Assert.Equal(30, result.Data);
    }

    [Fact]
    public async Task Addition_OverAThousand_ShouldReturnException()
    {
        // Arrange
        var sut = new CalculatorService();
        var firstValue = 999;
        var secondValue = 2;

        // Act & Assert
        var result = await Assert.ThrowsAsync<Exception>(() => sut.Addition(firstValue, secondValue));

        // Verifica a mensagem da exceção
        Assert.Equal("O resultado não pode ser superior a 1K", result.Message);
    }


    [Theory]
    [InlineData(10, 20, 30)]
    [InlineData(-5, 5, 0)]
    [InlineData(0, 0, 0)]
    [InlineData(100, 200, 300)]
    public async Task Addition_WithValidParameters_ShouldReturnSum_Theory(double firstValue, double secondValue, double expectedResult)
    {
        // Arrange
        var sut = new CalculatorService();

        // Act
        var result = await sut.Addition(firstValue, secondValue);

        // Assert
        Assert.Equal(expectedResult, result.Data);
    }
}