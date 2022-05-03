using UnityEngine;


/// <summary>
/// Weapon summons sheeps.
/// </summary>
public class SummonerWeapon : Weapons
{
	[SerializeField] private HunterEnemy prefabEnemy;
	[SerializeField] private int numSummons = 10;
	[SerializeField] private float delayTime = 0;

	public override void Weapon()
	{
		for (int i = 0; i < numSummons; ++i)
		{
			float x = Random.Range(-1f, 1f);
			float y = Random.Range(-1f, 1f);
			float angle = GeneralFunctions.AngleRotateToPoint(Vector3.zero, new Vector3(x, y));

			HunterEnemy enemy = Instantiate(this.prefabEnemy, this.transform.position, Quaternion.Euler(0, 0, angle));
			enemy.callSwitch(delayTime);
		}
	}
}
