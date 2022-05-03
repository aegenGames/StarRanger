using UnityEngine;

public class HunterEnemy : EnemyMinions
{
	private bool isHunting = false;
	private GameObject target;

	protected override void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		Move();
	}

	protected override void Move()
	{
		if (isHunting)
		{
			StepMove(target.transform.position);
		}
		else
		{
			this.transform.position += this.transform.up * this.speed * Time.deltaTime;
		}
	}

	private void switchMove()
	{
		isHunting = true;
	}

	public void callSwitch(float delay)
	{
		Invoke("switchMove", delay);
	}
}
