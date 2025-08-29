using Bookmarks.Domain.Service;
using Bookmarks.Infrastructure.Repository;

namespace BookmarkManager.Tests;

public class DependencyFixture: IDisposable
{
    private readonly TestDependencyInjector _injector = new TestDependencyInjector();

    public DependencyFixture()
    {
        
        _injector.Register<IBookmarkRepository>(new InMemoryBookmarkRepository());
        
        _injector.Register<IBookmarkService>(new BookmarkService(
            bookmarkRepository: _injector.Resolve<IBookmarkRepository>()
        ));
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