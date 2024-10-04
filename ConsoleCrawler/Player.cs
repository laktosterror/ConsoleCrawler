namespace ConsoleCrawler;

public class Player(int posY, int posX, string name) : AliveElement(posY, posX)
{
    
    public string Name { get; } = name;
    public override Dice Dice { get; set; } = new(6, 6, 2);
    
    public override float HealthPoints { get; set; } = 120;
    public override char ElementType { get; } = '@';
    public override ConsoleColor ElementColor { get; } = ConsoleColor.Yellow;

    public override void Update(Player player, List<LevelElement> elements)
    {
        throw new NotImplementedException();
    }

    public void Update(int deltaX, int deltaY, List<LevelElement> elements) {
        int newX = this.PosX + deltaX;
        int newY = this.PosY + deltaY;
        
        HandleMovementAndCollision(newX, newY, elements);
    }
}