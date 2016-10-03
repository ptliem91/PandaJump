using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{

	public static SceneFader instance;

	[SerializeField]
	private GameObject fadeCanvas;

	[SerializeField]
	private Animator fadeAni;

	void Awake ()
	{
		MakeASingleInstance ();
	}

	void MakeASingleInstance ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	IEnumerator FadeInAnimate (string levelName)
	{
		fadeCanvas.SetActive (true);
		fadeAni.Play ("FadeIn");
		yield return StartCoroutine (MyCoroutine.waitForRealSecond (.7f));

//		Application.LoadLevel (levelName);
		SceneManager.LoadScene (levelName);
		FadeOut ();
	}

	IEnumerator FadeOutAnimate ()
	{
		fadeAni.Play ("FadeOut");
		yield return StartCoroutine (MyCoroutine.waitForRealSecond (1f));


		fadeCanvas.SetActive (false);

	}

	public void FadeIn (string levelName)
	{
		StartCoroutine (FadeInAnimate (levelName));
	}

	public void FadeOut ()
	{
		StartCoroutine (FadeOutAnimate ());
	}
}
