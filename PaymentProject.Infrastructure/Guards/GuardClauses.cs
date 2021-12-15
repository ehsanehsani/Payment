using PaymentProject.Core.Data;

namespace PaymentProject.Infrastructure.Guards;

public static class GuardClauses
{
    public static void IsNotNull(object argumentValue, string argumentName)
    {
        if (argumentValue == null) 
            throw new ArgumentNullException(argumentName);
    }

    public static void IsNotNullOrEmpty(string argumentValue, string argumentName)
    {
        if (string.IsNullOrEmpty(argumentValue)) 
            throw new ArgumentNullException(argumentName);
    }

    public static void IsNotZero(decimal argumentValue, string argumentName)
    {
        if (argumentValue == 0) 
            throw new ArgumentException($"Argument {argumentName} cannot be zero",
                argumentName);
    }

    public static void IsLessThan(decimal maxValue, decimal argumentValue, string argumentName)
    {
        if (argumentValue >= maxValue) 
            throw new ArgumentException($"Argument {argumentName} cannot exceed {maxValue}",
                argumentName);
    }

    public static void IsMoreThan(decimal minValue, decimal argumentValue, string argumentName)
    {
        if (argumentValue <= minValue) 
            throw new ArgumentException($"Argument {argumentName}  cannot be lower than {minValue}",
                argumentName);
    }
}