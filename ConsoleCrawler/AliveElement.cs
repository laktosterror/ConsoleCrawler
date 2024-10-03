namespace ConsoleCrawler;

public abstract class AliveElement(int posY, int posX) : LevelElement(posY, posX)
{
    public bool HasCounterAttacked { get; set; }
    public abstract float HealthPoints { get; set; }
    public abstract Dice Dice { get; set; }
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
    
    public void Attack(AliveElement target)
    {
        var attackDamage = Dice.Throw(); 
        target.TakeDamage(attackDamage);
    }
    
    public void TakeDamage(int damage)
    {
        var defenceDices = Dice.Throw();
        var totalDamage = damage - defenceDices;
        
        this.HealthPoints -= totalDamage <= 0 ? 0 : totalDamage;
    }

    public void CounterAttack(AliveElement attacker)
    {
        if (!HasCounterAttacked)
        {
            HasCounterAttacked = true;
            Attack(attacker);
        }
    }

    public void Act(int newX, int newY, List<LevelElement> elements)
    {
        // Check for collision before moving
        var collidedElement = IsCollidingWith(newX, newY, elements);
        switch (collidedElement)
        {
            case AliveElement aliveElement:
                if (this is Player && aliveElement is Enemy || this is Enemy && aliveElement is Player)
                {
                    Attack(aliveElement);
                    aliveElement.CounterAttack(this);
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