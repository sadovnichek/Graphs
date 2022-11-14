namespace Graphs;

public class FordFulkersonAlgorithm
{
    const double INF = double.MaxValue;
    private static int s;
    private static int t;
    private Graph graph;
    private double[] h;
    private int[] previous;
    private double[,] A;
    private double[,] F;
    private int[] choice;

    public FordFulkersonAlgorithm(Graph G, int S, int T)
    {
        graph = G;
        s = S;
        t = T;
        h = new double[G.Vertexes.Count];
        previous = new int[G.Vertexes.Count];
        A = graph.Matrix;
        F = new double[G.Vertexes.Count, G.Vertexes.Count];
        choice = new int[G.Vertexes.Count];
    }

    private void Labeling()
    {
        previous = new int[graph.Vertexes.Count];
        choice = new int[graph.Vertexes.Count];
        foreach (var v in graph.Vertexes)
        {
            h[v] = INF;
        }
        var queue = new Queue<int>();
        queue.Enqueue(s);
        previous[s] = -1;
        while (h[t] == INF && queue.Count > 0)
        {
            var w = queue.Dequeue();
            foreach (var v in graph.Vertexes) // помечивание по прямым дугам
            {
                if (h[v] == INF && (A[w, v] - F[w, v]) > 0)
                {
                    h[v] = Math.Min(h[w], A[w, v] - F[w, v]);
                    previous[v] = w;
                    queue.Enqueue(v);
                    choice[v] = 1;
                }
            }
            foreach (var v in graph.Vertexes.Except(s)) // помечивание по обратным дугам
            {
                if (h[v] == INF && F[v, w] > 0)
                {
                    h[v] = Math.Min(h[w], F[v, w]);
                    queue.Enqueue(v);
                    previous[v] = w;
                    choice[v] = -1;
                }
            }
        }
    }

    public double[,] Implement()
    {
        var flow = 0d;
        do
        {
            Labeling();
            if (h[t] < INF)
            {
                flow += h[t];
                var v = t;
                while (v != s)
                {
                    var w = previous[v];
                    if (choice[v] == 1)
                        F[w, v] += h[t];
                    else
                        F[v, w] -= h[t];
                    v = w;
                }
            }
        } while (h[t] != INF);
        Console.WriteLine($"|f| = {flow}");
        return F;
    }
}