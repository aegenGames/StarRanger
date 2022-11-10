using UnityEngine;
using System.Collections;

public class CyberBoss : EnemyBoss
{
	private bool isPatrolling = false;
	private int curPatrolIndex = 0;
	private Vector3[] patrolPoints;

    protected override void DefaultSetup()
    {
		float posY = 3.7f;
		float posX = 1.6f;
		stopPoint = new Vector2(0, posY);
		patrolPoints = new Vector3[2];
		patrolPoints[0] = new Vector2(-posX, posY);
		patrolPoints[1] = new Vector2(posX, posY);
		base.DefaultSetup();
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

	protected override IEnumerator StartWeaponOne()
	{
		StartWeapon("WeaponOne");
		yield return new WaitForSeconds(15);
		StopWeapon("WeaponOne");
		yield return new WaitForSeconds(3);
		StartCoroutine(StartWeaponTwo());
	}

	protected IEnumerator StartWeaponTwo()
	{
		StartWeapon("WeaponTwo");
		yield return new WaitForSeconds(15);
		StopWeapon("WeaponTwo");
		yield return new WaitForSeconds(4);
		StartCoroutine(StartWeaponThree());
	}

	protected IEnumerator StartWeaponThree()
	{
		this.transform.Find("WeaponThree").gameObject.SetActive(true);
		isPatrolling = true;
		yield return new WaitForSeconds(12.5f);
		this.transform.Find("WeaponThree").gameObject.SetActive(false);
		isPatrolling = false;
		yield return new WaitForSeconds(2);
		StartCoroutine(StartWeaponOne());
	}
}
