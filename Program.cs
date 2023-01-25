using System.Threading.Channels;

namespace ConsoleApp1;
 class Program 
 {
     //відображення масиву в консолі
    public static void Show (char[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++) 
        {
            for (int j = 0; j < array.GetLength(1); j++) 
            {
                Console.Write(array[i,j] + " ");
            }
            Console.WriteLine();
        }
    }
    public static void Main(string[] args) {

        char[,] array = 
        {
            {'#', 'S', '#','.','.','.','.','#'},
            {'#', '.', '#','.','#','#','.','#'},
            {'#', '.', '.','.','#','.','.','#'},
            {'#', '#', '#','#','.','.','#','#'},
            {'#', '.', '.','.','.','#','F','#'},
            {'#', '.', '#','.','.','#','.','#'},
            {'#', '.', '#','#','#','#','.','#'},
            {'#', '.', '.','.','.','.','.','#'}
        };
        DFS dfs = new DFS(array);
        dfs.Dfs();
        Show(array);

    }
}