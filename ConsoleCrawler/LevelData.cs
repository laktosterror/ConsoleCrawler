namespace ConsoleCrawler;

public class LevelData
{
    public List<LevelElement> elements = [];

    public Player player = null;
    
    public void Load(string filePath)
    {
        using (var streamReader = new StreamReader(filePath))
        {
            string line;
            int row = 0;
            while ((line = streamReader.ReadLine()) != null)
            {
                var column = 0;
                foreach (var character in line)
                {
                    switch (character)
                    {
                        case '@':
                            player = new Player(row, column);
                            break;
                        case 'r':
                            elements.Add(new Rat(row, column));
                            break;
                        case 's':
                            elements.Add(new Snake(row, column));
                            break;
                        case '#':
                            elements.Add(new Wall(row, column));
                            break;
                        default:
                            break;
                    }
                    column++;
                }
                row++;
            }
        }
    }

    public void DrawAll()
    {
        foreach (var element in elements)
        {
            element.Draw();
        }
        player.Draw();
    }
}