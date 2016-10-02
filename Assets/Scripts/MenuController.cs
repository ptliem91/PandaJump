using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

	public GameObject audioOnIcon;
	public GameObject audioOffIcon;

	public void StartGame ()
	{
//		Application.LoadLevel ("Main");
		SceneManager.LoadScene ("Main");
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

}
