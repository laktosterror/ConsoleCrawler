namespace ConsoleCrawler;

public class LevelData
{
    public LevelData(string filePath)
    {
        Load(filePath);
    }
    public readonly List<LevelElement> Elements = [];

    public Player? Player = null;
    
    private void Load(string filePath)
    {
        using (var streamReader = new StreamReader(filePath))
        {
            string? line;
            int row = 0;
            while ((line = streamReader.ReadLine()) != null)
            {
                var column = 0;
                foreach (var character in line)
                {
                    switch (character)
                    {
                        case '@':
                            Player = new Player(row, column);
                            Elements.Add(Player); // add ref type player to list
                            break;
                        case 'r':
                            Elements.Add(new Rat(row, column));
                            break;
                        case 's':
                            Elements.Add(new Snake(row, column));
                            break;
                        case '#':
                            Elements.Add(new Wall(row, column));
                            break;
                        default:
                            break;
                    }
                    column++;
                }
                row++;
            }
        }
    }

    public void DrawAll()
    {
        foreach (var element in Elements)
        {
            element.Draw();
        }
        Player.Draw();
    }

    public void MoveEnemies()
    {
        for (int i = 0; i < Elements.Count; i++)
        {
            if (Elements[i] is Snake snake && snake.HealthPoints <= 0)
            {
                Elements.RemoveAt(i);
            }
        }
        foreach (var element in Elements.OfType<Enemy>())
        {
            element.Update(Player, Elements);
        }
    }

    public void CleanupDeadEnemies()
    {

        for (int i = Elements.Count -1; i >= 0; i--)
        {
            if (Elements[i] is AliveElement aliveElement && aliveElement.HealthPoints <= 0)
            {
                Elements.RemoveAt(i);
            }
        }
    }

    public void ResetCounterAttackFlags()
    {
        foreach (var element in Elements.OfType<AliveElement>())
        {
            element.HasCounterAttacked = false;
        }
    }
}