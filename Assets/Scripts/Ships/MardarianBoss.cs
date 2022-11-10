using UnityEngine;
using System.Collections;

public class MardarianBoss : EnemyBoss
{
    protected override void DefaultSetup()
	{
		stopPoint = new Vector2(0, 2.7f);
		base.DefaultSetup();
    }

	protected override IEnumerator StartWeaponOne()
	{
		StartWeapon("WeaponOne");
		yield return new WaitForSeconds(15);
		StopWeapon("WeaponOne");
		yield return new WaitForSeconds(2);
		StartCoroutine(StartWeaponTwo());
	}

	protected IEnumerator StartWeaponTwo()
	{
		StartWeapon("WeaponTwo");
		yield return new WaitForSeconds(15);
		StopWeapon("WeaponTwo");
		yield return new WaitForSeconds(2);
		StartCoroutine(StartWeaponOne());
	}
}
