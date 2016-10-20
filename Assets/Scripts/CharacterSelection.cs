using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
	public static CharacterSelection instance;

	private int selection = 0;
	public List<GameObject> characters = new List<GameObject> ();

	[SerializeField]
	private Button btnSelect, btnLock;

	void Awake ()
	{
//		GameObject go = Resources.Load ("Prefabs/GroundCake") as GameObject;

		//Set all character is false active
		foreach (GameObject chara in characters) {
			chara.SetActive (false);
		}

		if (PlayerPrefs.HasKey (GlobalValue.CHARACTER_SELECTED_INDEX)) {
			selection = PlayerPrefs.GetInt (GlobalValue.CHARACTER_SELECTED_INDEX);
		}

		if (selection >= characters.Count || selection < 0) {
			selection = 0;
		}

		characters [selection].SetActive (true);

//		go.GetComponent<SpriteRenderer> ().sprite = characters [selection];
		if (!PlayerPrefs.HasKey (GlobalValue.KEY_CHARACTER_LOCK_INDEX)) {
			PlayerPrefs.SetInt (GlobalValue.KEY_CHARACTER_LOCK_INDEX, GlobalValue.CHARACTER_LOCKED_INDEX);
		}

		MakeInstance ();
	}

	void MakeInstance ()
	{
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	//	void Start ()
	//	{
	//		foreach (GameObject chara in characters) {
	//			chara.SetActive (false);
	//		}
	//
	//		characters [selection].SetActive (true);
	//	}


	public void NextButton ()
	{
		characters [selection].SetActive (false);
		selection++;

		if (selection >= characters.Count) {
			selection = 0;
		}
		characters [selection].SetActive (true);

		disableButton ();
	}

	public void PreviousButton ()
	{
		characters [selection].SetActive (false);
		selection--;

		if (selection < 0) {
			selection = characters.Count - 1;
		}
		characters [selection].SetActive (true);

		disableButton ();
	}

	public void SelectButton ()
	{
		PlayerPrefs.SetInt (GlobalValue.CHARACTER_SELECTED_INDEX, selection);
		SceneFader.instance.FadeIn ("Main");
	}


	public void Unlock ()
	{
		if (GlobalValue.TOTAL_COIN_UNLOCK <= PlayerPrefs.GetInt (GlobalValue.POINTS_COUNT)) {
			btnLock.gameObject.SetActive (false);
			btnSelect.gameObject.SetActive (true);

			PlayerPrefs.SetInt (GlobalValue.KEY_CHARACTER_LOCK_INDEX, -1);
			PlayerPrefs.SetInt (GlobalValue.POINTS_COUNT, PlayerPrefs.GetInt (GlobalValue.POINTS_COUNT) - GlobalValue.TOTAL_COIN_UNLOCK);
		}

	}

	private void disableButton ()
	{
		int indexLock = PlayerPrefs.GetInt (GlobalValue.KEY_CHARACTER_LOCK_INDEX);
		
		if (selection == indexLock) {
			btnLock.gameObject.SetActive (true);
			btnSelect.gameObject.SetActive (false);
		} else {
			btnLock.gameObject.SetActive (false);
			btnSelect.gameObject.SetActive (true);
		}
	}
}
