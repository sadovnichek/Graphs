namespace Graphs;

internal class Program
{
    public static Graph Input()
    {
        var n = int.Parse(Console.ReadLine());
        var matrix = new double[n, n];
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split().Select(x => double.Parse(x)).ToList();
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
        var s = int.Parse(Console.ReadLine());
        var t = int.Parse(Console.ReadLine());
        var result = new FordFulkersonAlgorithm(graph, s, t).Implement();
        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                Console.Write(result[i,j] + " ");
            }
            Console.WriteLine();
        }
    }
}