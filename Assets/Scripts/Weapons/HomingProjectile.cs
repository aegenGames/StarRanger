using UnityEngine;

public class HomingProjectile : Ammunition
{
	[SerializeField] protected string targetTag = "Player";

	protected GameObject target = null;

	protected override void Move()
	{
		if (target != null)
		{
			float angle = GeneralFunctions.AngleRotateToPoint(this.transform.position, target.transform.position);
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 0, angle), Speed * 2 * Time.deltaTime);
		}
		base.Move();
	}

	protected override void OnTriggerEnter2D(Collider2D collision)
	{
		base.OnTriggerEnter2D(collision);
	}
}
