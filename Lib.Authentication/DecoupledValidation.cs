public static class Program
{
    public static void Main()
    {
        var validator = new Validator();
        var generator = new StuffGenerator();

        Console.WriteLine(CallIfValid(validator, generator, i => i.FirstMethod));
        Console.WriteLine(CallIfValid(validator, generator, i => i.SecondMethod));
    }

    public static TOutput CallIfValid<TOutput>(
        IMethods<ValidationResult> validation,
        IMethods<TOutput> output,
        Func<IMethods<object>, Func<object>> selector)
        where TOutput : class
    {
        var result = (ValidationResult)selector(validation)();
        if (result.IsOK) {
            return (TOutput)selector(output)();
        }
        return null;
    }
}

public interface IMethods<out TResult>
    where TResult : class
{
    TResult FirstMethod();
    TResult SecondMethod();
}

public class Validator : IMethods<ValidationResult> {
    public ValidationResult FirstMethod() { return new ValidationResult(true); }
    public ValidationResult SecondMethod() { return new ValidationResult(false); }
}

public class StuffGenerator : IMethods<string> {
    public string FirstMethod() { return "first method"; }
    public string SecondMethod() { return "second method"; }
}

public class ValidationResult
{
    public ValidationResult(bool ok) { this.IsOK = ok; }

    public bool IsOK { get; private set; }
}