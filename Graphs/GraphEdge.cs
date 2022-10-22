namespace Graphs;

public class GraphEdge
{
    public int Start { get; }

    public int End { get; }
    
    public int Weight { get; }

    public GraphEdge(int start, int end, int weight)
    {
        Start = start;
        End = end;
        Weight = weight;
    }

    public GraphEdge Inverse()
    {
        return new GraphEdge(End, Start, Weight);
    }

    public override string ToString()
    {
        return $"({Start}, {End}) : {Weight}";
    }
}