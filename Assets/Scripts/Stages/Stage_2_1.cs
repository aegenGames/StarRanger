using UnityEngine;

public class Stage_2_1 : Stage
{
	protected override void WaveOne()
	{
		SimpleFormation(PiratePrefabs[2], 4, 4, new Vector2(-2.5f, 0), new Vector2(7, 4), 0.8f, 0.7f, 2, 1.5f);
		InstShip(PiratePrefabs[6], new Vector2(0, 3.5f), new Vector2(0, 20));
	}

	protected override void WaveTwo()
	{
		Vector2 lastPoint = new Vector2(-2.4f, 0);
		Vector2[] tmpPath = (Vector2[])Paths[2].Clone();
		for (int i = 0; i < 20; ++i)
		{
			tmpPath[tmpPath.Length - 1] = new Vector2((lastPoint.x + 0.7f * (i % 4)), lastPoint.y + 0.8f * (i / 4));
			tmpPath[0].x -= 0.8f;
			InstShip(CyberPrefabs[0], tmpPath);
		}
	}

	protected override void WaveThree()
	{
		InstShip(MardarianPrefabs[3], new Vector2(-1.9f, 2), new Vector2(-7, 2), true);
		InstShip(MardarianPrefabs[3], new Vector2(-0.8f, 2.5f), new Vector2(-6, 2.5f), true);
		InstShip(MardarianPrefabs[2], new Vector2(0, 3.5f), new Vector2(0, 11f));
	}

	protected override void WaveFour()
	{
		SimpleFormation(CyberPrefabs[0], 4, 4, new Vector2(-2.2f, 0), new Vector2(-10, -3), 0.6f, 0.6f, 2);
		InstShip(CyberPrefabs[2], new Vector2(0, 4), new Vector2(0, 16));
	}

	protected override void WaveFive()
	{
		Vector2 lastPoint = new Vector2(-2.4f, 0);
		Vector2[] tmpPath = (Vector2[])Paths[3].Clone();
		for (int i = 0; i < 48; ++i)
		{
			tmpPath[tmpPath.Length - 1] = new Vector2((lastPoint.x + 0.7f * (i % 8)), lastPoint.y + 0.8f * (i / 8));
			tmpPath[0].x -= 0.7f;
			InstShip(SupremePrefabs[0], tmpPath, false);
		}
	}

	protected override void WaveSix()
	{
		SimpleFormation(PiratePrefabs[1], 5, 4, new Vector2(-2.5f, 0), new Vector2(7, 3), 0.7f, 0.7f, 2);
		SimpleFormation(PiratePrefabs[4], 1, 5, new Vector2(-2, 3.5f), new Vector2(0, 10), 0, 1, mirror:false);
	}

	protected override void WaveSeven()
	{
		SimpleFormation(MardarianPrefabs[0], 4, 4, new Vector2(-2.45f, 0), new Vector2(-4, 4), 1, 0.7f, 1.5f, 2);
	}
}
