using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Curve;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
	[SerializeField] private Player player;
	[SerializeField] private Stage [] Stages;
	[SerializeField] private Enemy [] cyberPrefabs;
	[SerializeField] private Enemy [] piratePrefabs;
	[SerializeField] private Enemy [] mardarianPrefabs;
	[SerializeField] private Enemy [] supremePrefabs;
	[SerializeField] private BGCurve [] curvepaths;     // Curves for move ships.
	[SerializeField] private GameObject description;    // Descriptions for skills.
	[SerializeField] private Image background;

	Stage currentStage = null;
	private Vector2 [][] paths;     // Paths for move ships.
	private bool isBuy = false;
	private int stageNum = 0;

	void Start()
	{
		if (paths == null)
		{
			GetCurvesPath();
		}

		GameData.ResetGame();

		player.MoveBorders();
		StartPlayerWeapon();
		player.Killed += EndGame;
		player.ChangeLifes += ChangeLifes;
		player.AddEnergy += AddEnergy;

		LaunchStage();
	}

	/// <summary>
	/// Transforming curves in path.
	/// </summary>
	private void GetCurvesPath()
	{
		Vector3 prevuePoint;
		paths = new Vector2[curvepaths.Length][];
		for (int k = 0; k < curvepaths.Length; ++k)
		{
			BGCurveAdaptiveMath BGCMath = new BGCurveAdaptiveMath(curvepaths[k],
										  new BGCurveAdaptiveMath.ConfigAdaptive(BGCurveAdaptiveMath.Fields.Position));
			List<BGCurveBaseMath.SectionInfo> sections = BGCMath.SectionInfos;
			List<Vector2> pathMove = new List<Vector2>();

			prevuePoint = sections[0].Points[0].Position;
			for (int i = 0; i < sections.Count; ++i)
			{
				List<BGCurveBaseMath.SectionPointInfo> points = sections[i].Points;
				for (int j = 0; j < points.Count; ++j)
				{
					if (Vector3.Distance(prevuePoint, points[j].Position) > 0.2)
					{
						prevuePoint = points[j].Position;
						pathMove.Add(prevuePoint);
					}
				}
			}

			paths[k] = new Vector2[pathMove.Count];
			pathMove.CopyTo(paths[k]);
		}
	}

	private void LaunchStage()
	{
		if (currentStage)
			Destroy(currentStage.gameObject);

		currentStage = Instantiate(Stages[stageNum]);
		currentStage.Paths = paths;
		currentStage.CyberPrefabs = this.cyberPrefabs;
		currentStage.PiratePrefabs = this.piratePrefabs;
		currentStage.SupremePrefabs = this.supremePrefabs;
		currentStage.MardarianPrefabs = this.mardarianPrefabs;

		if(stageNum < 15)
			currentStage.EndStage += LvLMenu;
		else
			currentStage.EndStage += EndGame;
		currentStage.Launch();
	}

	private void StopPlayerWeapon()
	{
		player.StopWeapons();
	}

	private void StartPlayerWeapon()
	{
		player.StartWeapons();
	}

	/// <summary>
	/// Start LvL menu.
	/// </summary>
	private void LvLMenu()
	{
		clearScene();
		player.IsZeroMove = true;

		this.transform.Find("UserInterface").gameObject.SetActive(false);
		this.transform.Find("LvLMenu").gameObject.SetActive(true);
		Text text = this.transform.Find("LvLMenu").Find("Points").GetComponent<Text>();
		text.text = "Credits : " + GameData.credits.ToString();
	}

	/// <summary>
	/// Start next LvL.
	/// </summary>
	public void Next(ToggleGroup tGroup)
	{
		Toggle tg = tGroup.GetFirstActiveToggle();
		if (tg)
			tg.isOn = false;

		++stageNum;
		this.transform.Find("LvLMenu").gameObject.SetActive(false);
		this.transform.Find("UserInterface").gameObject.SetActive(true);
		player.IsZeroMove = false;
		Invoke("LaunchStage", 7);
	}

	public void PlayAgain()
	{
		clearScene();
		player.gameObject.SetActive(true);

		Transform endGame = this.transform.Find("EndGame");
		endGame.gameObject.SetActive(false);
		endGame.Find("Win").gameObject.SetActive(false);
		endGame.Find("GameOver").gameObject.SetActive(false);

		GameData.ResetGame();
		player.StopWeapons();
		player.StartWeapons();
		player.transform.position = new Vector2(0, -4);
		player.NumLifes = 3;
		ChangeLifes();

		this.transform.Find("UserInterface").Find("Controller").Find("Annihilator").gameObject.SetActive(false);
		this.transform.Find("UserInterface").Find("Controller").Find("Hurricane").gameObject.SetActive(false);
		Transform lvlMenu = this.transform.Find("LvLMenu");
		for(int i = 0; i < lvlMenu.childCount; ++i)
		{
			Toggle tg = lvlMenu.GetChild(i).GetComponent<Toggle>();
			if (tg)
				tg.interactable = true;
		}
		lvlMenu.Find("AnnihilatorTg").GetChild(0).GetComponent<Image>().color = Color.red;
		lvlMenu.Find("HurricaneTg").GetChild(0).GetComponent<Image>().color = Color.red;
		lvlMenu.Find("RocketDmgOne").GetChild(0).GetComponent<Image>().color = Color.red;
		lvlMenu.Find("RocketDmgTwo").GetChild(0).GetComponent<Image>().color = Color.red;
		lvlMenu.Find("RocketDmgThree").GetChild(0).GetComponent<Image>().color = Color.red;

		stageNum = 0;
		LaunchStage();
	}

	public void Buy(ToggleGroup tGroup)
	{
		Toggle tg = tGroup.GetFirstActiveToggle();
		if (!tg)
			return;
		if (tg.transform.GetChild(0).GetComponent<Image>().color == Color.red)
			return;

		isBuy = true;
		tg.isOn = false;
		isBuy = false;
		Text text = this.transform.Find("LvLMenu").Find("Points").GetComponent<Text>();
		text.text = "Credits : " + GameData.credits.ToString();
	}

	/// <summary>
	/// Increase dron numbers.
	/// </summary>
	public void UpDron(Toggle tg)
	{
		GameObject textObject = description.transform.Find("Dron").gameObject;
		textObject.SetActive(!textObject.activeSelf);

		int price = 5000;
		if (tg.isOn)
		{
			++GameData.lvlOne;
		}
		else if ((!isBuy) || (price > GameData.credits))
			--GameData.lvlOne;
		else
		{
			GameData.credits -= price;
			tg.interactable = false;
		}

		player.StopWeaponOne();
		StartCoroutine(player.StartWeaponOne());
	}

	public void UpLaserDmg(Toggle tg)
	{
		GameObject textObject = description.transform.Find("UpLaserDmg").gameObject;
		textObject.SetActive(!textObject.activeSelf);

		int price = 7500;
		if (tg.isOn)
			GameData.dmgOne += 25;
		else if ((!isBuy) || (price > GameData.credits))
			GameData.dmgOne -= 25;
		else
		{
			GameData.credits -= price;
			tg.interactable = false;
			if (GameData.dmgOne >= 100)
			{
				GameObject annihilator = GameObject.Find("AnnihilatorTg");
				annihilator.transform.GetChild(0).GetComponent<Image>().color = Color.white;
			}
		}
	}

	// Increase rocket numbers.
	public void UpRocket(Toggle tg)
	{
		GameObject textObject = description.transform.Find("Rocket").gameObject;
		textObject.SetActive(!textObject.activeSelf);

		int price = 5000;
		if (tg.isOn)
			++GameData.lvlTwo;
		else if ((!isBuy) || (price > GameData.credits))
			--GameData.lvlTwo;
		else
		{
			GameData.credits -= price;
			tg.interactable = false;
			if (GameData.lvlTwo == 1)
			{
				GameObject[] rocketDmgToggles = GameObject.FindGameObjectsWithTag("UpRocketDmg");
				foreach (GameObject go in rocketDmgToggles)
					go.GetComponent<Image>().color = Color.white;
			}
			else if (GameData.lvlTwo == 4)
			{
				GameObject hurricane = GameObject.Find("HurricaneTg");
				hurricane.transform.GetChild(0).GetComponent<Image>().color = Color.white;
			}
		}

		player.StopWeaponTwo();
		StartCoroutine(player.StartWeaponTwo());
	}

	public void UpRocketDmg(Toggle tg)
	{
		if (tg.transform.GetChild(0).GetComponent<Image>().color == Color.red)
		{
			GameObject textObject = description.transform.Find("UpRocketDmgBlocked").gameObject;
			textObject.SetActive(!textObject.activeSelf);
		} else
		{
			GameObject textObject = description.transform.Find("UpRocketDmg").gameObject;
			textObject.SetActive(!textObject.activeSelf);
		}

		int price = 10000;
		if (tg.isOn)
			GameData.dmgTwo += 50;
		else if ((!isBuy) || (price > GameData.credits))
			GameData.dmgTwo -= 50;
		else
		{
			GameData.credits -= price;
			tg.interactable = false;
		}
	}

	// Demonstration ultimate skill.
	public void Annihilator(Toggle tg)
	{
		if (tg.transform.GetChild(0).GetComponent<Image>().color == Color.red)
		{
			GameObject textObject = description.transform.Find("AnnihilatorBlocked").gameObject;
			textObject.SetActive(!textObject.activeSelf);
		}
		else
		{
			GameObject textObject = description.transform.Find("Annihilator").gameObject;
			textObject.SetActive(!textObject.activeSelf);

			int price = 20000;
			if (tg.isOn)
				StartCoroutine(player.StartWeaponFour());
			else if ((isBuy) && (price < GameData.credits))
			{
				this.transform.Find("UserInterface").Find("Controller").Find("Annihilator").gameObject.SetActive(true);
				GameData.credits -= price;
				tg.interactable = false;
			}
		}
	}

	// Open ultimate skill.
	public void Annihilator(Button bt)
	{
		if (bt.GetComponent<Image>().fillAmount < 1)
			return;
		StartCoroutine(player.StartWeaponFour());
		bt.GetComponent<Image>().fillAmount = 0;
	}

	// Demonstration ultimate skill.
	public void Hurricane(Toggle tg)
	{
		if (tg.transform.GetChild(0).GetComponent<Image>().color == Color.red)
		{
			GameObject textObject = description.transform.Find("HurricaneBlocked").gameObject;
			textObject.SetActive(!textObject.activeSelf);
		}
		else
		{
			GameObject textObject = description.transform.Find("Hurricane").gameObject;
			textObject.SetActive(!textObject.activeSelf);

			int price = 30000;

			if (tg.isOn)
				StartCoroutine(player.StartWeaponThree());
			else if ((isBuy) && (price < GameData.credits))
			{
				this.transform.Find("UserInterface").Find("Controller").Find("Hurricane").gameObject.SetActive(true);
				GameData.credits -= price;
				tg.interactable = false;
			}
		}
	}

	// Open ultimate skill.
	public void Hurricane(Button bt)
	{
		if (bt.GetComponent<Image>().fillAmount < 1)
			return;
		StartCoroutine(player.StartWeaponThree());
		bt.GetComponent<Image>().fillAmount = 0;
	}

	public void AddEnergy(string nameWeapon)
	{
		Image img = this.transform.Find("UserInterface").Find("Controller").Find(nameWeapon).GetChild(0).GetComponent<Image>();
		if (img.fillAmount < 1)
			img.fillAmount += 0.1f;
	}

	public void EndGame()
	{
		clearScene();
		Destroy(currentStage.gameObject);
		Transform endGame = this.transform.Find("EndGame");
		endGame.gameObject.SetActive(true);
		background.raycastTarget = false;
		if (player.gameObject.activeSelf)
			endGame.Find("Win").gameObject.SetActive(true);
		else
			endGame.Find("GameOver").gameObject.SetActive(true);
	}

	public void ChangeLifes()
	{
		Transform lifeImages = this.transform.Find("LifeImages");
		if (player.NumLifes == 3)
		{
			for (int i = 0; i < player.NumLifes; ++i)
				lifeImages.GetChild(i).gameObject.SetActive(true);
		}
		else
		{
			lifeImages.GetChild(player.NumLifes).gameObject.SetActive(false);
		}
	}

	public void clearScene()
	{
		GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
		for (int i = 0; i < enemys.Length; ++i)
			Destroy(enemys[i]);
		GameObject[] enemyWeapons = GameObject.FindGameObjectsWithTag("EnemyWeapons");
		for (int i = 0; i < enemyWeapons.Length; ++i)
			Destroy(enemyWeapons[i]);
	}
}