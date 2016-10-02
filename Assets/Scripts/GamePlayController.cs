using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
	
	public static GamePlayController instance;

	[SerializeField]
	private GameObject pausePanel;

	[SerializeField]
	private Button pauseButon, resumeButton;

	[SerializeField]
	private Text txtScore, txtHighScore;

	//Medal
	[SerializeField]
	private Image imgMedal;

	[SerializeField]
	private Sprite[] medalList;

	// Use this for initialization
	void Awake ()
	{
		MakeInstance ();
	}

	void MakeInstance ()
	{
		if (instance == null) {
			instance = this; 
		}
	}


	public void PauseGameButton ()
	{
		Time.timeScale = 0f;
		pausePanel.SetActive (true);

		txtHighScore.text = ScoreController.instance.GetHighScore ().ToString ("0.0");

		UpdateImgMedal (ScoreController.instance.GetHighScore ());

		resumeButton.onClick.RemoveAllListeners ();
		resumeButton.onClick.AddListener (() => ReusmeGameButton ());
	}

	public void ReusmeGameButton ()
	{
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void RestartGame ()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Main");
	}

	public void PandaDiedShowPanel (float score)
	{
		pausePanel.SetActive (true);

		if (score > ScoreController.instance.GetHighScore ()) {
			ScoreController.instance.SetHighScore (score);
		}
		txtHighScore.text = ScoreController.instance.GetHighScore ().ToString ("0.0");

		UpdateImgMedal (ScoreController.instance.GetHighScore ());

		resumeButton.onClick.RemoveAllListeners ();
		resumeButton.onClick.AddListener (() => RestartGame ());

	}

	public void MenuButton ()
	{
		SceneManager.LoadScene ("Start");
	}

	public void InscreamentScore (float score)
	{
		txtScore.text = score.ToString ("0.0");
	}

	private void UpdateImgMedal (float score)
	{
		if (score < 50f) {
			imgMedal.sprite = medalList [0];

		} else if (score >= 50f && score < 100f) {
			imgMedal.sprite = medalList [1];

		} else if (score >= 100f && score < 150f) {
			imgMedal.sprite = medalList [2];

		} else if (score >= 150f && score < 250f) {
			imgMedal.sprite = medalList [3];

		} else if (score >= 250f && score < 350f) {
			imgMedal.sprite = medalList [4];

		} else if (score >= 350f && score < 550f) {
			imgMedal.sprite = medalList [5];

		} else if (score >= 550f && score < 750f) {
			imgMedal.sprite = medalList [6];

		} else if (score >= 750f && score < 1150f) {
			imgMedal.sprite = medalList [7];

		} else if (score >= 1150f) {
			imgMedal.sprite = medalList [8];
		}
	}

}
