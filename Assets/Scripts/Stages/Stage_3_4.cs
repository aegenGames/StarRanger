using UnityEngine;

public class Stage_3_4 : Stage_3_2
{
	protected override void WaveOne()
	{
		base.WaveSix();
	}

	protected override void WaveTwo()
	{
		base.WaveFour();
	}

	protected override void WaveThree()
	{
		base.WaveSeven();
	}

	protected override void WaveFour()
	{
		base.WaveTwo();
	}

	protected override void WaveFive()
	{
		base.WaveThree();
	}

	protected override void WaveSix()
	{
		base.WaveOne();
	}

	protected override void WaveSeven()
	{
		Instantiate(SupremePrefabs[6]);
	}
}
