using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//using System.Runtime.Serialization.Formatters.Binary;
//using System.IO;
//using AssemblyCSharp;

public class ScoreController : MonoBehaviour
{
	//	private string PATH_DATA_FILE;

	public static ScoreController instance;

	private const string HIGH_SCORES = "High Score";

	void Awake ()
	{
		MakeASingleInstance ();

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

	public void SetHighScore (float score)
	{
		PlayerPrefs.SetFloat (HIGH_SCORES, score);
	}

	public float GetHighScore ()
	{
		return PlayerPrefs.GetFloat (HIGH_SCORES);
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