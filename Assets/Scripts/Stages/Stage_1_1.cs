using UnityEngine;

public class Stage_1_1 : Stage
{
	protected override void WaveOne()
	{
		Vector2 lastPoint = new Vector2(-2.4f, -1);
		Vector2 [] tmpPath = (Vector2[])Paths[0].Clone();
		tmpPath[0].x -= 4;
		for (int i = 0; i < 16; ++i)
		{
			tmpPath[tmpPath.Length - 1] = new Vector2((lastPoint.x + 0.7f * (i % 4)), lastPoint.y + (i / 4));
			tmpPath[0].x -= 0.8f;
			InstShip(CyberPrefabs[1], tmpPath);
		}
	}

	protected override void WaveTwo()
	{
		Vector2 lastPoint = new Vector2(-2.4f, 0);
		Vector2 tmpLastPoint = Vector2.zero;
		Vector2 tmpStartPoint;
		Vector2 difference = new Vector2(5, -5);
		Enemy tmpPrefab;

		int numRow = 5;
		int numCol = 4;
		int left = 1;

		for(int i = 0; i < numRow; ++i)
		{
			for(int j = 0; j < numCol; ++j)
			{
				if ((i == (numRow - 1)) && ((j % (numCol - 1) == 0)))
					tmpPrefab = PiratePrefabs[4];
				else
					tmpPrefab = PiratePrefabs[1];
				if (left > 0)
					tmpLastPoint = new Vector2(lastPoint.x + j * 0.6f, lastPoint.y + i * 0.6f);
				else
					tmpLastPoint = new Vector2(lastPoint.x - j * 0.6f, lastPoint.y + i * 0.6f);
				tmpStartPoint = tmpLastPoint - new Vector2(difference.x - i * left, difference.y);
				InstShip(tmpPrefab, tmpLastPoint, tmpStartPoint);
			}
			if ((i == (numRow - 1)) && (left > 0))
			{
				i = -1;
				left = -1;
				lastPoint.x *= -1;
				difference.x *= -1;
			}
		}
		GameObject.Find("RobotVoice").transform.GetChild(1).gameObject.SetActive(true);
	}

	protected override void WaveThree()
	{
		SimpleFormation(CyberPrefabs[1], 4, 7, new Vector2(-1.8f, 0), new Vector2(-5, 5), 0.6f, 0.6f, mirror: false);
		InstShip(CyberPrefabs[4], new Vector2(0, 4), new Vector2(0, 15));
	}

	protected override void WaveFour()
	{
		SimpleFormation(MardarianPrefabs[1], 5, 4, new Vector2(-2.31f, 0.5f), new Vector2(-2, 6), 1f, 0.66f);
	}

	protected override void WaveFive()
	{
		Vector2 lastPoint = new Vector2(-2.5f, 0.5f);
		Vector2 tmpLastPoint = Vector2.zero;
		Vector2 tmpStartPoint;
		Vector2 difference = new Vector2(-5, -5);

		int numRow = 6;
		int numCol = 9;

		for (int i = 0; i < numRow; ++i)
		{
			for (int j = 0; j < numCol; ++j)
			{
				if ((i % 2) == (j % 2))
					continue;
				tmpLastPoint = new Vector2(lastPoint.x + j * 0.6f, lastPoint.y + i * 0.6f);
				tmpStartPoint = tmpLastPoint - new Vector2(difference.x - i, difference.y);
				InstShip(SupremePrefabs[0], tmpLastPoint, tmpStartPoint);
			}
		}
	}

	protected override void WaveSix()
	{
		SimpleFormation(PiratePrefabs[0], 3, 3, new Vector2(-2.3f, 1), new Vector2(3, 6), 0.7f, 0.8f, 0);
		InstShip(MardarianPrefabs[5], new Vector2(-1.5f, 4f), new Vector2(-3f, 15));
		InstShip(MardarianPrefabs[5], new Vector2(1.5f, 4f), new Vector2(3f, 15));
	}

	protected override void WaveSeven()
	{
		Vector2 lastPoint = new Vector2(-2.47f, 0.5f);
		Vector2 tmpLastPoint = Vector2.zero;
		Vector2 tmpStartPoint;
		Vector2 difference = new Vector2(-5, -5);
		Enemy tmpPrefab;

		int numRow = 5;
		int numCol = 7;

		for (int i = 0; i < numRow; ++i)
		{
			for (int j = 0; j < numCol; ++j)
			{
				if ((i % 2) == (j % 2))
					tmpPrefab = CyberPrefabs[0];
				else
					tmpPrefab = CyberPrefabs[1];
				tmpLastPoint = new Vector2(lastPoint.x + j * 0.8f, lastPoint.y + i * 0.9f);
				tmpStartPoint = tmpLastPoint - new Vector2(difference.x - i, difference.y);
				InstShip(tmpPrefab, tmpLastPoint, tmpStartPoint);
			}
		}
	}
}