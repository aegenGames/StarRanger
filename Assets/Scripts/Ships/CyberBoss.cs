using UnityEngine;

public class CyberBoss : EnemyBoss
{
	private bool isPatrolling = false;
	private int curPatrolIndex = 0;
	private Vector3[] patrolPoints;

	protected override void Start()
	{
		base.Start();
		
		float posY = 3.7f;
		float posX = 1.6f;
		stopPoint = new Vector2(0, posY);
		patrolPoints = new Vector3[2];
		patrolPoints[0] = new Vector2(-posX, posY);
		patrolPoints[1] = new Vector2(posX, posY);
	}

	void Update()
	{
		if (isPatrolling)
			MovePatrol();
		else
			Move();
	}

	protected override void Move()
	{
		base.Move();
		if (!isMoved)
			speed = 0.5f;
	}

	private void MovePatrol()
	{
		this.transform.position += (patrolPoints[curPatrolIndex] - this.transform.position).normalized * this.speed * Time.deltaTime;
		if (Vector3.Distance(patrolPoints[curPatrolIndex], this.transform.position) < Mathf.Pow(10, -2))
			curPatrolIndex = 1 - curPatrolIndex;
	}

	protected override void StartWeaponOne()
	{
		StartWeapon("WeaponOne");
		Invoke("StopWeaponOne", 15);
	}

	protected void StopWeaponOne()
	{
		StopWeapon("WeaponOne");
		Invoke("StartWeaponTwo", 3);
	}

	protected void StartWeaponTwo()
	{
		StartWeapon("WeaponTwo");
		Invoke("StopWeaponTwo", 15);
	}

	protected void StopWeaponTwo()
	{
		StopWeapon("WeaponTwo");
		Invoke("StartWeaponThree", 4);
	}

	protected void StartWeaponThree()
	{
		this.transform.Find("WeaponThree").gameObject.SetActive(true);
		Invoke("StopWeaponThree", 12.5f);
		isPatrolling = true;
	}

	protected void StopWeaponThree()
	{
		this.transform.Find("WeaponThree").gameObject.SetActive(false);
		Invoke("StartWeaponOne", 2);
		isPatrolling = false;
	}
}
