namespace ConsoleCrawler;

public class Player(int posY, int posX) : AliveElement(posY, posX)
{
    public override float HealthPoints { get; set; } = 120;
    public override char ElementType { get; } = '@';
    public override ConsoleColor ElementColor { get; } = ConsoleColor.Yellow;
    public override void Move(Player player, List<LevelElement> elements)
    {
        throw new NotImplementedException();
    }
    public void Move(int deltaX, int deltaY, List<LevelElement> elements) {
        int newX = this.PosX + deltaX;
        int newY = this.PosY + deltaY;
        
        // Check for collision before moving
        if (!IsColliding(newX, newY, elements)) {
            this.PosX = newX;
            this.PosY = newY;
        }
    }
}