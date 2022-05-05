using UnityEngine;

public class SimpleWeapons : MonoBehaviour, IWeapon
{
	[SerializeField] private Ammunition prefab;
	[SerializeField] protected float repeatRate = 3;

	public Ammunition Prefab { get => prefab; set => prefab = value; }

	public virtual void Weapon()
	{
		Instantiate(this.Prefab, this.transform.position, this.transform.rotation);
	}

	public virtual void StartWeapon()
	{
		InvokeRepeating("Weapon", 0.4f, repeatRate);
	}

	public void StopWeapon()
	{
		CancelInvoke("Weapon");
	}

	public void restartWeapon()
	{
		StopWeapon();
		StartWeapon();
	}
}
