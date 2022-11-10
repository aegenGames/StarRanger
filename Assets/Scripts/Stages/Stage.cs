using System;
using UnityEngine;

public class Stage : MonoBehaviour
{
	System.Action endStage;

	private Enemy [] cyberPrefabs;
	private Enemy [] piratePrefabs;
	private Enemy [] mardarianPrefabs;
	private Enemy [] supremePrefabs;
	private Vector2 [][] paths;
	protected System.Action [] stages;

	protected int numCurWave = 0;

	/// <summary>
	/// Movement paths.
	/// </summary>
	public Vector2 [][] Paths { get => paths; set => paths = value; }
	public Enemy [] CyberPrefabs { get => cyberPrefabs; set => cyberPrefabs = value; }
	public Enemy [] PiratePrefabs { get => piratePrefabs; set => piratePrefabs = value; }
	public Enemy [] MardarianPrefabs { get => mardarianPrefabs; set => mardarianPrefabs = value; }
	public Enemy [] SupremePrefabs { get => supremePrefabs; set => supremePrefabs = value; }
	public Action EndStage { get => endStage; set => endStage = value; }

	/// <summary>
	/// Launch stage
	/// </summary>
	public virtual void Launch()
	{
		stages = new System.Action[8];
		stages[0] += WaveOne;
		stages[1] += WaveTwo;
		stages[2] += WaveThree;
		stages[3] += WaveFour;
		stages[4] += WaveFive;
		stages[5] += WaveSix;
		stages[6] += WaveSeven;
		stages[7] += EndStage;
	}

	protected virtual void WaveOne() {}
	protected virtual void WaveTwo() {}
	protected virtual void WaveThree() {}
	protected virtual void WaveFour() {}
	protected virtual void WaveFive() {}
	protected virtual void WaveSix() {}
	protected virtual void WaveSeven() {}

	void Start()
	{
		InvokeRepeating("CheckWave", 0, 4);
	}

	/// <summary>
	/// Instance of ship.
	/// </summary>
	/// <param name="prefab">
	/// Prefab of ship.
	/// </param>
	/// <param name="path">
	/// Path move.
	/// </param>
	/// <param name="mirror">
	/// true - create copy mirrored by X.
	/// </param>
	/// <param name="patrolPath">
	/// Patrol path.
	/// </param>
	/// <param name="isMovingForward">
	/// true - ship is moving forward.
	/// false - ship is moving along shot path.
	/// </param>
	protected void InstShip(Enemy prefab, Vector2[] path, bool mirror = true, Vector2[] patrolPath = null, bool isMovingForward = true)
	{
		Vector2[] tmpPath = (Vector2[])path.Clone();
		Vector2[] mirrorPatrol = null;

		EnemyMinions tmpEnemy = Instantiate(prefab, path[0], Quaternion.identity).GetComponent<EnemyMinions>();
		tmpEnemy.PathMove = tmpPath;
		if (patrolPath != null)
		{
			tmpEnemy.PatrolPath = patrolPath;
			tmpEnemy.MoveForward = isMovingForward;
		}

		if (mirror)
		{
			tmpPath = (Vector2[])path.Clone();
			for (int i = 0; i < tmpPath.Length; ++i)
				tmpPath[i].x *= -1;
			if(patrolPath != null)
			{
				mirrorPatrol = (Vector2[])patrolPath.Clone();
				for (int i = 0; i < mirrorPatrol.Length; ++i)
					mirrorPatrol[i].x *= -1;
			}
			InstShip(prefab, tmpPath, false, mirrorPatrol, isMovingForward);
		}
	}

	/// <summary>
	/// Instance of patrol ship.
	/// </summary>
	protected void InstShip(Enemy prefab, Vector2 startPoint, Vector2[] patrolPath, bool isMovingForward, bool mirror)
	{
		Vector2[] path = { startPoint };
		InstShip(prefab, path, mirror, patrolPath, isMovingForward);
	}

	/// <summary>
	/// Instance of ship moving along path with stoping in lastpoint
	/// </summary>
	protected void InstShip(Enemy prefab, Vector2 lastPoint, Vector2[] path, bool mirror = true)
	{
		Vector2[] tmpPath = (Vector2[])path.Clone();
		tmpPath[tmpPath.Length - 1] = lastPoint;
		InstShip(prefab, tmpPath, mirror);
	}

	// Instance of ship moving from startPoint to lastPoint
	protected void InstShip(Enemy prefab, Vector2 lastPoint, Vector2 startPoint, bool mirror = false)
	{
		Vector2[] tmpPath = { startPoint, lastPoint };
		InstShip(prefab, tmpPath, mirror);
	}

