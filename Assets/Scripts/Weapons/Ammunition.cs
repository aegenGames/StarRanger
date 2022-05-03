using UnityEngine;

public class Ammunition : MonoBehaviour
{
	[SerializeField] private float speed = 1;
	[SerializeField] private bool isDestroyed = true;	// false - object will be hidden.
														// true - object will be destroyed.
	protected float xMin;
	protected float xMax;
	protected float yMin;
	protected float yMax;

	public float Speed { get => speed; set => speed = value; }

	void Start()
	{
		GeneralFunctions.GetBoard(0, 0, ref xMin, ref xMax, ref yMin, ref yMax);
	}

	void Update()
	{
		Move();
	}

	protected virtual void Move()
	{
		this.transform.position += this.transform.up * this.Speed * Time.deltaTime;
		CheckBoard();
	}

	protected virtual void CheckBoard()
	{
		if ((yMax < this.transform.position.y) || (yMin > this.transform.position.y) ||
			(xMax < this.transform.position.x) || (xMin > this.transform.position.x))
			
		{
			OnTriggerEnter2D(this.GetComponent<Collider2D>());
		}
	}

	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{
		if (isDestroyed)
			Destroy(this.gameObject);
		else
			this.gameObject.SetActive(false);
	}
}
