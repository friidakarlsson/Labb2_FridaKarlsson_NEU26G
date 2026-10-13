
using Labb2_FridaKarlsson_NEU26G;


Console.WriteLine("Write player name: ");
string? playerName = Console.ReadLine();

playerName = string.IsNullOrWhiteSpace(playerName) ? "Player" : playerName;
int turns = 0;

LevelData levelData = new LevelData();

levelData.Load("Level1.txt");
Console.Clear();

Player player = new Player(levelData.PlayerStartX, levelData.PlayerStartY);
levelData.PlayerCurrentPosition = player;
player.Name = playerName;

while (true)
{
	Console.Clear();
    Console.CursorVisible = false;
    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"Name: {player.Name}\t-\tHP: {player.Health.ToString().PadRight(3)}/100\t-\tTurn:{turns.ToString().PadRight(4)}");

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
	int playerNextMoveX = player.xPosition;
	int playerNextMoveY = player.yPosition;
		
	turns++;

	switch(pressedKey.Key)
	{
		case ConsoleKey.RightArrow:
		case ConsoleKey.D:
			 playerNextMoveX++; break; 
		case ConsoleKey.LeftArrow:
		case ConsoleKey.A:
			 playerNextMoveX--; break; 
		case ConsoleKey.DownArrow:
		case ConsoleKey.S:
			 playerNextMoveY ++; break; 
		case ConsoleKey.UpArrow:
		case ConsoleKey.W:
			 playerNextMoveY --; break; 
		default:  break;
	}

	if (player.MakeAMove(playerNextMoveX, playerNextMoveY, levelData))
	{
        player.xPosition = playerNextMoveX;
        player.yPosition = playerNextMoveY;

		levelData.PlayerCurrentPosition = player;
    }
	else
	{
		foreach (LevelElement element in levelData.Elements)
		{
			if (element is Enemy && playerNextMoveX == element.xPosition && playerNextMoveY == element.yPosition)
			{
				player.Attack((Enemy)element);
				((Enemy)element).WasInAFight = true;

			}
		}
	}

	foreach (LevelElement element in levelData.Elements)
	{
		if (element is Enemy)
		{
			if (((Enemy)element).WasInAFight) { continue; }
			((Enemy)element).Update(levelData);
		}
	}

	for (int i = levelData.Elements.Count -1 ; i >= 0 ; i--)
	{
		if (levelData.Elements[i] is Enemy && ((Enemy)levelData.Elements[i]).Health <= 0) 
		{
			levelData.Elements.RemoveAt(i);
		}
	}



    if (player.Health <=0)
	{
        Console.WriteLine("GAME OVER");
		break;
	}
}

