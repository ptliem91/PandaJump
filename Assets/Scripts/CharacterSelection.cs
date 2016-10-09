﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class CharacterSelection : MonoBehaviour
{
	public static CharacterSelection instance;

	private int selection = 0;
	public List<GameObject> characters = new List<GameObject> ();

	void Awake ()
	{
		foreach (GameObject chara in characters) {
			chara.SetActive (false);
		}

		if (PlayerPrefs.HasKey (GlobalValue.CHARACTER_INDEX)) {
			selection = PlayerPrefs.GetInt (GlobalValue.CHARACTER_INDEX);
		}

		if (selection >= characters.Count || selection < 0) {
			selection = 0;
		}

		characters [selection].SetActive (true);

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
		PlayerPrefs.SetInt (GlobalValue.CHARACTER_INDEX, selection);
		SceneFader.instance.FadeIn ("Main");
	}
}