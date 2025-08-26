namespace BookmarkManager.Tests;

public class DependencyFixture: IDisposable
{
    private readonly TestDependencyInjector _injector = new TestDependencyInjector();

    public DependencyFixture()
    {
    }
    
    public T GetService<T>() where T : class
    {
        return _injector.Resolve<T>();
    }
    
    public void Dispose()
    {
        _injector.Clear();
    }
}