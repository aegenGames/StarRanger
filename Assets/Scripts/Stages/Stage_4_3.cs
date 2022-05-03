using UnityEngine;

public class Stage_4_3 : Stage_4_1
{
	protected override void WaveOne()
	{
		base.WaveOne();
	}

	protected override void WaveTwo()
	{
		base.WaveTwo();
	}

	protected override void WaveThree()
	{
		InstShip(SupremePrefabs[3], new Vector2(0, 3.8f), new Vector2(0, 10.3f));
		SimpleFormation(SupremePrefabs[2], 3, 4, new Vector2(-2.4f, -0.8f), new Vector2(-4, 1), 0.8f, 0.7f);
		InstShip(SupremePrefabs[1], new Vector2(0, 2), new Vector2(0, 8f));
		InstShip(SupremePrefabs[1], new Vector2(-1.3f, 2.5f), new Vector2(1.5f, 8f), true);
		InstShip(SupremePrefabs[1], new Vector2(-1.8f, 3.7f), new Vector2(1.5f, 8f), true);
	}

	protected override void WaveFour()
	{
		InstShip(MardarianPrefabs[4], new Vector2(0, 3), new Vector2(0, 10));
		SimpleFormation(MardarianPrefabs[2], 2, 1, new Vector2(-2, -0.5f), new Vector2(-5, 1), 1.5f, 1.39f, 0, 0);
	}

	protected override void WaveFive()
	{
		base.WaveFive();
	}

	protected override void WaveSix()
	{
		base.WaveSix();
	}

	protected override void WaveSeven()
	{
		InstShip(SupremePrefabs[3], new Vector2(0, 3.5f), new Vector2(0, 10));
		InstShip(SupremePrefabs[3], new Vector2(-1.5f, 2.5f), new Vector2(0, 9), true);
	}
}
