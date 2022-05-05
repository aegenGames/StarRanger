using UnityEngine;

public class OrbitShip : Player
{
	protected override void Start()
	{
		base.Start();
	}

	public override void MoveBorders()
	{
		float widthObject = this.gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().bounds.size.x / 2;
		float heightObject = this.GetComponent<MeshRenderer>().bounds.size.y / 2;
		GeneralFunctions.GetBoard(heightObject, widthObject, ref xMin, ref xMax, ref yMin, ref yMax);
	}

	public override void StartWeaponOne()
	{
		int numDrons = GameData.lvlOne;
		Transform drons = this.transform.Find("Drons");

		for (int i = 0; i < numDrons; ++i)
		{
			if ((numDrons == 2) && (i == 0))
			{
				++numDrons;
				++i;
			}
			Transform dron = drons.GetChild(i);
			dron.gameObject.SetActive(true);

			dron.GetComponent<SimpleWeapons>().StartWeapon();
		}
	}

	public override void StartWeaponTwo()
	{
		int numTurrets = GameData.lvlTwo;
		Transform orbit = this.transform.Find("Orbit");

		for (int i = 0; i < numTurrets; ++i)
		{
			if ((numTurrets == 2) && (i == 1))
				i = 2;
			Transform turretStand = orbit.GetChild(i);
			turretStand.gameObject.SetActive(true);

			Turret turret = turretStand.GetChild(0).GetComponent<Turret>();
			turret.StartWeapon();
		}
	}

	public override void StopWeaponOne()
	{
		Transform drons = this.transform.Find("Drons");

		for (int i = 0; i < drons.childCount; ++i)
		{
			drons.GetChild(i).GetComponent<SimpleWeapons>().StopWeapon();
			drons.GetChild(i).gameObject.SetActive(false);
		}
	}

	public override void StopWeaponTwo()
	{
		Transform orbit = this.transform.Find("Orbit");

		for (int i = 0; i < orbit.childCount; ++i)
		{
			orbit.GetChild(i).GetChild(0).GetComponent<SimpleWeapons>().StopWeapon();
			orbit.GetChild(i).gameObject.SetActive(false);
		}
	}

	public override void StartWeaponThree()
	{
		int numTurrets = GameData.lvlTwo;
		Transform orbit = this.transform.Find("Orbit");

		for (int i = 0; i < numTurrets; ++i)
		{
			Transform turretStand = orbit.GetChild(i);

			if (turretStand.gameObject.activeSelf)
			{
				Turret turret = turretStand.GetChild(0).GetComponent<Turret>();
				turret.Hurricane();
			}
		}
	}

	public override void StartWeaponFour()
	{
		this.transform.Find("AnnihilatorLaser").gameObject.SetActive(true);
		Invoke("StopWeaponFour", 2);
	}

	public void StopWeaponFour()
	{
		this.transform.Find("AnnihilatorLaser").gameObject.SetActive(false);
	}

	public override void StartWeapons()
	{
		StartWeaponOne();
		StartWeaponTwo();
	}

	public override void StopWeapons()
	{
		StopWeaponOne();
		StopWeaponTwo();
	}
}