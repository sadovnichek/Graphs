namespace Graphs;

public class Graph
{
    public readonly List<int> Vertexes = new();

    public readonly List<GraphEdge> Edges = new();
    
    public double[,] Matrix { get; }

    public Graph()
    {  }
    
    public Graph(double[,] matrix)
    {
        Matrix = matrix;
        Vertexes = Enumerable.Range(0, matrix.GetLength(0)).ToList();
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            for(int j = 0; j < matrix.GetLength(0); j++)
            {
                AddEdge(new GraphEdge(i, j, matrix[i, j]));
            }
        }
    }
    
    public void AddEdge(GraphEdge edge)
    {
        Edges.Add(edge);
        if(!Vertexes.Contains(edge.Start))
            Vertexes.Add(edge.Start);
        if(!Vertexes.Contains(edge.End))
            Vertexes.Add(edge.End);
    }

    public Dictionary<int, List<int>> GetAdjacencyList()
    {
        var result = new Dictionary<int, List<int>>();
        foreach (var v in Vertexes)
        {
            var neighbours = new List<int>();
            foreach (var edge in Edges)
            {
                if(edge.Start == v)
                    neighbours.Add(edge.End);
                if(edge.End == v)
                    neighbours.Add(edge.Start);
            }
            neighbours.Sort();
            result.Add(v, neighbours);
        }

        return result;
    }
}