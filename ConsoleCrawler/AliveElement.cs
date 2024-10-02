namespace ConsoleCrawler;

public abstract class AliveElement(int posY, int posX) : LevelElement(posY, posX)
{
    public abstract float HealthPoints { get; set; }
    public abstract void Move(Player player, List<LevelElement> elements);
    
    public bool IsColliding(int newX, int newY, List<LevelElement> elements) {
        foreach (LevelElement element in elements) {
            if (this != element && newX == element.PosX && newY == element.PosY) {
                return true;
            }
        }
        return false;
    }
}