using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour {

	public float speed = 5f;
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.left * speed * Time.deltaTime;
	}
}
