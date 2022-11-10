using UnityEngine;

public class EnemyHomingProjectile : HomingProjectile
{
	[SerializeField] private float minDist = 2;

	void Awake()
	{
		target = GeneralFunctions.TargetSearch(targetTag, this.transform.position);
	}

	protected override void Move()
	{
		if (target && (Vector2.Distance(target.transform.position, this.transform.position) < minDist))
			target = null;
		base.Move();
	}
}
