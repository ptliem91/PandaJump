using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterSelection : MonoBehaviour
{

	private int selection = 0;
	public List<GameObject> characters = new List<GameObject> ();

	// Use this for initialization
	void Start ()
	{
		foreach (GameObject chara in characters) {
			chara.SetActive (false);
		}
	
		characters [selection].SetActive (true);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (Input.GetKeyDown (KeyCode.W)) {
			characters [selection].SetActive (false);
			selection++;
		
			if (selection >= characters.Count) {
				selection = 0;
			}
			characters [selection].SetActive (true);
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			characters [selection].SetActive (false);
			selection--;

			if (selection < 0) {
				selection = characters.Count - 1;
			}
			characters [selection].SetActive (true);
		}

		//
		if (Input.GetKeyDown (KeyCode.Space)) {
			PlayerPrefs.SetInt ("CharacterSelected", selection);
			SceneFader.instance.FadeIn ("Main");
		}
	}

	public void NextButton ()
	{
		characters [selection].SetActive (false);
		selection++;

		if (selection >= characters.Count) {
			selection = 0;
		}
		characters [selection].SetActive (true);
	}

	public void PreviousButton ()
	{
		characters [selection].SetActive (false);
		selection--;

		if (selection < 0) {
			selection = characters.Count - 1;
		}
		characters [selection].SetActive (true);
	}

	public void SelectButton ()
	{
		PlayerPrefs.SetInt ("CharacterSelected", selection);
		SceneFader.instance.FadeIn ("Main");
	}
}
