namespace ConsoleCrawler;

public abstract class AliveElement(int posY, int posX) : LevelElement(posY, posX)
{
    public abstract void Move(Player player, List<LevelElement> elements);
    
    public bool CheckCollision(int newX, int newY, List<LevelElement> elements) {
        foreach (LevelElement element in elements) {
            if (this != element && newX == element.PosX && newY == element.PosY) {
                return true;
            }
        }
        return false;
    }
}