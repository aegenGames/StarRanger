using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Ñlick works only when it hits the image.
/// </summary>
public class SpriteButton : MonoBehaviour
{
	private float HitMinimumThreshold = 0.001f;

	void Start()
	{
		gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = HitMinimumThreshold;
	}
}
