using UnityEngine;

public class FollowingObject : MonoBehaviour
{
	[SerializeField] private string targetTag = "Player";
	private GameObject target;
	
	void Start()
	{
		target = GeneralFunctions.targetSearch(targetTag, this.transform.position);
	}

	void Update()
	{
		Rotation();
	}

	private void Rotation()
	{
		float angle = GeneralFunctions.AngleRotateToPoint(this.transform.position, target.transform.position);
		this.transform.rotation = Quaternion.Euler(0, 0, angle);
	}
}
