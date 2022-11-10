using UnityEngine;
using System.Collections;


/// <summary>
/// Periodically performs a quick series of attacks.
/// </summary>
public class FastAttackWeapon : SimpleWeapons
{
	[SerializeField] private int attackCount = 3;  // Number of attacks before next volley.
	[SerializeField] private float intervalAttack = 0.3f;  // Interval bw attacks.

    public override IEnumerator Shot()
	{
		for (int i = 0; i < attackCount; ++i)
		{
			StartCoroutine(base.Shot());
			yield return new WaitForSeconds(intervalAttack);
		}
	}
}
