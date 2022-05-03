using UnityEngine;

public class Stage_4_1 : Stage
{
	protected override void WaveOne()
	{
		CirclePatrol(SupremePrefabs[0], new Vector2(-5, -1), 18, 2, new Vector2(-0.5f, 2), -0.8f, mirror: true);
		InstShip(SupremePrefabs[3], new Vector2(0, 2.1f), new Vector2(0, 10));
	}

	protected override void WaveTwo()
	{
		InstShip(MardarianPrefabs[4], new Vector2(0, 3), new Vector2(0, 10));
		InstShip(MardarianPrefabs[4], new Vector2(-2, 2), new Vector2(-2, 9), true);
	}

	protected override void WaveThree()
	{
		SimpleFormation(CyberPrefabs[2], 1, 3, new Vector2(-2f, 4.5f), new Vector2(-2, 20), 1, 2f, 0, 0, false);
		SimpleFormation(CyberPrefabs[4], 1, 3, new Vector2(-2f, 2.5f), new Vector2(-2, 18), 1, 2f, 0, 0, false);

		Vector2 lastPoint = new Vector2(-2.55f, 0);
		Vector2[] tmpPath = (Vector2[])Paths[1].Clone();
		for (int i = 0; i < 12; ++i)
		{
			tmpPath[tmpPath.Length - 1] = new Vector2((lastPoint.x + 0.7f * (i % 4)), lastPoint.y + 0.7f * (i / 4));
			tmpPath[0].x -= 0.8f;
			InstShip(CyberPrefabs[0], tmpPath);
		}
	}

	protected override void WaveFour()
	{
		Vector2 startPoint = Paths[2][0];
		for(int i = 0; i < 16; ++i)
		{
			startPoint.x -= 0.6f;
			InstShip(PiratePrefabs[0], startPoint, Paths[2], true, true);
		}
		InstShip(PiratePrefabs[6], new Vector2(-2, 0), new Vector2(-5, 2), true);
		InstShip(PiratePrefabs[6], new Vector2(-1.5f, 1.3f), new Vector2(-4.5f, 3.3f), true);
		SimpleFormation(PiratePrefabs[5], 1, 2, new Vector2(-2, 4), new Vector2(-2, 8), 0, 1.35f, 0, 0);
	}

	protected override void WaveFive()
	{
		InstShip(MardarianPrefabs[4], new Vector2(0, 3), new Vector2(0, 10.5f));
		SimpleFormation(MardarianPrefabs[3], 3, 1, new Vector2(-2f, 0.5f), new Vector2(-5, 2), 1.5f, 0);
		SimpleFormation(MardarianPrefabs[2], 2, 1, new Vector2(0, -0.5f), new Vector2(0, 7.5f), 1.5f, 0, 0, 0, false);
	}

	protected override void WaveSix()
	{
		InstShip(SupremePrefabs[4], new Vector2(-1.3f, 3.5f), new Vector2(0, 10), true);
		SimpleFormation(SupremePrefabs[1], 2, 1, new Vector2(-2f, 0.5f), new Vector2(-5, 2), 1.5f, 0);
		CirclePatrol(SupremePrefabs[0], new Vector2(-4, -2), 16, 1.5f, new Vector2(0, 1.1f), -0.6f);
		CirclePatrol(SupremePrefabs[0], new Vector2(4, 2), 11, 1f, new Vector2(0, 1.1f), 0.6f, false);
		CirclePatrol(SupremePrefabs[0], new Vector2(4, -2), 6, 0.5f, new Vector2(0, 1.1f), 0.6f);
	}

	protected override void WaveSeven()
	{
		InstShip(CyberPrefabs[3], new Vector2(-2.1f, 3.5f), new Vector2(0, 14), true);
		SimpleFormation(CyberPrefabs[4], 2, 1, new Vector2(-2, 0.5f), new Vector2(0, 8), 1.5f, 2, 0, 0);
	}
}
