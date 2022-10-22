namespace Graphs;

internal class Program
{
    public static Graph Input()
    {
        var n = int.Parse(Console.ReadLine());
        var matrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();
            for(int j = 0; j < n; j++)
            {
                matrix[i, j] = input[j];
            }
        }
        return new Graph(matrix);
    }
    
    public static void Main()
    {
        var graph = Input();
        Console.WriteLine("42");
    }
}