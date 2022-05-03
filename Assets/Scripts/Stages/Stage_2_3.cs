using UnityEngine;

public class Stage_2_3 : Stage_2_1
{
	protected override void WaveOne()
	{
		base.WaveThree();
	}

	protected override void WaveTwo()
	{
		base.WaveTwo();
	}

	protected override void WaveThree()
	{
		base.WaveOne();
	}

	protected override void WaveFour()
	{
		base.WaveFive();
	}

	protected override void WaveFive()
	{
		base.WaveSeven();
	}

	protected override void WaveSix()
	{
		base.WaveFour();
	}

	protected override void WaveSeven()
	{
		base.WaveSix();
	}
}
