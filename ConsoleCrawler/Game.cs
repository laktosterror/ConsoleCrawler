namespace ConsoleCrawler;

class Game
{
    public static int Turns = 0;
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        
        LevelData levelData = new LevelData(@"C:\Users\TEST\RiderProjects\ConsoleCrawler\ConsoleCrawler\Levels\Level1.txt");
        BeginGameLoop(levelData);
    }

    static void BeginGameLoop(LevelData levelData)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Crawler!");
            Console.WriteLine("Press any key to continue...");
            
            levelData.DrawAll();
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    levelData.Player?.Update(0, -1, levelData.Elements);
                    break;
                case ConsoleKey.DownArrow:
                    levelData.Player?.Update(0, 1, levelData.Elements);

                    break;
                case ConsoleKey.LeftArrow:
                    levelData.Player?.Update(-1, 0, levelData.Elements);

                    break;
                case ConsoleKey.RightArrow:
                    levelData.Player?.Update(1, 0, levelData.Elements);

                    break;
                default:
                    break;
            }
            levelData.MoveEnemies();
            levelData.CleanupDeadEnemies();
            levelData.ResetCounterAttackFlags();
        }
    }
}