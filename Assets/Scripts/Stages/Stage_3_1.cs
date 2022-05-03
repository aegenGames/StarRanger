using UnityEngine;

public class Stage_3_1 : Stage
{
	protected override void WaveOne()
	{
		InstShip(SupremePrefabs[4], new Vector2(0, 2f), new Vector2(0, 10));
		CirclePatrol(SupremePrefabs[0], new Vector2(3.5f, -3), 12, 1.5f, new Vector2(0, 2f), 0.8f, mirror: false);
		CirclePatrol(SupremePrefabs[0], new Vector2(3.5f, 3), 18, 2.25f, new Vector2(0, 2f), 0.8f, false, mirror: false);
	}

	protected override void WaveTwo()
	{
		SimpleFormation(CyberPrefabs[0], 3, 3, new Vector2(-2f, 0), new Vector2(-4, 2), 1, 0.8f);
		InstShip(CyberPrefabs[3], new Vector2(0, 3.5f), new Vector2(0, 10));
	}

	protected override void WaveThree()
	{
		SimpleFormation(PiratePrefabs[2], 3, 3, new Vector2(-0.8f, 0), new Vector2(0, 6), 0.8f, 0.8f, 0, 0, false);
		InstShip(PiratePrefabs[6], new Vector2(-1.9f, 1), new Vector2(-8, 2), true);
		InstShip(PiratePrefabs[6], new Vector2(-1.4f, 2.5f), new Vector2(-7.5f, 3), true);
		InstShip(PiratePrefabs[5], new Vector2(0, 3.5f), new Vector2(0, 9.5f));
	}

	protected override void WaveFour()
	{
		SimpleFormation(MardarianPrefabs[0], 4, 3, new Vector2(-1.8f, -0.8f), new Vector2(9, 3), 0.8f, 0.6f);
		InstShip(MardarianPrefabs[4], new Vector2(0, 2.8f), new Vector2(0, 12));
	}

	protected override void WaveFive()
	{
		InstShip(CyberPrefabs[3], new Vector2(0, 3.8f), new Vector2(0, 16));

		Vector2 lastPoint = new Vector2(-2.4f, -0.5f);
		Vector2[] tmpPath = (Vector2[])Paths[2].Clone();
		for (int i = 0; i < 15; ++i)
		{
			tmpPath[tmpPath.Length - 1] = new Vector2((lastPoint.x + 0.7f * (i % 4)), lastPoint.y + 0.8f * (i / 3));
			tmpPath[0].x -= 0.8f;
			InstShip(CyberPrefabs[0], tmpPath);
		}
	}

	protected override void WaveSix()
	{
		SimpleFormation(SupremePrefabs[2], 3, 4, new Vector2(-2.33f, 0), new Vector2(-6, 2), 0.8f, 0.68f);
		InstShip(SupremePrefabs[3], new Vector2(0, 3.5f), new Vector2(0, 10));
	}

	protected override void WaveSeven()
	{
		SimpleFormation(MardarianPrefabs[1], 3, 3, new Vector2(-0.6f, 0), new Vector2(0, 10), 0.8f, 0.6f, 0, 0, false);
		InstShip(MardarianPrefabs[5], new Vector2(-1.7f, 1.8f), new Vector2(-6, 3), true);
		InstShip(MardarianPrefabs[5], new Vector2(-1.1f, 3.1f), new Vector2(-5.4f, 4.3f), true);
	}
}
