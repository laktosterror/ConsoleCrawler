namespace ConsoleCrawler;

public class Dice(int numberOfDice, int sidesPerDice, int modifier)
{
  private int NumberOfDice { get; set; } = numberOfDice;
  private int SidesPerDice { get; set; } = sidesPerDice;
  private int Modifier { get; set; } = modifier;
  private readonly Random _random = new Random();

  public int Throw()
  {
    int roll = 0;
    for (int i = 0; i < NumberOfDice; i++)
    {
      roll += _random.Next(1, SidesPerDice);
    }
    return roll + Modifier;
  }

  public override string ToString()
  {
    return $"{NumberOfDice}d{SidesPerDice}+{Modifier}";
  }
}