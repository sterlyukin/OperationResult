namespace OperationResult.Tests;

public class TypeForTest
{
    public int Value { get; }

    public TypeForTest(int value)
    {
        Value = value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        
        var convertedObj = (TypeForTest)obj;
        return Value == convertedObj.Value;
    }

    public override int GetHashCode()
    {
        return Value;
    }
}