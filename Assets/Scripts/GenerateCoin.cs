using UnityEngine;
using System.Collections;

public class GenerateCoin : MonoBehaviour
{
	private float startTime;
	private float nextSpawn = 0f;

	public float spawnRate = 1f;
	public float randomDelay = 3f;

	public Transform prefabCoinToSpawn;

	void Start ()
	{
		startTime = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (startTime > Random.Range (300, 1000) && Time.time > nextSpawn) {

			Instantiate (prefabCoinToSpawn, transform.position, Quaternion.identity);

			nextSpawn = Time.time + spawnRate + Random.Range (3, randomDelay);
		} else {
			startTime++;
		}
	}
}
