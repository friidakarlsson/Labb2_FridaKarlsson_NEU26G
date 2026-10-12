
using Labb2_FridaKarlsson_NEU26G;
using System.Xml.Linq;

LevelData levelData = new LevelData();

levelData.Load("Level1.txt");

Player player = new Player(levelData.PlayerStartX, levelData.PlayerStartY);
levelData.PlayerCurrentPosition = player;

while (true)
{


		ConsoleKeyInfo pressedKey = Console.ReadKey(true);
		int playerNextMoveX = player.xPosition;
		int playerNextMoveY = player.yPosition;

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

    Console.Clear();
    Console.CursorVisible = false;

    foreach (LevelElement element in levelData.Elements)
    {
		double distanceToSurroundingElements = Math.Sqrt(Math.Pow(player.xPosition - element.xPosition, 2)+ Math.Pow(player.yPosition - element.yPosition, 2));
        if (distanceToSurroundingElements <= 5 || element.DiscoveredWall)
		{
			element.Draw();
			if (element is Wall) { element.DiscoveredWall = true; }
		}
    }

	foreach (LevelElement element in levelData.Elements)
	{
		if(element is Enemy)
		{
			((Enemy)element).WasInAFight = false;
		}
	}

    player.Draw();

    if (player.Health <=0)
	{
        Console.WriteLine("GAME OVER");
		break;
	}
}

