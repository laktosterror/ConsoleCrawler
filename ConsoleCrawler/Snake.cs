namespace ConsoleCrawler;

public class Snake(int posY, int posX) : Enemy(posY, posX)
{
    public override Dice Dice { get; set; } = new(3, 6, 2);
    public override float HealthPoints { get; set; } = 100;
    public override char ElementType { get; } = 's';
    public override ConsoleColor ElementColor { get; } = ConsoleColor.Magenta;
    
    public override void Update(Player player, List<LevelElement> elements) {
        if (this.DistanceTo(player) <= 1.0) {
            int newX = this.PosX, newY = this.PosY;
            
            if (this.PosX < player.PosX) newX--;
            else if (this.PosX > player.PosX) newX++;
            else if (this.PosY < player.PosY) newY--;
            else if (this.PosY > player.PosY) newY++;
            
            Act(newX, newY, elements);
        }
    }
}