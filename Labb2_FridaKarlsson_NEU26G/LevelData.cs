

namespace Labb2_FridaKarlsson_NEU26G
{
    internal class LevelData
    {
        public int PlayerStartX = 0;
        public int PlayerStartY = 0;
        public Player PlayerPosition { get; set; }
        private List<LevelElement> elements;
        public List<LevelElement> Elements
        {
            get { return elements; }
        }
        public void Load(string filename)
        {
            elements = new List<LevelElement>();
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
                        case '@': { PlayerStartX = x; PlayerStartY = y; x++; continue; }
                        case '#': { elements.Add(new Wall(x, y)); break; }
                        case 'r': { elements.Add(new Rat(x, y)); break; }
                        case 's': { elements.Add(new Snake(x, y)); break; }
                    }

                    x++;
                }

                foreach (LevelElement element in elements)
                {
                    element.Draw();
                }
            }
            catch
            {
                //Filenotfoundexception
            }
            
        }
    }
}
