namespace Day8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Part1();
        }

        private static void Part1()
        {
            var grid = LoadGrid();
            int count = 0;
            for (int i = 0; i < 99; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    var tree = grid[i, j];
                    var up = Enumerable.Range(0, j).All(x => grid[i, x].height < tree.height);
                    var down = Enumerable.Range(j + 1, 98 - j).All(x => grid[i, x].height < tree.height);
                    var left = Enumerable.Range(0, i).All(x => grid[x, j].height < tree.height);
                    var right = Enumerable.Range(i + 1, 98 - i).All(x => grid[x, j].height < tree.height);
                    if (grid[i, j].visible = up || down || left || right)
                        count++;
                }
            }
            Console.WriteLine(count);
        }

        private static (int height, bool visible)[,] LoadGrid()
        {
            var grid = new (int, bool)[99, 99];
            using var input = File.OpenText("input.txt");
            var line = input.ReadLine();
            int count = 0;
            while (line != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    grid[count, i] = (int.Parse(line[i].ToString()), false);
                }
                count++;
                line = input.ReadLine();
            }
            return grid;
        }
    }
}