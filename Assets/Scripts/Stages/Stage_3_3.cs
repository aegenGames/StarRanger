using UnityEngine;

public class Stage_3_3 : Stage_3_1
{
	protected override void WaveOne()
	{
		base.WaveThree();
	}

	protected override void WaveTwo()
	{
		base.WaveFive();
	}

	protected override void WaveThree()
	{
		base.WaveSeven();
	}

	protected override void WaveFour()
	{
		base.WaveSix();
	}

	protected override void WaveFive()
	{
		base.WaveOne();
	}

	protected override void WaveSix()
	{
		base.WaveTwo();
	}

	protected override void WaveSeven()
	{
		base.WaveFour();
	}
}
