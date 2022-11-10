using UnityEngine;
using System.Collections;

public class PirateBoss : EnemyBoss
{
    protected override void DefaultSetup()
	{
		stopPoint = new Vector2(0, 3);
		base.DefaultSetup();
    }

    protected override IEnumerator StartWeaponOne()
	{
		StartWeapon("WeaponOne");
		StartWeapon("WeaponTwo");
		yield break;
	}
}
