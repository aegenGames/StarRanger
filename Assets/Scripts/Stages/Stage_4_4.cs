using UnityEngine;

public class Stage_4_4 : Stage
{
	public override void Launch()
	{
		stages = new System.Action[2];
		stages[0] += WaveOne;
		stages[1] += EndStage;
	}

	protected override void WaveOne()
	{
		Instantiate(MardarianPrefabs[6]);
	}
}
