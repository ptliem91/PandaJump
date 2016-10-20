using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class MoveLeft : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
	{
//		Debug.Log (GlobalValue.AllSpeedIncrementGround);
		transform.position += Vector3.left * GlobalValue.AllSpeedIncrementGround * Time.deltaTime;
	}
}
