using System;
using UnityEngine;

public class Player : MonoBehaviour {

	private System.Action killed;
	private System.Action changeLifes;
	private System.Action<string> addEnergy;
	private bool isZeroMove = false;    // true - moving to zero point.
	private bool immortal = false;
	private int numLifes = 3;
	private Vector3 zeroPoint = new Vector3(0, -3);

	// Bounding board points for move.
	protected float xMin;
	protected float xMax;
	protected float yMin;
	protected float yMax;

	[SerializeField] private float speed = 3;
	[SerializeField] private Joystick joystick;

	public bool IsZeroMove { get => isZeroMove; set => isZeroMove = value; }
	public int NumLifes { get => numLifes; set => numLifes = value; }
	public System.Action Killed { get => killed; set => killed = value; }
	public System.Action ChangeLifes { get => changeLifes; set => changeLifes = value; }
	public Action<string> AddEnergy { get => addEnergy; set => this.addEnergy = value; }

	protected virtual void Start()
	{
		MoveBorders();
	}

	void Update()
	{
		if (IsZeroMove)
			ZeroMove();
		else
			Move();
	}

	protected void Move()
	{
		var deltaX = joystick.Horizontal * Time.deltaTime * speed;
		var newPosX = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
		var deltaY = joystick.Vertical * Time.deltaTime * speed;
		var newPosY = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
		this.transform.position = new Vector2(newPosX, newPosY);
	}

	/// <summary>
	/// Moving to zero point.
	/// </summary>
	private void ZeroMove()
	{
		if (Vector3.Distance(this.transform.position, zeroPoint) > Mathf.Pow(10,-2))
		{
			this.transform.position += (zeroPoint - this.transform.position).normalized * speed / 10 * Time.deltaTime;
		}
	}

	public virtual void MoveBorders()
	{
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (immortal)
			return;

		GameObject obj = collision.gameObject;
		if ((obj.layer == LayerMask.NameToLayer("EnemyWeapons"))
			|| (obj.layer == LayerMask.NameToLayer("Enemy")))
		{
			--numLifes;
			if (numLifes < 0)
			{
				StopWeapons();
				this.gameObject.SetActive(false);
				killed();
			}
			else
			{
				this.transform.Find("Shield").gameObject.SetActive(true);
				immortal = true;
				Invoke("OffImmortal", 2);
				changeLifes();
			}
		}
	}

	private void OffImmortal()
	{
		this.transform.Find("Shield").gameObject.SetActive(false);
		immortal = false;
	}

	public virtual void StartWeaponOne() { }
	public virtual void StartWeaponTwo() { }
	public virtual void StartWeaponThree() { }
	public virtual void StartWeaponFour() { }
	public virtual void StartWeapons() { }
	public virtual void StopWeapons() { }
	public virtual void StopWeaponOne() { }
	public virtual void StopWeaponTwo() { }
}