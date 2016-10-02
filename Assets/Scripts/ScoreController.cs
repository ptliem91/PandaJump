using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public static ScoreController instance;

	private const string HIGH_SCORES = "High Score";

	void Awake(){
		MakeASingleInstance ();
	}

	void MakeASingleInstance(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void SetHighScore(float score){
		PlayerPrefs.SetFloat (HIGH_SCORES, score);
	}

	public float GetHighScore(){
		return PlayerPrefs.GetFloat (HIGH_SCORES);
	}
}
