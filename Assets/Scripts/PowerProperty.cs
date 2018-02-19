using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerProperty : MonoBehaviour {
	string side;
	void OnEnable(){
		side = checkSideOfObject ();
	}
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.CompareTag("Player")){
		//Debug.Log ("powwer");
			GameManager.Instance.increaseScore();
			if (GameManager.Instance.getScore() % GameManager.Instance.speedIncreaseFactor == 0) {
				GameManager.Instance.speed += .25f;
			}
			//Debug.Log (""+ GameManager.Instance.Score);
			gameObject.GetComponent<SpriteRenderer>().enabled=false;
		//GameManager.Instance.respawnObjects(side);
		}
    }
	string checkSideOfObject(){
		if (transform.position.x < 0) {
			//left side
			return "left";
		} else {
			return "right";
		}
	}
}
