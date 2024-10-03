namespace ConsoleCrawler;

public abstract class AliveElement(int posY, int posX) : LevelElement(posY, posX)
{
    public abstract float HealthPoints { get; set; }
    public abstract Dice Dice { get; set; }
    public abstract void Update(Player player, List<LevelElement> elements);

    public LevelElement? IsCollidingWith(int newX, int newY, List<LevelElement> elements) {
        foreach (LevelElement element in elements) {
            if (this != element && newX == element.PosX && newY == element.PosY) {
                return true;
            }
        }
        return false;
    }
    
    public double DistanceTo(AliveElement other)
    {
        int deltaX = this.PosX - other.PosX;
        int deltaY = this.PosY - other.PosY;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }
    public void MoveTo(int moveToX, int moveToY)
    {
        this.PosX = moveToX;
        this.PosY = moveToY;
    }
    
}