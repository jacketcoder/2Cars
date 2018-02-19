using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadManager : MonoBehaviour {
	public Transform Point;
	Vector3 tempSpawnPoint;
	public int Xgap,Ygap;
	public int objectAtFirst;
	public int objectActiveAtCamera;
	// Use this for initialization
	void Start () {
		makeScene ();
	}
	public void makeScene(){
		for (int i = 0; i < objectAtFirst; i++) {

			findPorbabilityOfPosition (i);
			findProbabilityAndSpawnObject ();
		}
	}
	void findPorbabilityOfPosition(int gapIndex){
		float temp = Random.Range (0f, 1f);
		if (temp > .5f) {
			//choose right
				Debug.Log("left choosed");
			tempSpawnPoint = new Vector3(Point.position.x-Xgap,Point.position.y+(gapIndex*Ygap),Point.position.z);


		} else {
			//choose left
			//Debug.Log("right choosed");
			tempSpawnPoint = new Vector3(Point.position.x+Xgap,Point.position.y+(gapIndex*Ygap),Point.position.z);
		}
		//Debug.Log (tempSpawnPoint);
	}
	void findProbabilityAndSpawnObject(){
		float temp = Random.Range (0f, 1f);
		if (temp > .5f) {
			//choose obstracle
			//	Debug.Log("obstracle choosed");
			spawnObjects(GameManager.Instance.getObstracle());
		} else {
			//choose power
			//Debug.Log("power choosed");
			spawnObjects(GameManager.Instance.getPower());
		}
	}
	void spawnObjects(GameObject toSpawn){
		toSpawn.transform.position = tempSpawnPoint;
		toSpawn.SetActive (true);

	}
	public void addObjects(){
		findPorbabilityOfPosition (objectActiveAtCamera);
		findProbabilityAndSpawnObject ();
	}
}

