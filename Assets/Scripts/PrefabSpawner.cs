using UnityEngine;
using System.Collections;

public class PrefabSpawner : MonoBehaviour
{

	private float nextSpawn = 0f;

	public Transform[] prefabToSpawn;
	//	public float spawnRate = 1f;
	//	public float randomDelay = 3f;

	public AnimationCurve spawnCurveAnim;
	public float curveLengthInSeconds = 30f;
	private float startTime;
	public float jitter = 0.25f;

	// Use this for initialization
	void Start ()
	{
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > nextSpawn) {

			int randNum = Random.Range (0, prefabToSpawn.Length);

			Transform spawnRandom = prefabToSpawn [randNum];

			Instantiate (spawnRandom, transform.position, Quaternion.identity);
//			nextSpawn = Time.time + spawnRate + Random.Range (0, randomDelay);

			float curvePos = (Time.time - startTime) / curveLengthInSeconds;
			if (curvePos > 1f) {
				curvePos = 1f;
				startTime = Time.time;
			}

			nextSpawn = Time.time + spawnCurveAnim.Evaluate (curvePos) + Random.Range (-jitter, jitter);
		}
	}
}
