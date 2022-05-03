using UnityEngine;

public class EnemyLaserWeapon : Weapons
{
	[SerializeField] protected int changeOfShot = 10;
	
	public override void Weapon()
	{
		if (Random.Range(0, 100) <= changeOfShot)
			base.Weapon();
	}
}
