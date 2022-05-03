using UnityEngine;

public class Stage_3_2 : Stage
{
	protected override void WaveOne()
	{
		SimpleFormation(MardarianPrefabs[2], 1, 3, new Vector2(-1.5f, 3.5f), new Vector2(1, 20), 1, 1.5f, 0, 0, false);

		Vector2 lastPoint = new Vector2(-2.4f, -1.5f);
		Vector2[] tmpPath = (Vector2[])Paths[2].Clone();
		for (int i = 0; i < 14; ++i)
		{
			tmpPath[tmpPath.Length - 1] = new Vector2((lastPoint.x + 0.7f * (i % 4)), lastPoint.y + 0.7f * (i / 2));
			tmpPath[0].x -= 0.8f;
			InstShip(MardarianPrefabs[0], tmpPath);
		}
	}

	protected override void WaveTwo()
	{
		for (int i = 0; i < 5; ++i)
		{
			float patrolX = 1.3f + i % 2;
			Vector2 startPoint = new Vector2(-4, i);
			Vector2[] patrolPath = { new Vector2(-patrolX, i), new Vector2(patrolX, i) };
			InstShip(PiratePrefabs[3], startPoint, patrolPath, false, false);
		}
		SimpleFormation(PiratePrefabs[5], 2, 1, new Vector2(-2.1f, -0.5f), new Vector2(-6, 0), 4.5f, 0, 0, 0);
	}

	protected override void WaveThree()
	{
		SimpleFormation(CyberPrefabs[2], 3, 1, new Vector2(-1.8f, 1), new Vector2(-6, 3), 1.5f, 0);
		SimpleFormation(CyberPrefabs[0], 8, 3, new Vector2(-0.6f, 0), new Vector2(0, 7), 0.6f, 0.6f, 0, 0, false);
	}

	protected override void WaveFour()
	{
		CirclePatrol(SupremePrefabs[0], new Vector2(-4, -4), 10, 1, new Vector2(-1.5f, 0), -0.74f, mirror: true);
		InstShip(SupremePrefabs[5], new Vector2(-1.5f, 0), new Vector2(-3, -1.5f), true);
		CirclePatrol(SupremePrefabs[0], new Vector2(-3, 0), 10, 1, new Vector2(1.5f, 3), -0.74f, mirror: true);
		InstShip(SupremePrefabs[5], new Vector2(1.5f, 3), new Vector2(3, 5.5f), true);
	}

	protected override void WaveFive()
	{
		SimpleFormation(CyberPrefabs[4], 2, 1, new Vector2(-1.9f, 2.5f), new Vector2(0, 3), 1.6f, 0, 0, 0);
		SimpleFormation(CyberPrefabs[3], 1, 1, new Vector2(-1.8f, 1.2f), new Vector2(-4, 0), 0, 0);
	}

	protected override void WaveSix()
	{
		InstShip(SupremePrefabs[3], new Vector2(0, 3.7f), new Vector2(0, 10));
		InstShip(SupremePrefabs[1], new Vector2(-2, 3), new Vector2(-5, 6), true);
		SimpleFormation(SupremePrefabs[2], 3, 3, new Vector2(-1.96f, 0), new Vector2(-4, 1), 0.8f, 0.8f);
	}

	protected override void WaveSeven()
	{
		InstShip(MardarianPrefabs[4], new Vector2(0, 3f), new Vector2(0, 14));
		SimpleFormation(MardarianPrefabs[2], 2, 1, new Vector2(-1.5f, -0.5f), new Vector2(0, 10), 1.5f, 1.4f, 0, 0);
	}
}
