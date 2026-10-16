namespace Generics;

public class Store<T> where T : IHasId
{
    private readonly Dictionary<int, T> _items = [];


    public void Add(T item)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (!_items.TryAdd(item.Id, item))
            throw new InvalidOperationException($"An item with Id {item.Id} already exists in the store.");
    }

    public T? GetById(int id)
    {
        _items.TryGetValue(id, out var item);
        return item;

    }

    public IReadOnlyList<T> GetAll() => new List<T>(_items.Values).AsReadOnly();

    public void Remove(int id)
    {
        _items.Remove(id);
    }
}
