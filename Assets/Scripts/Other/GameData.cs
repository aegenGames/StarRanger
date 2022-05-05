public static class GameData
{
	// Game options
	public static int lvlOne;
	public static int lvlTwo;
	public static int lvlThree;
	public static int lvlFour;

	public static int dmgOne;
	public static int dmgTwo;
	public static int dmgThree;
	public static int dmgFour;

	public static int credits;

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
