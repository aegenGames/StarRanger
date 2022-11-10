using UnityEngine;
using System.Collections;

public class SupremeBoss : EnemyBoss
{
    protected override void DefaultSetup()
    {
        stopPoint = new Vector2(0, 3);
        base.DefaultSetup();
    }


    protected override IEnumerator StartWeaponOne()
    {
        StartWeapon("WeaponOne");
        yield return new WaitForSeconds(15);
        StopWeapon("WeaponOne");
        yield return new WaitForSeconds(2);
        StartCoroutine(StartWeaponTwo());
    }

    protected IEnumerator StartWeaponTwo()
    {
        StartWeapon("WeaponTwo");
        yield return new WaitForSeconds(15);
        StopWeapon("WeaponTwo");
        yield return new WaitForSeconds(2);
        StartCoroutine(StartWeaponThree());
    }

    protected IEnumerator StartWeaponThree()
    {
        StartWeapon("WeaponThree");
        yield return new WaitForSeconds(10);
        StopWeapon("WeaponThree");
        yield return new WaitForSeconds(2);
        StartCoroutine(StartWeaponFour());
    }

    protected IEnumerator StartWeaponFour()
    {
        Transform weapons = this.transform.Find("WeaponFour");
        weapons.GetChild(0).GetComponent<SummonerWeapon>().StartWeapon();
        yield return new WaitForSeconds(14);
        weapons.GetChild(0).GetComponent<SummonerWeapon>().StopWeapon();
        yield return new WaitForSeconds(2);
        StartCoroutine(StartWeaponOne());
    }
}
