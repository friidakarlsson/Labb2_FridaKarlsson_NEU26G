
using Labb2_FridaKarlsson_NEU26G;


Console.WriteLine("Write player name: ");
string? playerName = Console.ReadLine();
playerName = string.IsNullOrWhiteSpace(playerName) ? "Player" : playerName;

string attackText = string.Empty;
ConsoleColor attackTextColor = ConsoleColor.DarkGray; 
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

    string playerResult = player.PlayerUpdate(pressedKey, levelData);
    if (playerResult != "")
    {
        attackText = playerResult;
        attackTextColor = player.color;
    }
	
    turns++;

    foreach (LevelElement element in levelData.Elements)
    {
        if (element is Enemy)
        {
            if (((Enemy)element).WasInAFight) 
            { 
                continue; 
            }

            string enemyResult = ((Enemy)element).Update(levelData);
            if (enemyResult != "")
            {
                attackText = enemyResult;
                attackTextColor = element.color;
            }
        }
    }

    for (int i = levelData.Elements.Count -1 ; i >= 0 ; i--)
	{
		if (levelData.Elements[i] is Enemy && ((Enemy)levelData.Elements[i]).Health <= 0) 
		{
			levelData.Elements.RemoveAt(i);
		}
	}

    Console.SetCursorPosition(0, 1);
    Console.ForegroundColor = attackTextColor;
    Console.WriteLine(attackText.PadRight(200));
    Console.ResetColor();

    if (player.Health <= 0)
    {
        Console.SetCursorPosition(0, 3);
        Console.WriteLine("GAME OVER");
    }
}

