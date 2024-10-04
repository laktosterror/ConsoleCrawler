
namespace ConsoleCrawler;

public class Wall(int posY, int posX) : LevelElement(posY, posX)
{
    public override char ElementType { get; } = '#';
    public override ConsoleColor ElementColor { get; } = ConsoleColor.Gray;

    public override void Draw()
    {
        if (this.IsDiscovered)
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = ElementColor;
            Console.WriteLine(ElementType.ToString());
        }
    }
}