using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PandaController : MonoBehaviour
{

	private Rigidbody2D pandaBody;

	public float pandaJumpForce = 500f;

	private Animator anim;

	private float pandaDiedTime = -1;

	//Score
	//	public Text txtScore;
	private float startTime;

	private float score = 0f;
	private int coin1 = 0;

	//nhay 2 lan
	private int jumpLeft = 2;
	//	bool isAndroidPlatform = false;

	//Audio
	public AudioSource jumpSfx;
	public AudioSource deathSfx;
	public AudioSource backgroundSfx;
	[SerializeField]
	private AudioClip deathClip;

	//
	private float lastClickTime = 0f;
	private float catchTime = 0.01f;

	// Use this for initialization
	void Start ()
	{
		pandaBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		startTime = Time.time;

//		if (Application.platform == RuntimePlatform.Android) {
//			isAndroidPlatform = true;
//		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (pandaDiedTime == -1) {
			if ((Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) && jumpLeft > 0) {
				if (pandaBody.velocity.y < 0 || pandaBody.velocity.y > 3.5f) {
					pandaBody.velocity = Vector2.zero;
				}

				if (jumpLeft == 1 || Input.touchCount > 1 || DoubleClick ()) {
					pandaBody.AddForce (transform.up * pandaJumpForce * 1f);
//					Debug.Log (jumpLeft);
				} else {
					pandaBody.AddForce (transform.up * pandaJumpForce);
				}

				jumpLeft--;

				jumpSfx.Play ();
			}

			anim.SetFloat ("vVelocity", pandaBody.velocity.y);

			score = (Time.time - startTime);
			GamePlayController.instance.InscreamentScore (score);
		} 
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			foreach (PrefabSpawner spawner in FindObjectsOfType<PrefabSpawner>()) {
				spawner.enabled = false;
			}

			foreach (MoveLeft moveLefter in FindObjectsOfType<MoveLeft>()) {
				moveLefter.enabled = false;
			}

			pandaDiedTime = Time.time;
			anim.SetBool ("Died", true);

			deathSfx.PlayOneShot (deathClip);
			backgroundSfx.Stop ();

			GamePlayController.instance.PandaDiedShowPanel (score, coin1);

		} else if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Point")) {
			Destroy (collision.gameObject);

			GamePlayController.instance.InscreamentPoint (++coin1);

		} else if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			jumpLeft = 2;
		}
	}

	//	private void Jump(float forceAdd){
	//		pandaBody.AddForce (transform.up * pandaJumpForce * forceAdd);
	//
	//	}

	//	bool isTouch(int tap){
	//		if (isAndroidPlatform) {
	//			return (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Began && Input.GetTouch (0).tapCount >= tap);
	//		} else {
	//			return Input.GetKey ("space") || Input.GetMouseButtonDown(0);
	//		}
	//
	//	}



	private bool DoubleClick ()
	{
		bool isDoubleClick = false;
		if (Input.GetButtonDown ("Fire1")) {
			if (Time.time - lastClickTime < catchTime) {
				//double click
				print ("done:" + (Time.time - lastClickTime).ToString ());
				isDoubleClick = true;
			} else {
				isDoubleClick = false;
			}
			lastClickTime = Time.time;
		}
		return isDoubleClick;
	}

	private bool DoubleTap ()
	{
		foreach (Touch touch in Input.touches) {
			if (touch.tapCount == 2) {
				Debug.Log ("Double tap!");
				return true;
			}
		}
		return false;
	}

}
