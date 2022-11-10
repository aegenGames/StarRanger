using UnityEngine;
using System.Collections;

public class HunterEnemy : EnemyMinions
{
	private bool isHunting = false;
	private GameObject target;

    protected override void DefaultSetup()
	{
		target = GameObject.FindGameObjectWithTag("Player");
		base.DefaultSetup();
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

	public IEnumerator CallSwitch(float delay)
	{
		yield return new WaitForSeconds(delay);
		isHunting = true;
	}
}
