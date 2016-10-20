using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using AssemblyCSharp;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

	public GameObject audioOnIcon;
	public GameObject audioOffIcon;

	[SerializeField]
	private GameObject selectCharacterPanel;

	[SerializeField]
	private Button btnLock, btnSelect;

	public void StartGame ()
	{
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

		Debug.Log ("ShowSelectCharacterPanel --->" + PlayerPrefs.GetInt (GlobalValue.KEY_CHARACTER_LOCK_INDEX));

		if (PlayerPrefs.GetInt (GlobalValue.CHARACTER_SELECTED_INDEX) == PlayerPrefs.GetInt (GlobalValue.KEY_CHARACTER_LOCK_INDEX)) {
			btnLock.gameObject.SetActive (true);
			btnSelect.gameObject.SetActive (false);
		} else {
			btnLock.gameObject.SetActive (false);
			btnSelect.gameObject.SetActive (true);
		}
	}

	public void BackButton ()
	{
		selectCharacterPanel.SetActive (false);
	}

}
