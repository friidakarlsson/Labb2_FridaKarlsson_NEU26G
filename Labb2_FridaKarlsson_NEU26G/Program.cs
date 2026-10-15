
using Labb2_FridaKarlsson_NEU26G;

Console.CursorVisible = false;
Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine("Welcome to the Dungeon Crawler! \nUse arrow keys to navigate (or WASD if you prefer), if you get bored - just press ESC. \n\nThe game will start in...");
for (int i = 10; i >= 0; i--)
{
    Console.SetCursorPosition(0, 4);
    Console.WriteLine($"{i} seconds".PadRight(Console.WindowWidth));
    Thread.Sleep(1000);
}
Console.ResetColor();
Console.Clear();

Console.CursorVisible = true;
Console.WriteLine("Write your name: ");
string? playerName = Console.ReadLine();
playerName = string.IsNullOrWhiteSpace(playerName) ? "Player" : playerName;

int turns = 0;

LevelData levelData = new LevelData();
levelData.Load("Level1.txt");
Console.Clear();

Player player = new Player(levelData.PlayerStartX, levelData.PlayerStartY, playerName);
levelData.PlayerPosition = player;


while (true)
{

    Console.CursorVisible = false;
    Console.SetCursorPosition(0, 0);
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"Name: {player.Name}\t-\tHP: {player.Health.ToString().PadRight(3)}/100\t-\tTurn:{turns.ToString().PadRight(4)}");
    Console.ResetColor();

    if (player.Health <= 0)
    {
        Console.SetCursorPosition(0, 3);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("GAME OVER");
        Console.ResetColor();
        Thread.Sleep(8000);
        Console.Clear();
        break;
    }

    foreach (LevelElement element in levelData.Elements)
    {
        double distanceToSurroundingElements = Math.Sqrt(Math.Pow(player.xPosition - element.xPosition, 2) + Math.Pow(player.yPosition - element.yPosition, 2));
        if (distanceToSurroundingElements <= 5 || element.DiscoveredWall)
        {
            element.Draw();
            if (element is Wall)
            {
                element.DiscoveredWall = true;
            }
        }
    }

    foreach (LevelElement element in levelData.Elements)
    {
        if (element is Enemy)
        {
            ((Enemy)element).WasInAFight = false;
        }
    }

    player.Draw();

    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
    if (pressedKey.Key == ConsoleKey.Escape) 
    { 
        return; 
    }

    player.PlayerUpdate(pressedKey, levelData);
    turns++;

    foreach (LevelElement element in levelData.Elements)
    {
        if (element is Enemy)
        {
            if (((Enemy)element).WasInAFight)
            {
                continue;
            }

            ((Enemy)element).Update(levelData);
        }
    }

    for (int i = levelData.Elements.Count - 1; i >= 0; i--)
    {
        if (levelData.Elements[i] is Enemy && ((Enemy)levelData.Elements[i]).Health <= 0)
        {
            levelData.Elements.RemoveAt(i);
        }
    }
}



