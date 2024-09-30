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

        while (true)
        {
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    
                    
                
            }
            
        }
        
        
        levelData.DrawAll();
        
    }
}