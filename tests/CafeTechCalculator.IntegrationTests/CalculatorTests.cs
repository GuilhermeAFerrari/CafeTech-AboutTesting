using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using static CafeTechCalculator.Program;

namespace CafeTechCalculator.IntegrationTests;

public class CalculatorTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Theory]
    [InlineData(10, 20, 200.0)]
    [InlineData(0.0, 0.0, 0.0)]
    [InlineData(500.0, 2, 1000.0)]
    public async Task Multiplication_ValidParameters_ReturnsExpectedResult(double firstValue, double secondValue, double expectedResult)
    {
        // Arrange
        var requestModel = new RequestModel
        {
            FirstValue = firstValue,
            SecondValue = secondValue
        };

        // Act
        var response = await _client.PostAsJsonAsync("/multiplication", requestModel);
        response.EnsureSuccessStatusCode(); // Lança uma exceção se o status não for 2xx

        var result = await response.Content.ReadFromJsonAsync<double>();

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public async Task Multiplication_InvalidParameters_ReturnsBadRequest()
    {
        // Arrange
        var requestModel = new RequestModel
        {
            FirstValue = 1000,
            SecondValue = 20
        };

        // Act
        var response = await _client.PostAsJsonAsync("/multiplication", requestModel);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal("\"O resultado não pode ser superior a 10K\"", await response.Content.ReadAsStringAsync());
    }
}