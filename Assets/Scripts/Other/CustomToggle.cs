using UnityEngine.UI;

public class CustomToggle : Toggle
{
	private float HitMinimumThreshold = 0.001f;

	/// <summary>
	/// Ñlick works only when it hits the image.
	/// </summary>
	new void Start()
	{
		base.Start();
		this.image.alphaHitTestMinimumThreshold = HitMinimumThreshold;
	}
}
