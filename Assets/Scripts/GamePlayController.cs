using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using AssemblyCSharp;

public class GamePlayController : MonoBehaviour
{
	public static GamePlayController instance;

	[SerializeField]
	private GameObject pausePanel, coinSpawer;

	[SerializeField]
	private Button resumeButton;

	[SerializeField]
	private Text txtScore, txtHighScore, txtPoint, txtTotalPoint;

	//Medal
	//	[SerializeField]
	//	private Image imgMedal;

	//	[SerializeField]
	//	private Sprite[] medalList;

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
//		pausePanel.SetActive (true);
//		pauseButon.gameObject.SetActive (false);
//		txtPoint.gameObject.SetActive (false);
		coinSpawer.SetActive (false);
//		playButon.gameObject.SetActive (true);
//
//		txtHighScore.text = ScoreController.instance.GetHighScore ().ToString ("0.0");
//		txtTotalPoint.text = ScoreController.instance.GetPointsCount ().ToString ("0");
//		txtGameOver.text = "Pause Game";
//
//		UpdateImgMedal (ScoreController.instance.GetHighScore ());

//		resumeButton.onClick.RemoveAllListeners ();
//		resumeButton.onClick.AddListener (() => ReusmeGameButton ());
	}

	public void ReusmeGameButton ()
	{
		Time.timeScale = 1f;
		pausePanel.SetActive (false);

//		pauseButon.gameObject.SetActive (true);
		txtPoint.gameObject.SetActive (true);
		coinSpawer.SetActive (true);
//		playButon.gameObject.SetActive (false);
		txtScore.gameObject.SetActive (true);
	}

	public void RestartGame ()
	{
		GlobalValue.AllSpeedIncrementGround = GlobalValue.START_SPEED_GROUND;
		
		Time.timeScale = 1f;
		SceneFader.instance.FadeIn ("Main");
	}

	public void PandaDiedShowPanel (float score, int coin)
	{
		pausePanel.SetActive (true);
//		pauseButon.gameObject.SetActive (false);
		txtPoint.gameObject.SetActive (false);
		coinSpawer.SetActive (false);
//		playButon.gameObject.SetActive (false);
		txtScore.gameObject.SetActive (false);

		if (score > ScoreController.instance.GetHighScore ()) {
			ScoreController.instance.SetHighScore (score);
		}
		txtHighScore.text = ScoreController.instance.GetHighScore ().ToString ("0.0");

		//Coin
		int currentPoint = ScoreController.instance.GetPointsCount ();
		ScoreController.instance.SetPointsCount (coin + currentPoint);

		txtTotalPoint.text = ScoreController.instance.GetPointsCount ().ToString ("0");

		UpdateImgMedal (ScoreController.instance.GetHighScore ());

		resumeButton.onClick.RemoveAllListeners ();
		resumeButton.onClick.AddListener (() => RestartGame ());

//		AdmobController.instance.RequestBanner ();

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

	public void InscreamentPoint (int coin)
	{
		txtPoint.text = coin.ToString ("0");
	}

	public void UpdateImgMedal (float score)
	{
		if (score < 30f) {
//			imgMedal.sprite = medalList [0];

		} else if (score >= 30f && score < 70f) {
//			imgMedal.sprite = medalList [1];
			GlobalValue.AllSpeedIncrementGround = GlobalValue.NORMAL_SPEED_GROUND;

		} else if (score >= 70f && score < 120f) {
//			imgMedal.sprite = medalList [2];
			GlobalValue.AllSpeedIncrementGround = GlobalValue.NORMAL_SPEED_GROUND;

		} else if (score >= 120f && score < 200f) {
//			imgMedal.sprite = medalList [3];
			GlobalValue.AllSpeedIncrementGround = GlobalValue.HARD_SPEED_GROUND;

		} else if (score >= 200f && score < 250f) {
//			imgMedal.sprite = medalList [4];
			GlobalValue.AllSpeedIncrementGround = GlobalValue.HARD_SPEED_GROUND;

		} else if (score >= 250f && score < 300) {
//			imgMedal.sprite = medalList [5];
			GlobalValue.AllSpeedIncrementGround = GlobalValue.VERY_HARD_SPEED_GROUND;

		} else if (score >= 300f && score < 370f) {
//			imgMedal.sprite = medalList [6];
			GlobalValue.AllSpeedIncrementGround = GlobalValue.VERY_HARD_SPEED_GROUND;

		} else if (score >= 370f && score < 500f) {
//			imgMedal.sprite = medalList [7];
			GlobalValue.AllSpeedIncrementGround = GlobalValue.EXTREMLY_HARD_SPEDD_GROUND;

		} else if (score >= 500f) {
//			imgMedal.sprite = medalList [8];
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


