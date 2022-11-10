using UnityEngine;
using System.Collections;


/// <summary>
/// Оружие игрока, выполняющее атаки самонаводящимися снарядами
/// Weapon of playe attacking with homing projectiles
/// </summary>
public class Turret : SimpleWeapons
{
	private int numberRocket = 0;
	private bool startHurricane = false;
	private Ammunition [] rocketPool;

    protected override void AwakeSettup()
    {
        base.AwakeSettup();
		rocketPool = new Ammunition[20];
		for (int i = 0; i < rocketPool.Length; ++i)
		{
			Ammunition rocket = Instantiate(this.Prefab, this.transform.position, Quaternion.identity);
			rocket.gameObject.SetActive(false);
			rocketPool[i] = rocket;
		}
	}

    public void StartHurricane()
    {
		if (startHurricane)
			return;

		startHurricane = true;
		RestartWeapon();
    }

	public override IEnumerator Weapon()
	{
		float HurricaneSpeedUp = 4;
		int hurricaneWavesCount = 14;
		while (true)
		{
			if (startHurricane)
			{
				ChangeRocketSpeed(HurricaneSpeedUp);
				for (int i = 0; i < hurricaneWavesCount; ++i)
				{
					StartCoroutine(Shot());
					yield return new WaitForSeconds(repeatRate / (HurricaneSpeedUp * 4));
				}
				ChangeRocketSpeed(1 / HurricaneSpeedUp);
				startHurricane = false;
				yield return new WaitForSeconds(2);
			}
			else
			{
				StartCoroutine(Shot());
				yield return new WaitForSeconds(repeatRate);
			}
        }
	}
	
    public override IEnumerator Shot()
    {
		while (rocketPool[numberRocket].gameObject.activeSelf)
		{
			++numberRocket;
			if (numberRocket == rocketPool.Length)
				numberRocket = 0;
		}
		Vector2 pos = this.GetComponent<MeshRenderer>().bounds.center;
		rocketPool[numberRocket].transform.position = pos;
		rocketPool[numberRocket].gameObject.SetActive(true);
		yield break;
	}

	public void ChangeRocketSpeed(float coefSpeedUp)
	{
		for (int i = 0; i < rocketPool.Length; ++i)
		{
			rocketPool[i].Speed = rocketPool[i].Speed * coefSpeedUp;
		}
	}
}