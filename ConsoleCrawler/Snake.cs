namespace ConsoleCrawler;

public class Snake(int posY, int posX) : Enemy(posY, posX)
{
    public override char ElementType { get; } = 's';
    public override ConsoleColor ElementColor { get; } = ConsoleColor.Magenta;
}