namespace CafeTechCalculator.Models;

public class Result<T>
{
    public bool Succeeded { get; set; }
    public T? Data { get; set; }
    public string? Error { get; set; }
}