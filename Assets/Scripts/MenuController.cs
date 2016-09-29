using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public void StartGame(){
//		Application.LoadLevel ("Main");
		SceneManager.LoadScene("Main");
	}
}