	/// <summary>
	/// Instance of ship in his start point and moving to patrol zone.
	/// After patrol in circle.
	/// </summary>
	/// <param name="prefab">
	/// Prefab of ship.
	/// </param>
	/// <param name="startPoint">
	/// Point of start moving.
	/// </param>
	/// <param name="numShips">
	/// Number of create ships.
	/// </param>
	/// <param name="radius">
	/// Radius of circle.
	/// </param>
	/// <param name="center">
	/// Center of circle.
	/// </param>
	/// <param name="stepTailX">
	/// Distance between ships.
	/// </param>
	/// <param name="clockwise">
	/// true - direction of rotait clocwise.
	/// false - counterclockwise.
	/// </param>
	/// <param name="step">
	/// step between divisions on circle.
	/// </param>
	/// <param name="mirror">
	/// true - create copy mirrored by X.
	/// </param>
	protected void CirclePatrol(Enemy prefab, Vector2 startPoint, int numShips, float radius,
								Vector2 center, float stepTailX, bool clockwise = true, int step = 20, bool mirror = false)
	{
		Vector2[] patrolPath = new Vector2[360/step];
		int k = 0;
		for (int i = 0; i < patrolPath.Length; ++i)
		{
			if (clockwise)
				k = i;
			else
				k = patrolPath.Length - 1 - i;
			patrolPath[i] = new Vector2(Mathf.Cos(k * step * Mathf.Deg2Rad), Mathf.Sin(k * step * Mathf.Deg2Rad));
			patrolPath[i] = patrolPath[i] * radius + center;
		}

		Vector2[] tmpPath = new Vector2[2];
		tmpPath[1] = startPoint;
		for (int i = 0; i < numShips; ++i)
		{
			startPoint.x += stepTailX;
			tmpPath[0] = startPoint;
			InstShip(prefab, tmpPath, mirror, patrolPath);
		}
	}

	/// <summary>
	/// Instance some ships wich create rectangle formation.
	/// —оздаЄт несколько экземпл€ров корабл€, которые образуют построение пр€моуголной формации
	/// </summary>
	/// <param name="prefab">
	/// Prefab of ship.
	/// </param>
	/// <param name="numRow">
	/// Number of rows.
	/// </param>
	/// <param name="numCol">
	/// Number of columns.
	/// </param>
	/// <param name="lastPoint">
	/// Based for last points.
	/// </param>
	/// <param name="diffBWLastStart">
	/// Distance between last and start points.
	/// </param>
	/// <param name="distanceBWRow">
	/// Distance bw rows.
	/// </param>
	/// <param name="distanceBWCol">
	/// Distance bw columns.
	/// </param>
	/// <param name="shiftStartX">
	/// Shift start poins along X.
	/// For more chaotic move.
	/// </param>
	/// <param name="shiftStartY">
	/// Shift start poins along Y.
	/// For more chaotic move.
	/// </param>
	/// <param name="mirror">
	/// true - create copy mirrored by X.
	/// </param>
	protected void SimpleFormation(Enemy prefab, int numRow, int numCol, Vector2 lastPoint, Vector2 diffBWLastStart,
									float distanceBWRow, float distanceBWCol, float shiftStartX = 1, float shiftStartY = 1, bool mirror = true)
	{
		Vector2 tmplastPoint = Vector2.zero;
		Vector2 tmpStartPoint = Vector2.zero;

		for (int i = 0; i < numRow; ++i)
		{
			for (int j = 0; j < numCol; ++j)
			{
				tmplastPoint = new Vector2(lastPoint.x + j * distanceBWCol, lastPoint.y + i * distanceBWRow);
				tmpStartPoint = tmplastPoint + new Vector2(diffBWLastStart.x + i * shiftStartX, diffBWLastStart.y + j * shiftStartY);
				InstShip(prefab, tmplastPoint, tmpStartPoint, mirror);
			}
		}
	}

	/// <summary>
	/// Check for enemies.
	/// If scene clear, start next wave.
	/// </summary>
	private void CheckWave()
	{
		if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
		{
			if ((numCurWave < stages.Length) && (GameObject.FindGameObjectsWithTag("EnemyWeapons").Length == 0))
				stages[numCurWave++]();
			if (numCurWave == stages.Length)
			{
				CancelInvoke("checkWave");
				GameObject.Find("RobotVoice").transform.GetChild(2).gameObject.SetActive(true);
			}
		}
	}
}
