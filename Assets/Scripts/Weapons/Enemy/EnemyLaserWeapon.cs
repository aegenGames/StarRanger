using UnityEngine;
using System.Collections;

public class EnemyLaserWeapon : SimpleWeapons
{
	[SerializeField] protected int changeOfShot = 10;
	
    public override IEnumerator Shot()
	{
		if (Random.Range(0, 100) <= changeOfShot)
			yield return base.Shot();
    }
}
