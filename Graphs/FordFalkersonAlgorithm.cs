namespace Graphs;

public class FordFulkersonAlgorithm
{
    private static int _s;
    private static int _t;
    private Graph graph;
    private int[] h;
    private int[] previous;

    private void Labeling()
    {
        var queue = new Queue<int>();
        foreach (var vertex in graph.Vertexes)
        {
            h[vertex] = int.MaxValue;
        }
        queue.Enqueue(_s);
        previous[_s] = -1;
        while (h[_t] == int.MaxValue && queue.Count > 0)
        {
            
        }
    }
}