

namespace Labb2_FridaKarlsson_NEU26G
{
    internal class LevelData
    {
        public int PlayerStartX = 0;
        public int PlayerStartY = 0;
        public Player PlayerPosition { get; set; } = null!;
        private List<LevelElement> elements = new List<LevelElement>();
        public List<LevelElement> Elements => elements;

        public void Load(string filename)
        {
            try
            {
                using StreamReader reader = new StreamReader(filename);

                int x = 0;
                int y = 0;
                char readCharacter;
                                
                while (!reader.EndOfStream)
                {
                    readCharacter = (char)reader.Read();

                    switch (readCharacter)
                    {
                        case ' ': { x++; continue; }
                        case '\n': { x = 0; y++; continue; }
                        case '\r': { continue; }
                        case '@': { PlayerStartX = x; PlayerStartY = y; x++; continue; }
                        case '#': { elements.Add(new Wall(x, y)); break; }
                        case 'r': { elements.Add(new Rat(x, y)); break; }
                        case 's': { elements.Add(new Snake(x, y)); break; }
                    }

                    x++;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Filen hittades inte och programmet kan inte köras, vänligen kontakta support.");
            }
            
        }
    }
}
