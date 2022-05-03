using UnityEngine;

public class PlayerLaser : Ammunition, IDmg
{
	public int Dmg { get => GameData.dmgOne; }
}
