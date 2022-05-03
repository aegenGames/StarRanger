using UnityEngine;


/// <summary>
/// Оружие игрока, выполняющее атаки самонаводящимися снарядами
/// Weapon of playe attacking with homing projectiles
/// </summary>
public class Turret : Weapons
{
	private float coefSpeedUp = 1;
	private int numberRocket = 0;
	private int hurWaveNum = 0;  // Rocket wave number when using ultimate
	private bool hurricaneIsReady = true;
	private Ammunition [] rocketPool;

	void Start()
	{
		rocketPool = new Ammunition[20];
		for (int i = 0; i < rocketPool.Length; ++i)
		{
			Ammunition rocket = Instantiate(this.Prefab, this.transform.position, Quaternion.identity);
			rocket.gameObject.SetActive(false);
			rocketPool[i] = rocket;
		}
	}

	public override void Weapon()
	{
		while(rocketPool[numberRocket].gameObject.activeSelf)
		{
			++numberRocket;
			if (numberRocket == rocketPool.Length)
				numberRocket = 0;
		}
		Vector2 pos = this.GetComponent<MeshRenderer>().bounds.center;
		rocketPool[numberRocket].transform.position = pos;
		rocketPool[numberRocket].gameObject.SetActive(true);

		if (coefSpeedUp > 1)
			++hurWaveNum;
		if(hurWaveNum == 14)
		{
			Hurricane();
		}
	}

	/// <summary>
	/// Ultimate skill.
	/// Increase speed and start frequency of rockets.
	/// </summary>
	public void Hurricane()
	{
		float coef = 5;
		if (hurricaneIsReady && (hurWaveNum == 0))
		{
			coefSpeedUp = coef;
			repeatRate /= coef * 4;
			restartWeapon();
			changeRocketSpeed();
			hurricaneIsReady = !hurricaneIsReady;
		}
		else if(!hurricaneIsReady && (hurWaveNum == 14))
		{
			coefSpeedUp = 1f / coef;
			repeatRate *= coef * 4;
			StopWeapon();
			Invoke("StartWeapon", 2);
			Invoke("changeRocketSpeed", 2);
			hurricaneIsReady = !hurricaneIsReady;
		}
	}

	public void changeRocketSpeed()
	{
		float curSpeed = rocketPool[numberRocket].Speed * coefSpeedUp;
		for (int i = 0; i < rocketPool.Length; ++i)
		{
			rocketPool[i].Speed = curSpeed;
		}
		hurWaveNum = 0;
	}
}
