using UnityEngine;
using System.Collections;

public class SimpleWeapons : MonoBehaviour, IWeapon
{
	[SerializeField] private Ammunition prefab;
	[SerializeField] protected float repeatRate = 3;

	public Ammunition Prefab { get => prefab; set => prefab = value; }

    void Awake()
    {
		AwakeSettup();
	}

	protected virtual void AwakeSettup()
    {
	}

    public virtual IEnumerator Weapon()
	{
		yield return new WaitForSeconds(0.4f);
		while (true)
		{
			yield return StartCoroutine(Shot());
			yield return new WaitForSeconds(repeatRate);
		}
	}

	public virtual IEnumerator Shot()
    {
		Instantiate(this.Prefab, this.transform.position, this.transform.rotation);
		yield break;
	}

	public virtual void StartWeapon()
	{
		StartCoroutine("Weapon");
	}

	public void StopWeapon()
	{
		StopCoroutine("Weapon");
	}

	public void RestartWeapon()
	{
		StopWeapon();
		StartWeapon();
	}
}
