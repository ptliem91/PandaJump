﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AssemblyCSharp;

//using System.Runtime.Serialization.Formatters.Binary;
//using System.IO;

public class ScoreController : MonoBehaviour
{
	//	private string PATH_DATA_FILE;

	public static ScoreController instance;

	private const string HIGH_SCORES = "High Score";

	[SerializeField]
	private Text txtTotalPoint, txtHighScoreMainMenu;

	private bool isQuit = true;

	void Awake ()
	{
		MakeASingleInstance ();

		txtTotalPoint.text = GetPointsCount ().ToString ("0");
		txtHighScoreMainMenu.text = GetHighScore ().ToString ("0.0");
//		PATH_DATA_FILE = Application.persistentDataPath + "playerInfo.dat";
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

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!isQuit) {
				Application.Quit (); 
			} else {
				isQuit = false;
			}
		}
	}

	public void SetHighScore (float score)
	{
		PlayerPrefs.SetFloat (HIGH_SCORES, score);
	}

	public float GetHighScore ()
	{
		return PlayerPrefs.GetFloat (HIGH_SCORES);
	}

	public void SetPointsCount (int point)
	{
		PlayerPrefs.SetInt (GlobalValue.POINTS_COUNT, point);
	}

	public int GetPointsCount ()
	{
		if (!PlayerPrefs.HasKey (GlobalValue.POINTS_COUNT)) {
			return 0;
		}
		return PlayerPrefs.GetInt (GlobalValue.POINTS_COUNT);
	}

	//Save data
	//	public void SaveData ()
	//	{
	//		BinaryFormatter bf = new BinaryFormatter ();
	//		FileStream fs = File.Create (PATH_DATA_FILE);
	//
	//		PlayerData pd = new PlayerData ();
	//		pd.lastSpeed = GlobalValue.AllSpeedIncrementGround;
	//
	//		bf.Serialize (fs, pd);
	//		fs.Close ();
	//	}
	//
	//	public void LoadData ()
	//	{
	//		if (File.Exists (PATH_DATA_FILE)) {
	//			BinaryFormatter bf = new BinaryFormatter ();
	//			FileStream fs = File.Open (PATH_DATA_FILE, FileMode.Open);
	//
	//			PlayerData pd = (PlayerData)bf.Deserialize (fs);
	//			fs.Close ();
	//
	//			GlobalValue.AllSpeedIncrementGround = pd.lastSpeed;
	//		}
	//	}
}

//[System.Serializable]
//class PlayerData
//{
//	public float lastSpeed;
//}