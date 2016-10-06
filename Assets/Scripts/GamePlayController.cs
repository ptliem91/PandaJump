using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using AssemblyCSharp;

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

	//
	private bool isExited = true;

	//
	bool isPaused = false;

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

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!isExited) {
				Application.Quit (); 
			} else {
				isExited = false;
			}
		}
	}

	void OnGUI ()
	{
		if (isPaused) {
			PauseGameButton ();
		}
	}

	public void PauseGameButton ()
	{
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
		pauseButon.gameObject.SetActive (false);

		txtHighScore.text = ScoreController.instance.GetHighScore ().ToString ("0.0");

		UpdateImgMedal (ScoreController.instance.GetHighScore ());

		resumeButton.onClick.RemoveAllListeners ();
		resumeButton.onClick.AddListener (() => ReusmeGameButton ());
	}

	public void ReusmeGameButton ()
	{
		Time.timeScale = 1f;
		pausePanel.SetActive (false);

		pauseButon.gameObject.SetActive (true);
	}

	public void RestartGame ()
	{
		GlobalValue.AllSpeedIncrementGround = GlobalValue.START_SPEED_GROUND;
		
		Time.timeScale = 1f;
		SceneFader.instance.FadeIn ("Main");
	}

	public void PandaDiedShowPanel (float score)
	{
		pausePanel.SetActive (true);
		pauseButon.gameObject.SetActive (false);

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
		Time.timeScale = 1f;
		SceneFader.instance.FadeIn ("Start");
	}

	public void InscreamentScore (float score)
	{
		txtScore.text = score.ToString ("0.0");

		UpdateImgMedal (score);
	}

	public void UpdateImgMedal (float score)
	{
		if (score < 40f) {
			imgMedal.sprite = medalList [0];

		} else if (score >= 40f && score < 100f) {
			imgMedal.sprite = medalList [1];
			GlobalValue.AllSpeedIncrementGround = GlobalValue.NORMAL_SPEED_GROUND;

		} else if (score >= 100f && score < 150f) {
			imgMedal.sprite = medalList [2];
			GlobalValue.AllSpeedIncrementGround = GlobalValue.NORMAL_SPEED_GROUND;

		} else if (score >= 150f && score < 250f) {
			imgMedal.sprite = medalList [3];
			GlobalValue.AllSpeedIncrementGround = GlobalValue.HARD_SPEED_GROUND;

		} else if (score >= 250f && score < 350f) {
			imgMedal.sprite = medalList [4];
			GlobalValue.AllSpeedIncrementGround = GlobalValue.HARD_SPEED_GROUND;

		} else if (score >= 350f && score < 550f) {
			imgMedal.sprite = medalList [5];
			GlobalValue.AllSpeedIncrementGround = GlobalValue.VERY_HARD_SPEED_GROUND;

		} else if (score >= 550f && score < 750f) {
			imgMedal.sprite = medalList [6];
			GlobalValue.AllSpeedIncrementGround = GlobalValue.VERY_HARD_SPEED_GROUND;

		} else if (score >= 750f && score < 1150f) {
			imgMedal.sprite = medalList [7];
			GlobalValue.AllSpeedIncrementGround = GlobalValue.EXTREMLY_HARD_SPEDD_GROUND;

		} else if (score >= 1150f) {
			imgMedal.sprite = medalList [8];
			GlobalValue.AllSpeedIncrementGround = GlobalValue.EXTREMLY_HARD_SPEDD_GROUND;
		}
	}

	//Pause game
	void OnApplicationFocus (bool hasFocus)
	{
		isPaused = !hasFocus;
	}

	void OnApplicationPause (bool pauseStatus)
	{
		isPaused = pauseStatus;
	}

}


