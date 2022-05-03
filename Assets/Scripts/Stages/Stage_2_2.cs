using UnityEngine;

public class Stage_2_2 : Stage
{
	protected override void WaveOne()
	{
		SimpleFormation(SupremePrefabs[2], 4, 3, new Vector2(-2.25f, 1.4f), new Vector2(-3, 4), 1, 0.9f);
	}

	protected override void WaveTwo()
	{
		SimpleFormation(MardarianPrefabs[1], 3, 3, new Vector2(-1, 0), new Vector2(0, 7), 1, 1, 0, 0, false);
		InstShip(MardarianPrefabs[5], new Vector2(-1.8f, 2.5f), new Vector2(-5, 4.5f), true);
		InstShip(MardarianPrefabs[2], new Vector2(-1.8f, 3.5f), new Vector2(-6, 3.5f), true);
	}

	protected override void WaveThree()
	{
		Vector2 lastPoint = new Vector2(-2.4f, -0.5f);
		Vector2[] tmpPath = (Vector2[])Paths[0].Clone();
		Vector2[] tmpPath2 = (Vector2[])Paths[3].Clone();
		for (int i = 0; i < 12; ++i)
		{
			tmpPath[tmpPath.Length - 1] = new Vector2((lastPoint.x + 0.7f * (i % 4)), lastPoint.y + 0.8f * (i / 4));
			tmpPath[0].x -= 0.8f;
			InstShip(CyberPrefabs[1], tmpPath[tmpPath.Length - 1], tmpPath);

			tmpPath2[0].x -= 0.8f;
			tmpPath2[tmpPath2.Length - 1] = tmpPath[tmpPath.Length - 1];
			tmpPath2[tmpPath2.Length - 1].y += 2.5f;
			InstShip(CyberPrefabs[0], tmpPath2[tmpPath2.Length - 1], tmpPath2);
		}
	}

	protected override void WaveFour()
	{
		SimpleFormation(SupremePrefabs[0], 3, 4, new Vector2(-2.4f, 1), new Vector2(7, 2), 0.6f, 0.6f);
		InstShip(SupremePrefabs[5], new Vector2(-1.4f, 3), new Vector2(-5, 9), true);
	}

	protected override void WaveFive()
	{
		SimpleFormation(PiratePrefabs[0], 3, 7, new Vector2(-2.5f, 0.5f), new Vector2(7, 2), 0.8f, 0.8f, mirror: false);

		Vector2 startPoint = new Vector2(6, 6);
		Vector2[] patrolPath = { new Vector2(1.5f, 4), new Vector2(-1.5f, 4) };
		InstShip(PiratePrefabs[3], startPoint, patrolPath, false, false);

		startPoint = new Vector2(-6, 5);
		Vector2[] patrolPath2 = { new Vector2(-1.5f, 3), new Vector2(1.5f, 3) };
		InstShip(PiratePrefabs[3], startPoint, patrolPath2, false, false);
	}

	protected override void WaveSix()
	{
		Vector2 lastPoint = new Vector2(-2.4f, 1.2f);
		Vector2[] tmpPath = (Vector2[])Paths[1].Clone();
		for (int i = 0; i < 20; ++i)
		{
			tmpPath[tmpPath.Length - 1] = new Vector2((lastPoint.x + 0.6f * (i % 4)), lastPoint.y + 0.8f * (i / 4));
			tmpPath[0].y += 1;
			InstShip(MardarianPrefabs[0], tmpPath);
		}
	}

	protected override void WaveSeven()
	{
		SimpleFormation(PiratePrefabs[2], 3, 3, new Vector2(-1.9f, 0), new Vector2(-5, -2), 1, 0.8f);
		InstShip(PiratePrefabs[6], new Vector2(-1.5f, 3.5f), new Vector2(-1, 10), true);
	}
}
