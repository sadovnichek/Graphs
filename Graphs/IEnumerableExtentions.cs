namespace Graphs;

public static class IEnumerableExtentions
{
    public static IEnumerable<int> Except(this IEnumerable<int> source, int element)
    {
        return source.Where(x => x != element);
    }
}