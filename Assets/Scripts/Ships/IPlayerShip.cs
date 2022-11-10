using UnityEngine;
using System.Collections;

interface IPlayerShip
{
	public IEnumerator StartWeaponOne();
	public IEnumerator StartWeaponTwo();
	public IEnumerator StartWeaponThree();
	public IEnumerator StartWeaponFour();
	public void StartWeapons();
	public void StopWeapons();
	public void StopWeaponOne();
	public void StopWeaponTwo();
}
