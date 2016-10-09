using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using AssemblyCSharp;

public class MenuController : MonoBehaviour
{

	public GameObject audioOnIcon;
	public GameObject audioOffIcon;

	[SerializeField]
	private GameObject selectCharacterPanel;

	[SerializeField]
	private GameObject buttonSelectCharacter;

	public void StartGame ()
	{
//		Application.LoadLevel ("Main");
//		SceneManager.LoadScene ("Main");
		SceneFader.instance.FadeIn ("Main");

		//Update speed ground
		GlobalValue.AllSpeedIncrementGround = GlobalValue.START_SPEED_GROUND;
	}

	public void ToggleSound ()
	{
		if (PlayerPrefs.GetInt ("Muted", 0) == 0) {
			PlayerPrefs.SetInt ("Muted", 1);
		} else {
			PlayerPrefs.SetInt ("Muted", 0);
		}

		SetSoundState ();
	}

	private void SetSoundState ()
	{
		if (PlayerPrefs.GetInt ("Muted", 0) == 0) {
			AudioListener.volume = 1;
			audioOffIcon.SetActive (false);
			audioOnIcon.SetActive (true);

		} else {
			AudioListener.volume = 0;
			audioOffIcon.SetActive (true);
			audioOnIcon.SetActive (false);
		}
	}

	public void ShowSelectCharacterPanel ()
	{
		selectCharacterPanel.SetActive (true);
		buttonSelectCharacter.SetActive (false);
	}

	public void BackButton ()
	{
		selectCharacterPanel.SetActive (false);
		buttonSelectCharacter.SetActive (true);
	}

}
