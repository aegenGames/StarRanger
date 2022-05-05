using UnityEngine;


/// <summary>
/// Spray weapon.
/// Analog weapon from of "Contra")
/// </summary>
public class S : SimpleWeapons
{
	public override void Weapon()
	{
		int amount = 7;
		Vector3 targetPoint = new Vector3(1, -1);
		for (int i = 0; i <= amount; ++i)
		{
			float angle = GeneralFunctions.AngleRotateToPoint(Vector3.zero, targetPoint);
			Instantiate(this.Prefab, this.transform.position, Quaternion.Euler(0, 0, angle));
			targetPoint.x -= 2f / amount;
		}
	}
}
