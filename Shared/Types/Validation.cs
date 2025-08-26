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


    public Validation MinLength(int min)
    {
        if(_value is string fieldValue && fieldValue.Length < min)
            _errorMessages.Add($"Field '{_fieldName}' must be grater than {min} characters.");
        
        return this;
    }

    public Validation MaxLength(int max)
    {
        if(_value is string fieldValue && fieldValue.Length > max)
            _errorMessages.Add($"Field '{_fieldName}' must be lower than {max} characters.");
        
        return this;
    }
    
    public void Validate(Guard guard)
    {
        foreach (var error in _errorMessages)
        {
            guard.AddError(_fieldName, error);
        }
    }
}