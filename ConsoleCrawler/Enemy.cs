namespace ConsoleCrawler;

public abstract class Enemy(int posY, int posX) : AliveElement(posY, posX)
{
    public override void Draw()
    {
        if (this.IsVisible)
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = ElementColor;
            Console.WriteLine(ElementType.ToString());
        }
    }
}