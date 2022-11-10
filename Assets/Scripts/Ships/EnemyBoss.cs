using UnityEngine;
using System.Collections;

public class EnemyBoss : Enemy
{
	protected bool isMoved = true;
	protected Vector2 stopPoint;

    protected override void DefaultSetup()
    {
		this.transform.position = new Vector2(0, 8);
		base.DefaultSetup();
	}

    protected override void Move()
	{
		if (isMoved)
		{
			this.transform.position += this.transform.up * speed * Time.deltaTime;
			if ((this.transform.position.y - stopPoint.y) < Mathf.Pow(10, -3))
			{
				isMoved = false;
				StartCoroutine(StartWeaponOne());
			}
		}
	}

	protected virtual IEnumerator StartWeaponOne() { yield break; }

	protected void StartWeapon(string nameObject)
	{
		Transform weapons = this.transform.Find(nameObject);
		for (int i = 0; i < weapons.childCount; ++i)
		{
			weapons.GetChild(i).GetComponent<SimpleWeapons>().StartWeapon();
		}
	}

	protected void StopWeapon(string nameObject)
	{
		Transform weapons = this.transform.Find(nameObject);
		for (int i = 0; i < weapons.childCount; ++i)
		{
			weapons.GetChild(i).GetComponent<SimpleWeapons>().StopWeapon();
		}
	}
}
