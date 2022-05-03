using UnityEngine;

public class PirateBoss : EnemyBoss
{
	protected override void Start()
	{
		base.Start();
		stopPoint = new Vector2(0, 3);
	}

	protected override void StartWeaponOne()
	{
		StartWeapon("WeaponOne");
		StartWeapon("WeaponTwo");
	}
}
