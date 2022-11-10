using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallJoystick : MonoBehaviour
{
	[SerializeField] private Joystick joystick;
	[SerializeField] private GameObject lvlMenu;
	[SerializeField] private GameObject endGame;
	private Image imgJoystick;
	private Image imgHandle;
	private Color colorJoystick;
	private Color colorHandle;

	private void Awake()
	{
		imgJoystick = joystick.GetComponent<Image>();
		imgHandle = joystick.transform.GetChild(0).GetComponent<Image>();
		colorJoystick = imgJoystick.color;
		colorHandle = imgHandle.color;
	}

	private void OnMouseDown()
	{
		if (lvlMenu.activeSelf || endGame.activeSelf)
			return;

		joystick.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
		SetAlpha(1);
	}

	private void OnMouseUp()
	{
		SetAlpha(0);
	}

	private void SetAlpha(float alpha)
	{
		colorJoystick.a = alpha;
		colorHandle.a = alpha;

		imgJoystick.color = colorJoystick;
		imgHandle.color = colorHandle;
	}
}
