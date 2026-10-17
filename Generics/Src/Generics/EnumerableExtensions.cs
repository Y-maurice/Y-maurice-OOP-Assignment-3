namespace Generics;

public static class EnumerableExtensions
{
    public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentOutOfRangeException.ThrowIfLessThan(pageNumber, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1);

        return PageIterator(source, pageNumber, pageSize);
    }

    private static IEnumerable<T> PageIterator<T>(IEnumerable<T> source, int pageNumber, int pageSize)
    {
        long start = (long)(pageNumber - 1) * pageSize;
        long end = start + pageSize;
        long index = 0;

        foreach (var item in source)
        {
            if (index >= end)
                yield break;

            if (index >= start)
                yield return item;

            index++;
        }
    }

    public static T? FindById<T>(this IEnumerable<T> source, int id) where T : IHasId
    {
        ArgumentNullException.ThrowIfNull(source);

        foreach (var item in source)
        {
            if (item.Id == id)
                return item;
        }

        return default;
    }

    public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(this IEnumerable<T> source) where T : IHasId
    {
        ArgumentNullException.ThrowIfNull(source);

        var result = new Dictionary<int, T>();

        foreach (var item in source)
        {
            if (!result.TryAdd(item.Id, item))
                throw new ArgumentException(
                    $"Duplicate Id {item.Id} found while building the dictionary.", nameof(source));
        }

        return result;
    }
}
