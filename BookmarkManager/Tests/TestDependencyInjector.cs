namespace BookmarkManager.Tests;

public class TestDependencyInjector
{
    private readonly Dictionary<Type, object> _instances = new();

    public void Register<T>(T instance) where T : class
    {
        _instances[typeof(T)] = instance;
    }

    public T Resolve<T>() where T : class
    {
        return (T)_instances[typeof(T)];
    }

    public void Clear()
    {
        _instances.Clear();
    }
}