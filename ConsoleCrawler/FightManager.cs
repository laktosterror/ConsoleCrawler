namespace ConsoleCrawler;

public static class FightManager
{
    public static bool FightResultsExist { get; set; } = false;
    public static FightResult LastResult = new FightResult();
    
    public static void InitiateFightBetween(AliveElement attacker, AliveElement defender)
    {
        LastResult.AttackerAtkDice = attacker.AtkDice.ToString();
        LastResult.AttackerDefDice = attacker.DefDice.ToString();
        LastResult.AttackerType = attacker.GetType().Name;
        LastResult.AttackerDamage = attacker.GetAttackPoints();
        LastResult.DefenderDefence = defender.GetDefensePoints();
        
        defender.TakeDamage(LastResult.AttackerDamage - LastResult.DefenderDefence);

        LastResult.DefenderAtkDice = defender.AtkDice.ToString();
        LastResult.DefenderDefDice = defender.DefDice.ToString();
        LastResult.DefenderType = defender.GetType().Name;
        LastResult.DefenderDamage = defender.GetAttackPoints();
        LastResult.AttackerDefence = attacker.GetDefensePoints();
        
        attacker.TakeDamage(LastResult.DefenderDamage - LastResult.AttackerDefence);
        
        FightResultsExist = true;
    }
    
    public static void DrawLastFightResult()
    {
        if (FightResultsExist)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{LastResult.AttackerType} (ATK: {LastResult.AttackerAtkDice} => {LastResult.AttackerDamage}) attacked the {LastResult.DefenderType} (DEF: {LastResult.DefenderDefDice} => {LastResult.DefenderDefence})");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{LastResult.DefenderType} (ATK: {LastResult.DefenderAtkDice} => {LastResult.DefenderDamage}) counterattacked the {LastResult.AttackerType} (DEF: {LastResult.AttackerDefDice} => {LastResult.AttackerDefence})");
            
            FightResultsExist = false;
        }
    }
}