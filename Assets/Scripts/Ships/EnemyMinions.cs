using UnityEngine;
using System.Collections;

public class EnemyMinions : Enemy
{
	private Vector2 [] pathMove = null;
	private Vector2 [] patrolPath = null;
	private int curIndexMovePoint = 0;
	private int curIndexPatrolPoint = 0;
	private bool moveForward = true;

	public Vector2 [] PathMove
	{
		get => pathMove;
		set
		{
			if (value != null) {
				pathMove = value;
				float angle = GeneralFunctions.AngleRotateToPoint(this.transform.position, pathMove[0]);
				transform.rotation = Quaternion.Euler(0, 0, angle);
				this.gameObject.transform.position = pathMove[0];
			}
		}
	}

	public bool MoveForward
	{
		get => moveForward;
		set
		{
			moveForward = value;
			if (moveForward == false)
			{
				float angle = GeneralFunctions.AngleRotateToPoint(this.transform.up, new Vector2(0, -1));
				transform.rotation = Quaternion.Euler(0, 0, angle);
			}
		}
	}

	public Vector2[] PatrolPath
	{
		get => patrolPath;
		set
		{
			patrolPath = value;
			if(patrolPath != null)
				Invoke("LaunchWeapons", 6f);
		}
	}

	protected override void Move()
	{
		if (pathMove == null)
		{
			return;
		}
		if (curIndexMovePoint < pathMove.Length)
		{
			StepMove(pathMove[curIndexMovePoint]);
			if (Vector2.Distance(pathMove[curIndexMovePoint], this.transform.position) < 0.1)
				++curIndexMovePoint;
		}
		else if((curIndexMovePoint == pathMove.Length) && (patrolPath == null))
		{
			float angle = GeneralFunctions.AngleRotateToPoint(this.transform.up, -Vector2.up);
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime);
			if (Mathf.Abs(Mathf.Abs(angle) - 90) < 1)
			{
				++curIndexMovePoint;
				speed = 1;
				Invoke("LaunchWeapons", 1f);

				Animation animation = this.GetComponent<Animation>();
				if (animation != null)
					animation.enabled = true;
			}
		}
		else if(patrolPath != null)
		{
			MovePatrol();
		}
	}

	protected void LaunchWeapons()
	{
		for(int i = 0; i < this.gameObject.transform.childCount; ++i)
		{
			IWeapon wp = this.gameObject.transform.GetChild(i).GetComponent<IWeapon>();
			if(wp != null)
				wp.StartWeapon();
		}
	}

	protected void MovePatrol()
	{
		if (Vector2.Distance(PatrolPath[curIndexPatrolPoint], this.transform.position) < 0.1)
		{
			if (++curIndexPatrolPoint >= patrolPath.Length)
				curIndexPatrolPoint = 0;
		}
		else
		{
			StepMove(PatrolPath[curIndexPatrolPoint]);
		}
	}

	protected void StepMove(Vector3 targetPoint)
	{
		if (moveForward)
		{
			float angle = GeneralFunctions.AngleRotateToPoint(this.transform.position, targetPoint);
			transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 0, angle), speed * 5 * Time.deltaTime);
			this.transform.position += this.transform.up * this.speed * Time.deltaTime;
		}
		else
		{
			this.transform.position += (targetPoint - this.transform.position).normalized * this.speed * Time.deltaTime;
		}
	}
}
