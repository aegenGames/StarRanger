using UnityEngine;

public class Energy : MonoBehaviour
{
	[SerializeField] string nameWeapon = "Annihilator";
	
	protected float xMin;
	protected float xMax;
	protected float yMin;
	protected float yMax;

	void Start()
	{
		GeneralFunctions.GetBoard(0, 0, ref xMin, ref xMax, ref yMin, ref yMax);
	}

	void Update()
	{
		this.transform.position -= this.transform.up * Time.deltaTime;
		CheckBoard();
	}

	private void CheckBoard()
	{
		if ((yMax < this.transform.position.y) || (yMin > this.transform.position.y) ||
			(xMax < this.transform.position.x) || (xMin > this.transform.position.x))

		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject go = collision.gameObject;
		if(go.tag == "Player")
		{
			go.GetComponent<OrbitShip>().AddEnergy(nameWeapon);
			Destroy(this.gameObject);
		}
	}
}
