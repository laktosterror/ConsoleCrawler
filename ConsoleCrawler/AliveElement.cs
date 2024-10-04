namespace ConsoleCrawler;

public abstract class AliveElement(int posY, int posX) : LevelElement(posY, posX)
{
    public abstract float HealthPoints { get; set; }
    public abstract Dice AtkDice { get; set; }
    public abstract Dice DefDice { get; set; }
    public abstract void Update(Player player, List<LevelElement> elements);

    public LevelElement? IsCollidingWith(int newX, int newY, List<LevelElement> elements) {
        foreach (LevelElement element in elements) {
            if (this != element && newX == element.PosX && newY == element.PosY) {
                return element;
            }
        }
        return null;
    }
    
    public double DistanceTo(AliveElement other)
    {
        int deltaX = this.PosX - other.PosX;
        int deltaY = this.PosY - other.PosY;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }
    
    public int GetAttackPoints()
    {
        var attackPoints = AtkDice.Throw();
        return attackPoints;
    }

    public int GetDefensePoints()
    {
        var defensePoints = DefDice.Throw();
        return defensePoints;
    }
    
    public void TakeDamage(int damageToDeal)
    {
        this.HealthPoints -= damageToDeal <= 0 ? 0 : damageToDeal;
    }

    public void HandleMovementAndCollision(int newX, int newY, List<LevelElement> elements)
    {
        // Check for collision before moving
        var collidedElement = IsCollidingWith(newX, newY, elements);
        switch (collidedElement)
        {
            case AliveElement aliveElement:
                if (this is Player && aliveElement is Enemy || this is Enemy && aliveElement is Player)
                {
                    FightManager.InitiateFightBetween(this, aliveElement);
                }
                break;
            case Wall:
                break;
            default:
                MoveTo(newX, newY);
                break;
        }
    }
    
    public void MoveTo(int moveToX, int moveToY)
    {
        this.PosX = moveToX;
        this.PosY = moveToY;
    }
}