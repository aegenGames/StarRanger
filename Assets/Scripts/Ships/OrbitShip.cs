using UnityEngine;
using System.Collections;

public class OrbitShip : Player
{
	Transform drons;

	private void Awake()
    {
		drons = this.transform.Find("Drons");
	}

    public override void MoveBorders()
	{
		float widthObject = this.gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().bounds.size.x / 2;
		float heightObject = this.GetComponent<MeshRenderer>().bounds.size.y / 2;
		GeneralFunctions.GetBoard(heightObject, widthObject, ref xMin, ref xMax, ref yMin, ref yMax);
	}

	public override IEnumerator StartWeaponOne()
	{
		int numDrons = GameData.lvlOne;
		

		for (int i = 0; i < numDrons; ++i)
		{
			if ((numDrons == 2) && (i == 0))
			{
				++numDrons;
				++i;
			}
			Transform dron = drons.GetChild(i);
			dron.gameObject.SetActive(true);
			yield return new WaitForEndOfFrame();
			dron.GetComponent<SimpleWeapons>().StartWeapon();
		}
	}

	public override IEnumerator StartWeaponTwo()
	{
		int numTurrets = GameData.lvlTwo;
		Transform orbit = this.transform.Find("Orbit");

		for (int i = 0; i < numTurrets; ++i)
		{
			if ((numTurrets == 2) && (i == 1))
				i = 2;
			Transform turretStand = orbit.GetChild(i);
			turretStand.gameObject.SetActive(true);

			yield return new WaitForEndOfFrame();
			Turret turret = turretStand.GetChild(0).GetComponent<Turret>();
			turret.StartWeapon();
		}
	}

	public override void StopWeaponOne()
	{
		drons = this.transform.Find("Drons");

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

	public override IEnumerator StartWeaponThree()
	{
		int numTurrets = GameData.lvlTwo;
		Transform orbit = this.transform.Find("Orbit");

		for (int i = 0; i < numTurrets; ++i)
		{
			Transform turretStand = orbit.GetChild(i);

			if (turretStand.gameObject.activeSelf)
			{
				Turret turret = turretStand.GetChild(0).GetComponent<Turret>();
				turret.StartHurricane();
			}
		}
		yield break;
	}

	public override IEnumerator StartWeaponFour()
	{
		var annihilator = this.transform.Find("AnnihilatorLaser").gameObject;
		annihilator.SetActive(true);
		yield return new WaitForSeconds(2);
		annihilator.SetActive(false);
	}

	public override void StartWeapons()
	{
		StartCoroutine(StartWeaponOne());
		StartCoroutine(StartWeaponTwo());
	}

	public override void StopWeapons()
	{
		StopWeaponOne();
		StopWeaponTwo();
	}
}