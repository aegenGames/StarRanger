using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] protected int hp = 300;
	[SerializeField] protected float speed = 3;

	protected int credits;

	private bool shotAnnihilator = false;

	public int Hp { get => hp; set => hp = value; }

	protected void Start()
	{
		DefaultSetup();
	}

	protected virtual void DefaultSetup()
    {
		credits = hp / 10;
	}

	void Update()
	{
		Move();
	}

	protected virtual void Move() { }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject obj = collision.gameObject;
		if (obj.layer != LayerMask.NameToLayer("PlayerWeapons"))
			return;

		if (obj.tag == "Annihilator")
		{
			if (shotAnnihilator)
				return;
			shotAnnihilator = true;
		}

		Hp -= obj.GetComponent<IDmg>().Dmg;
		if (Hp <= 0)
		{
			GameData.credits += credits;
			Destroy(this.gameObject);
			float rand = Random.Range(0, 100);
			if (rand <= 3)
				Instantiate(Resources.Load("EnergyAnnihilator"), this.transform.position, Quaternion.identity);
			else if(rand >= 97)
				Instantiate(Resources.Load("EnergyHurricane"), this.transform.position, Quaternion.identity);
		}
	}
}
