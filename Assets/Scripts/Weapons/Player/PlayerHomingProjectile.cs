using UnityEngine;

public class PlayerHomingProjectile : HomingProjectile, IDmg
{
	public int Dmg { get => GameData.dmgTwo; }

	protected override void Move()
	{
		if (!target)
		{
			target = GeneralFunctions.TargetSearch(targetTag, this.transform.position);
		}
		base.Move();
	}

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		target = null;
		base.OnTriggerEnter2D(collision);
	}
}
