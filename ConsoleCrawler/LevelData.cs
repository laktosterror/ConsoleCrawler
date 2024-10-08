﻿namespace ConsoleCrawler;

public class LevelData
{
    public readonly List<LevelElement> Elements = [];

    public Player? Player;
    
    public void Load(string filePath)
    {
        using var streamReader = new StreamReader(filePath);
        int consoleOffset = 3;
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
                        Player = new Player(row + consoleOffset, column);
                        Elements.Add(Player);
                        break;
                    
                    case 'r':
                        Elements.Add(new Rat(row + consoleOffset, column));
                        break;
                    
                    case 's':
                        Elements.Add(new Snake(row + consoleOffset, column));
                        break;
                    
                    case '#':
                        Elements.Add(new Wall(row + consoleOffset, column));
                        break;
                }
                column++;
            }
            row++;
        }
    }

    public void DrawAllElements()
    {
        foreach (var element in Elements)
        {
            element.Draw();
        }
    }

    public void UpdateDiscoveries()
    {
        foreach (var element in Elements)
        {
            element.SetIsDiscoveredIfCloseTo(Player);
            
        }
    }

    public void UpdateVisibility()
    {
        foreach (var element in Elements)
        {
            element.SetIsVisibleIfCloseTo(Player);
        }
    }

    public void MoveAllEnemies()
    {
        foreach (var element in Elements.OfType<Enemy>())
        {
            element.Update(Player, Elements);
        }
    }

    public void RemoveDeadEnemies()
    {

        for (int i = Elements.Count -1; i >= 0; i--)
        {
            if (Elements[i] is AliveElement aliveElement && aliveElement.HealthPoints <= 0)
            {
                Elements.RemoveAt(i);
            }
        }
    }
    
    public void DrawPlayerStatus()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"Name: {Player.Name} - Health: {Player.HealthPoints}/100 - Turn: {Game.Turns}");
    }
}