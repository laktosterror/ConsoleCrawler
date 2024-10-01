namespace ConsoleCrawler;

public class Player(int posY, int posX) : AliveElements(posY, posX)
{
    public override char ElementType { get; } = '@';
    public override ConsoleColor ElementColor { get; } = ConsoleColor.Yellow;
}