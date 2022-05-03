using UnityEngine;

public class MardarianBoss : EnemyBoss
{
	protected override void Start()
	{
		base.Start();
		stopPoint = new Vector2(0, 2.7f);
	}

	protected override void StartWeaponOne()
	{
		StartWeapon("WeaponOne");
		Invoke("StopWeaponOne", 15);
	}

	protected void StopWeaponOne()
	{
		StopWeapon("WeaponOne");
		Invoke("StartWeaponTwo", 2);
	}

	protected void StartWeaponTwo()
	{
		StartWeapon("WeaponTwo");
		Invoke("StopWeaponTwo", 15);
	}

	protected void StopWeaponTwo()
	{
		StopWeapon("WeaponTwo");
		Invoke("StartWeaponOne", 2);
	}
}
