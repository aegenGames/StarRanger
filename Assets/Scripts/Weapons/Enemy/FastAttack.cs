using UnityEngine;


/// <summary>
/// Periodically performs a quick series of attacks.
/// </summary>
public class FastAttack : Weapons
{
	[SerializeField] private int numberAttack = 3;  // Number of attacks before next volley.
	[SerializeField] private float intervalAttack = 0.3f;  // Interval bw attacks.

	private int attackNum = 0;	// Attack number.

	public override void Weapon()
	{
		InvokeRepeating("AttackWave", 0, intervalAttack);
	}

	private void AttackWave()
	{
		base.Weapon();
		++attackNum;
		if (attackNum >= numberAttack)
		{
			attackNum = 0;
			CancelInvoke("AttackWave");
		}
	}
}
