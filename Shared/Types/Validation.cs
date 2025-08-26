namespace Shared.Types;

public class Validation
{
    private readonly string _fieldName;
    private readonly object? _value;
    private readonly List<string> _errorMessages = [];

    public Validation(string fieldName, object value)
    {
        _fieldName = fieldName;
        _value = value;
    }
    
    public void Validate(Guard guard)
    {
        foreach (var error in _errorMessages)
        {
            guard.AddError(_fieldName, error);
        }
    }
}