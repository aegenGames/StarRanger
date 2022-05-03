using UnityEngine;

public class SupremeBoss : EnemyBoss
{
    protected override void Start()
    {
        base.Start();
        stopPoint = new Vector2(0, 3);
    }

    protected override void StartWeaponOne()
    {
        StartWeapon("WeaponOne");
        Invoke("StopWeaponOne", 15);
    }

    protected void StopWeaponOne()
    {
        StopWeapon("WeaponOne");
        Invoke("StartWeaponTwo", 2);
    }

    protected  void StartWeaponTwo()
    {
        StartWeapon("WeaponTwo");
        Invoke("StopWeaponTwo", 15);
    }

    protected void StopWeaponTwo()
    {
        StopWeapon("WeaponTwo");
        Invoke("StartWeaponThree", 2);
    }

    protected  void StartWeaponThree()
    {
        StartWeapon("WeaponThree");
        Invoke("StopWeaponThree", 10);
    }

    protected void StopWeaponThree()
    {
        StopWeapon("WeaponThree");
        Invoke("StartWeaponFour", 2);
    }

    protected  void StartWeaponFour()
    {
        Transform weapons = this.transform.Find("WeaponFour");
        weapons.GetChild(0).GetComponent<SummonerWeapon>().StartWeapon();
        Invoke("StopWeaponFour", 14);
    }

    protected void StopWeaponFour()
    {
        Transform weapons = this.transform.Find("WeaponFour");
        weapons.GetChild(0).GetComponent<SummonerWeapon>().StopWeapon();
        Invoke("StartWeaponOne", 2);
    }
}
