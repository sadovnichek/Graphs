namespace Graphs;

public class Point
{
    public int X { get; set; }

    public int Y { get; set; }

    public int DistanceTo(Point other)
    {
        return Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
    }

    public override string ToString()
    {
        return $"[{X}, {Y}]";
    }
}