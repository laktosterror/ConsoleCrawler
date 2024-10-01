namespace ConsoleCrawler;

class Game
{
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
            levelData.DrawAll();
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    levelData.player.Move(0, -1, levelData.elements);
                    break;
                case ConsoleKey.DownArrow:
                    levelData.player.Move(0, 1, levelData.elements);

                    break;
                case ConsoleKey.LeftArrow:
                    levelData.player.Move(-1, 0, levelData.elements);

                    break;
                case ConsoleKey.RightArrow:
                    levelData.player.Move(1, 0, levelData.elements);

                    break;
                default:
                    break;
            }
            levelData.MoveEnemies();
        }
    }
}