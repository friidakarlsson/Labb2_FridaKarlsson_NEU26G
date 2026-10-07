
using Labb2_FridaKarlsson_NEU26G;

LevelData levelData = new LevelData();

levelData.Load("Level1.txt");

Player player = new Player(levelData.PlayerStartX, levelData.PlayerStartY);
levelData.PlayerCurrentPosition = player;

while (true)
{
    Console.Clear();
    Console.CursorVisible = false;

    foreach (LevelElement element in levelData.Elements)
	{
		element.Draw();
	}
		player.Draw();

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

	foreach (LevelElement element in levelData.Elements)
	{
		if (element is Enemy)
		{
			((Enemy)element).Update(levelData);
		}
	}
}