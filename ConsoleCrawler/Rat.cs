namespace ConsoleCrawler;

public class Rat(int posY, int posX) : Enemy(posY, posX)
{
    public override Dice AtkDice { get; set; } = new(1, 6, 3);
    public override Dice DefDice { get; set; } = new(1, 6, 1);
    public override float HealthPoints { get; set; } = 10;
    public override char ElementType { get; } = 'r';
    public override ConsoleColor ElementColor { get; } = ConsoleColor.DarkGreen;
    
    private Random random = new Random();
    public override void Update(Player player, List<LevelElement> elements)
    {
        int direction = random.Next(4);
        int newX = this.PosX, newY = this.PosY;
        
        if (direction == 0) newY++;
        else if (direction == 1) newY--;
        else if (direction == 2) newX--;
        else if (direction == 3) newX++;
        
        HandleMovementAndCollision(newX, newY, elements);
    }
}