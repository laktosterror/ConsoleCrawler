namespace ConsoleCrawler;

public class Player(int posY, int posX) : LevelElement(posY, posX)
{
    public override char ElementType { get; } = '@';
    public override ConsoleColor ElementColor { get; } = ConsoleColor.Yellow;
}