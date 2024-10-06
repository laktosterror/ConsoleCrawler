namespace ConsoleCrawler;

public static class FightManager
{
    public static bool FightResultsExist { get; set; }
    public static FightResult Result = new FightResult();
    
    public static void InitiateFightBetween(AliveElement attacker, AliveElement defender)
    {
        Result.AttackerAtkDice = attacker.AtkDice.ToString();
        Result.AttackerDefDice = attacker.DefDice.ToString();
        Result.AttackerType = attacker.GetType().Name;
        Result.AttackerDamage = attacker.GetAttackPoints();
        Result.DefenderDefence = defender.GetDefensePoints();
        
        defender.TakeDamage(Result.AttackerDamage - Result.DefenderDefence);

        Result.DefenderAtkDice = defender.AtkDice.ToString();
        Result.DefenderDefDice = defender.DefDice.ToString();
        Result.DefenderType = defender.GetType().Name;
        Result.DefenderDamage = defender.GetAttackPoints();
        Result.AttackerDefence = attacker.GetDefensePoints();

        if (defender.HealthPoints > 0)
        {
            attacker.TakeDamage(Result.DefenderDamage - Result.AttackerDefence);
        }
        
        FightResultsExist = true;
    }
    
    public static void DrawLastFightResult()
    {
        if (FightResultsExist)
        {
            var attackMessage =
                $"{Result.AttackerType} (ATK: {Result.AttackerAtkDice} => {Result.AttackerDamage}) attacked the " +
                $"{Result.DefenderType} (DEF: {Result.DefenderDefDice} => {Result.DefenderDefence})";
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(attackMessage);

            var counterAttackMessage =
                $"{Result.DefenderType} (ATK: {Result.DefenderAtkDice} => {Result.DefenderDamage}) counterattacked the " +
                $"{Result.AttackerType} (DEF: {Result.AttackerDefDice} => {Result.AttackerDefence})";
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(counterAttackMessage);
            
            FightResultsExist = false;
        }
    }
}