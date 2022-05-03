using UnityEngine;

public class Stage_1_4 : Stage_1_2
{
	protected override void WaveOne()
	{
		base.WaveFour();
	}

	protected override void WaveTwo()
	{
		base.WaveSix();
	}

	protected override void WaveThree()
	{
		base.WaveFive();
	}

	protected override void WaveFour()
	{
		base.WaveOne();
	}

	protected override void WaveFive()
	{
		base.WaveSeven();
	}

	protected override void WaveSix()
	{
		base.WaveThree();
	}

	protected override void WaveSeven()
	{
		Instantiate(PiratePrefabs[7]);
		//base.WaveTwo();
	}
}
