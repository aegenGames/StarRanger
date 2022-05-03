using UnityEngine;

public class Stage_1_3 : Stage_1_1
{
	protected override void WaveOne()
	{
		base.WaveFour();
	}

	protected override void WaveTwo()
	{
		base.WaveThree();
	}

	protected override void WaveThree()
	{
		base.WaveSix();
	}

	protected override void WaveFour()
	{
		base.WaveSeven();
	}

	protected override void WaveFive()
	{
		base.WaveFive();
	}

	protected override void WaveSix()
	{
		base.WaveOne();
	}

	protected override void WaveSeven()
	{
		base.WaveTwo();
	}
}
