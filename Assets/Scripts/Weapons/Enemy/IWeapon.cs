using UnityEngine;
using System.Collections;

interface IWeapon
{
	public IEnumerator Weapon();
	public void StartWeapon();
	public void StopWeapon();
}