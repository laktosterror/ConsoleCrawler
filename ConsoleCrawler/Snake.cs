namespace ConsoleCrawler;

public class Snake(int posY, int posX) : Enemy(posY, posX)
{
    public override char ElementType { get; } = 's';
    public override ConsoleColor ElementColor { get; } = ConsoleColor.Magenta;
    
    public override void Move(Player player, List<LevelElement> elements) {
        if (Math.Abs(this.PosX - player.PosX) <= 1 && Math.Abs(this.PosY - player.PosY) <= 1) {
            int newX = this.PosX, newY = this.PosY;
            
            if (this.PosX < player.PosX) newX--;
            else if (this.PosX > player.PosX) newX++;
            else if (this.PosY < player.PosY) newY--;
            else if (this.PosY > player.PosY) newY++;
            
            // Check for collision before moving
            if (!CheckCollision(newX, newY, elements)) {
                this.PosX = newX;
                this.PosY = newY;
            }
        }
    }
}