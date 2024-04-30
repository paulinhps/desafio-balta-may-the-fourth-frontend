using BlazorBootstrap;

public class BreadcrumbItemService : IBreadcrumbItemService
{
    public event EventHandler<BreadcrumbItemsEventArgs>? OnItemsChanged;

    public void UpdateBreadcrumbs(params BreadcrumbItem[] breadcrumbItems)
    {
        OnItemsChanged?.Invoke(this, new BreadcrumbItemsEventArgs(breadcrumbItems));
    }

    public void UpdateHasEmpty()
    => UpdateBreadcrumbs([]);
}

public interface IBreadcrumbItemService : IBreadcrumbItemServiceEvents {
    void UpdateBreadcrumbs(params BreadcrumbItem[] breadcrumbItems);
    void UpdateHasEmpty();
}

public interface IBreadcrumbItemServiceEvents {
    event EventHandler<BreadcrumbItemsEventArgs> OnItemsChanged;
    
}

public class BreadcrumbItemsEventArgs : EventArgs
{
    public BreadcrumbItemsEventArgs(IEnumerable<BreadcrumbItem> items)
    {
        Items = items;
    }
    public IEnumerable<BreadcrumbItem> Items { get; private set; } = Enumerable.Empty<BreadcrumbItem>();
}