using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
	public void ExitGame() {
		AudioManager.instance.PlayPressButton();
		Application.Quit();
	}
}
