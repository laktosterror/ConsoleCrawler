namespace ConsoleCrawler;

public class LevelData
{
    public List<LevelElement> elements = [];
    
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
                            elements.Add(new Player(column, row));
                            break;
                        case 'r':
                            elements.Add(new Rat(column, row));
                            break;
                        case 's':
                            elements.Add(new Snake(column, row));
                            break;
                        case '#':
                            elements.Add(new Wall(column, row));
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
    }
}