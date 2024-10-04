namespace ConsoleCrawler;

public class FightResult
{
    public string AttackerType { get; set; } = string.Empty;
    public string AttackerAtkDice { get; set; } = string.Empty;
    public string AttackerDefDice { get; set; } = string.Empty;
    public int AttackerDamage { get; set; }
    public int DefenderDefence { get; set; }
    

    public string DefenderType { get; set; } = string.Empty;
    public string DefenderAtkDice { get; set; } = string.Empty;
    public string DefenderDefDice { get; set; } = string.Empty;
    public int DefenderDamage { get; set; }
    public int AttackerDefence { get; set; }
        
}