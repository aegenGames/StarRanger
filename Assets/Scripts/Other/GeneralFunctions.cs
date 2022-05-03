using UnityEngine;

public static class GeneralFunctions
{
	public static float heightControllerSquare;

	public static float AngleRotateToPoint(Vector3 posObject, Vector3 posTarget)
	{
		Vector2 direction = posTarget - posObject;
		float angle = -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
		return angle;
	}

	public static GameObject targetSearch(string targetTag, Vector3 position)
	{
		GameObject target = null;
		GameObject [] enemys = GameObject.FindGameObjectsWithTag(targetTag);
		Vector2 seekerPos = position;
		float minDist = 0;
		float curDist;

		if (enemys.Length > 0)
		{
			minDist = Vector2.Distance(enemys[0].transform.position, seekerPos);
			target = enemys[0];
		}

		foreach (GameObject e in enemys)
		{
			curDist = Vector2.Distance(e.transform.position, seekerPos);
			if (curDist < minDist)
			{
				minDist = curDist;
				target = e;
			}
		}
		return target;
	}

	public static void GetBoard(float heightObject, float widthObject, ref float xMin, ref float xMax, ref float yMin, ref float yMax)
	{
		Camera gameCamera = Camera.main;
		xMin = gameCamera.ViewportToWorldPoint(new Vector2(0, 0)).x + widthObject;
		xMax = gameCamera.ViewportToWorldPoint(new Vector2(1, 0)).x - widthObject;
		yMin = gameCamera.ViewportToWorldPoint(new Vector2(0, 0)).y + heightObject + heightControllerSquare;
		yMax = gameCamera.ViewportToWorldPoint(new Vector2(0, 1)).y - heightObject;
	}
}
