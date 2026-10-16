namespace Generics;

public class Store<T>
{
    private readonly List<T> _items = [];


    public void Add(T item)
    {
        _items.Add(item);
    }

    public
        T? GetById(int id)
    {
        foreach (var item in _items)
        {
            if (item.Id == id)
                return item;
        }

        return null;
    }

    public IReadOnlyList<T> GetAll() => _items;

    public void Remove(int id)
    {
        var item = GetById(id);

        if (item is not null)
            _items.Remove(item);
    }
}
