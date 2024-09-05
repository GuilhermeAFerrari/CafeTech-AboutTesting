using CafeTechCalculator.Models;

namespace CafeTechCalculator.Services;

public class CalculatorService
{
    public Task<Result<double>> Addition(double firstValue, double secondValue)
    {
        var result = firstValue + secondValue;
        if (result > 1000) throw new Exception("O resultado não pode ser superior a 1K");

        return Task.FromResult(new Result<double>
        {
            Succeeded = true,
            Data = result
        });
    }

    public Task<Result<double>> Subtraction(double firstValue, double secondValue)
    {
        return Task.FromResult(new Result<double>
        {
            Succeeded = true,
            Data = firstValue - secondValue
        });
    }

    public Task<Result<double>> Multiplication(double firstValue, double secondValue)
    {
        var result = firstValue * secondValue;
        if (result > 10000)
        {
            return Task.FromResult(new Result<double>
            {
                Succeeded = false,
                Error = "O resultado não pode ser superior a 10K"
            });
        }

        return Task.FromResult(new Result<double>
        {
            Succeeded = true,
            Data = firstValue * secondValue
        });
    }

    public Task<Result<double>> Divison(double firstValue, double secondValue)
    {
        return Task.FromResult(new Result<double>
        {
            Succeeded = true,
            Data = firstValue / secondValue
        });
    }
}