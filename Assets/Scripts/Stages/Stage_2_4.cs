using UnityEngine;

public class Stage_2_4 : Stage_2_2
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
		base.WaveSix();
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
		base.WaveTwo();
	}

	protected override void WaveSeven()
	{
		Instantiate(CyberPrefabs[5]);
	}
}
