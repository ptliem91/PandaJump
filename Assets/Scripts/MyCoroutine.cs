using UnityEngine;
using System.Collections;

public static class MyCoroutine  {

	public static IEnumerator waitForRealSecond(float time){
		float start = Time.realtimeSinceStartup;

		while(Time.realtimeSinceStartup < (start + time)){
			yield return null; // moi giay ignore 1 khung hinh ???
		}
	}
}
