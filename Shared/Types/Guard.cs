namespace Shared.Types;

public class Guard
{
    private readonly List<ApplicationError> _errors = [];
    
    public static Validation Check(string fieldName, object value)
    {
        return new Validation(fieldName, value);
    }

    public void AddError(string fieldName, string message) => _errors.Add(ApplicationError.Of(fieldName, message));
    
    public bool HasErrors() => _errors.Count > 0;
    
    public IEnumerable<ApplicationError> GetErrors() => _errors;
    
    public void ClearErrors() => _errors.Clear();
}