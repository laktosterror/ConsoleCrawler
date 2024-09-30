namespace ConsoleCrawler;

class Game
{
    static void Main(string[] args)
    {
        BeginGameLoop();
    }

    static void BeginGameLoop()
    {
        LevelData levelData = new LevelData();
        levelData.Load(@"C:\Users\TEST\RiderProjects\ConsoleCrawler\ConsoleCrawler\Levels\Level1.txt");
        Console.CursorVisible = false;

        while (true)
        {
            Console.Clear();
            levelData.DrawAll();
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    levelData.player.PosY--;
                    break;
                case ConsoleKey.DownArrow:
                    levelData.player.PosY++;
                    break;
                case ConsoleKey.LeftArrow:
                    levelData.player.PosX--;
                    break;
                case ConsoleKey.RightArrow:
                    levelData.player.PosX++;
                    break;
                default:
                    break;
            }
            
        }
    }
}