using UnityEngine;

public class Stage_1_2 : Stage
{
	protected override void WaveOne()
	{
		Vector2 lastPoint = new Vector2(-2.4f, 0);
		Vector2[] tmpPath = (Vector2[])Paths[1].Clone();
		for (int i = 0; i < 18; ++i)
		{
			tmpPath[tmpPath.Length - 1] = new Vector2((lastPoint.x + 0.9f * (i % 3)), lastPoint.y + 0.8f * (i / 3));
			tmpPath[0].x -= 0.8f;
			InstShip(PiratePrefabs[0], tmpPath);
		}
	}

	protected override void WaveTwo()
	{
		InstShip(MardarianPrefabs[3], new Vector2(-2.1f, 2), new Vector2(-6, 4), true);
		InstShip(MardarianPrefabs[3], new Vector2(-1.3f, 3), new Vector2(-2, 8), true);
	}

	protected override void WaveThree()
	{
		SimpleFormation(CyberPrefabs[1], 5, 5, new Vector2(-2.1f, 0), new Vector2(14, 7), 1, 1, 2, 1.5f, false);
	}

	protected override void WaveFour()
	{
		SimpleFormation(PiratePrefabs[1], 3, 3, new Vector2(-2.1f, 0), new Vector2(-2, 6), 1f, 0.7f);
		SimpleFormation(PiratePrefabs[2], 1, 2, new Vector2(-2.1f, 3), new Vector2(1.8f, 6), 1f, 1.4f);
	}

	protected override void WaveFive()
	{
		SimpleFormation(CyberPrefabs[0], 5, 3, new Vector2(-2.3f, 0), new Vector2(3, 7), 0.8f, 0.9f);
	}

	protected override void WaveSix()
	{
		SimpleFormation(MardarianPrefabs[1], 5, 3, new Vector2(-2.3f, 0), new Vector2(3, 6), 0.7f, 0.8f, 0);
		SimpleFormation(MardarianPrefabs[0], 1, 2, new Vector2(-2.1f, 4), new Vector2(-10, 5), 0, 1.4f);
	}

	protected override void WaveSeven()
	{
		SimpleFormation(PiratePrefabs[1], 3, 5, new Vector2(-1.2f, 0), new Vector2(0, 6), 0.6f, 0.6f, 0, 0, false);
		InstShip(PiratePrefabs[6], new Vector2(0, 3), new Vector2(0, 11));
	}
}