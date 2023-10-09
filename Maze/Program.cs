namespace Maze
{
    public class Program
    {
        static void Main(string[] args)
        {
            var gen = new MazeGenerator(20, 20);
            var maze = gen.CreateMaze();
            MazeGenerator.DebugPrint(maze);

            var pos = Seeker.Seek(maze);
            MazeGenerator.DebugPrint(maze);
            Console.WriteLine($"X : {pos.X}, Y : {pos.Y}");
        }
    }
}
