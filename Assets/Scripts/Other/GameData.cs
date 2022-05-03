public static class GameData
{
	// Game options
	public static int lvlOne = 1;
	public static int lvlTwo = 0;
	public static int lvlThree = 0;
	public static int lvlFour = 0;

	public static int dmgOne = 50;
	public static int dmgTwo = 100;
	public static int dmgThree = 0;
	public static int dmgFour = 0;

	public static int credits = 0;

	public static void ResetGame()
	{
		lvlOne = 1;
		lvlTwo = 0;
		lvlThree = 0;
		lvlFour = 0;

		dmgOne = 50;
		dmgTwo = 100;
		dmgThree = 0;
		dmgFour = 0;

		credits = 0;
	}
}
