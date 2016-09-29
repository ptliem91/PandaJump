using UnityEngine;
using System.Collections;

public class BGCollector : MonoBehaviour {

	private GameObject[] grounds;

	private float lastGroundPostX;

	void Awake(){
		grounds = GameObject.FindGameObjectsWithTag ("Ground");

		lastGroundPostX = grounds [0].transform.position.x;

		for(int i = 1; i < grounds.Length; i++){
			if(lastGroundPostX < grounds[i].transform.position.x){
				lastGroundPostX = grounds [i].transform.position.x;
			}
		}
	}

	//check va cham giua 2 vat the, ma 1 trong 2 co check isTrigger = true
	void OnTriggerEnter2D(Collider2D target){
		//loop ground
		 if(target.tag == "Ground"){
			Vector3 temp = target.transform.position;
			float width = ((BoxCollider2D)target).size.x;

			temp.x = lastGroundPostX + width;

			target.transform.position = temp;

			lastGroundPostX = temp.x;
		}
	}

}
