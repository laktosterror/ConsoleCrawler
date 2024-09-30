namespace ConsoleCrawler;

public class Rat(int posY, int posX) : Enemy(posY, posX)
{
    public override char ElementType { get; } = 'r';
    public override ConsoleColor ElementColor { get; } = ConsoleColor.DarkGreen;

    
}