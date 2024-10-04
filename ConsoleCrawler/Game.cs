namespace ConsoleCrawler;

class Game
{
    public static int Turns = 0;
    static void Main(string[] args)
    {
        var levelData = new LevelData();
        levelData.Load(@"C:\Users\TEST\RiderProjects\ConsoleCrawler\ConsoleCrawler\Levels\Level1.txt");
        Console.Write("Enter your name: ");
        levelData.Player.Name = Console.ReadLine();
        
        Console.CursorVisible = false;
        BeginGameLoop(levelData);
    }

    static void BeginGameLoop(LevelData levelData)
    {
        while (levelData.Player.HealthPoints >= 0)
        {
            Console.Clear();
            levelData.DrawPlayerStatus();
            FightManager.DrawLastFightResult();
            levelData.DrawAllElements();
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

            Turns++;
        }
        Console.Clear();
        Console.WriteLine("Game Over");
    }
}