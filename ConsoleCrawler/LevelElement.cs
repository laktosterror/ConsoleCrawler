using System.Data;

namespace ConsoleCrawler;

public abstract class LevelElement(int posY, int posX)
{
    public bool IsDiscovered { get; set; }
    public bool IsVisible { get; set; }
    public int PosY { get; set; } = posY;
    public int PosX { get; set; } = posX;
    public abstract char ElementType { get; }
    public abstract ConsoleColor ElementColor { get; }
    public abstract void Draw();
    
    public double DistanceTo(AliveElement other)
    {
        int deltaX = this.PosX - other.PosX;
        int deltaY = this.PosY - other.PosY;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }
    
    public void SetIsDiscoveredIfCloseTo(Player player)
    {
        if (this.DistanceTo(player) <= 5.0)
        {
            IsDiscovered = true;
        }
    }

    public void SetIsVisibleIfCloseTo(Player player)
    {
        if (this.DistanceTo(player) <= 5.0)
        {
            IsVisible = true;
        }
        else
        {
            IsVisible = false;
        }
    }
}