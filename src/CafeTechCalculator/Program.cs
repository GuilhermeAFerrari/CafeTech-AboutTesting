using CafeTechCalculator.Services;

namespace CafeTechCalculator;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSingleton<CalculatorService>();

        var app = builder.Build();

        MapActions(app);

        app.Run();
    }

    public static void MapActions(WebApplication app)
    {
        app.MapPost("/addition", async (CalculatorService calculatorService, RequestModel request) =>
            {
                if (double.IsNaN(request.FirstValue) || double.IsInfinity(request.FirstValue))
                {
                    return Results.BadRequest("O primeiro valor deve ser um número válido");
                }

                if (double.IsNaN(request.SecondValue) || double.IsInfinity(request.SecondValue))
                {
                    return Results.BadRequest("O segundo valor deve ser um número válido");
                }

                var result = await calculatorService.Addition(request.FirstValue, request.SecondValue);

                if (!result.Succeeded)
                    return Results.BadRequest(result.Error);

                return Results.Ok(result.Data);
            })
            .ProducesValidationProblem()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("Addition")
            .WithTags("Calculator");

        app.MapPost("/subtraction", async (CalculatorService calculatorService, RequestModel request) =>
            {
                if (double.IsNaN(request.FirstValue) || double.IsInfinity(request.FirstValue))
                {
                    return Results.BadRequest("O primeiro valor deve ser um número válido");
                }

                if (double.IsNaN(request.SecondValue) || double.IsInfinity(request.SecondValue))
                {
                    return Results.BadRequest("O segundo valor deve ser um número válido");
                }

                var result = await calculatorService.Subtraction(request.FirstValue, request.SecondValue);

                if (!result.Succeeded)
                    return Results.BadRequest(result.Error);

                return Results.Ok(result.Data);
            })
            .ProducesValidationProblem()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("Subtraction")
            .WithTags("Calculator");

        app.MapPost("/multiplication", async (CalculatorService calculatorService, RequestModel request) =>
            {
                if (double.IsNaN(request.FirstValue) || double.IsInfinity(request.FirstValue))
                {
                    return Results.BadRequest("O primeiro valor deve ser um número válido");
                }

                if (double.IsNaN(request.SecondValue) || double.IsInfinity(request.SecondValue))
                {
                    return Results.BadRequest("O segundo valor deve ser um número válido");
                }

                var result = await calculatorService.Multiplication(request.FirstValue, request.SecondValue);

                if (!result.Succeeded)
                    return Results.BadRequest(result.Error);

                return Results.Ok(result.Data);
            })
            .ProducesValidationProblem()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("Multiplication")
            .WithTags("Calculator");

        app.MapPost("/division", async (CalculatorService calculatorService, RequestModel request) =>
            {
                if (double.IsNaN(request.FirstValue) || double.IsInfinity(request.FirstValue))
                {
                    return Results.BadRequest("O primeiro valor deve ser um número válido");
                }

                if (double.IsNaN(request.SecondValue) || double.IsInfinity(request.SecondValue))
                {
                    return Results.BadRequest("O segundo valor deve ser um número válido");
                }

                var result = await calculatorService.Divison(request.FirstValue, request.SecondValue);

                if (!result.Succeeded)
                    return Results.BadRequest(result.Error);

                return Results.Ok(result.Data);
            })
            .ProducesValidationProblem()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName("Divison")
            .WithTags("Calculator");
    }

    public class RequestModel
    {
        public double FirstValue { get; set; }
        public double SecondValue { get; set; }
    }
}