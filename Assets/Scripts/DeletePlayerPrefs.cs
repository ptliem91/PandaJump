using UnityEngine;
using System.Collections;

public class DeletePlayerPrefs : MonoBehaviour
{

	void Awake ()
	{
		PlayerPrefs.DeleteAll ();
	}
}
