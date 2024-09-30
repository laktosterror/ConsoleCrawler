using System.Data;

namespace ConsoleCrawler;

public abstract class LevelElement(int posY, int posX)
{
    public int PosY { get; set; } = posY;
    public int PosX { get; set; } = posX;
    public abstract char ElementType { get; }
    public abstract ConsoleColor ElementColor { get; }

    public void Draw()
    {
        Console.SetCursorPosition(PosX, PosY);
        Console.ForegroundColor = ElementColor;
        Console.WriteLine(ElementType.ToString());
    }
}