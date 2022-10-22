namespace Graphs;

public class BoruvkaKruskalAlgorithm
{
    private readonly Graph _graph;
    private readonly int _n;
    private readonly int[] _name;
    private readonly int[] _size;
    private readonly int[] _next;
    
    public BoruvkaKruskalAlgorithm(Graph graph)
    {
        _graph = graph;
        _n = _graph.Vertexes.Count;
        _name = new int[_n];
        _size = new int[_n];
        _next = new int[_n];
    }
    
    private void Merge(GraphEdge edge, int p, int q)
    {
        var v = edge.Start;
        var w = edge.End;
        _name[w] = p;
        var u = _next[w];
        while (_name[u] != p)
        {
            _name[u] = p;
            u = _next[u];
        }
        _size[p] += _size[q];
        (_next[v], _next[w]) = (_next[w], _next[v]);
    }
    
    public Graph Implement()
    {
        var queue = new Queue<GraphEdge>();
        _graph.Edges.OrderBy(edge => edge.Weight).ToList().ForEach(x => queue.Enqueue(x));
        foreach (var v in _graph.Vertexes)
        {
            _name[v] = v; _size[v] = 1; _next[v] = v;
        }
        var tree = new Graph();
        while (tree.Edges.Count != _n - 1)
        {
            var currentEdge = queue.Dequeue();
            var p = _name[currentEdge.Start];
            var q = _name[currentEdge.End];
            if (p == q) continue;
            Merge(currentEdge, p, q);
            tree.AddEdge(currentEdge);
        }
        return tree;
    }
}