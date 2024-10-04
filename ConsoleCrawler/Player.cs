namespace ConsoleCrawler;

public class Player(int posY, int posX) : AliveElement(posY, posX)
{
    
    public string Name { get; set; } = String.Empty;
    public override Dice AtkDice { get; set; } = new(2, 6, 2);
    public override Dice DefDice { get; set; } = new(2, 6, 0);
    
    public override float HealthPoints { get; set; } = 100;
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