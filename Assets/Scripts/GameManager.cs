using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private static GameManager instance=null;
	public GameObject obstracle, power;
	public List<GameObject> obstracleList = new List<GameObject> ();
	public List<GameObject>powerList = new List<GameObject> ();
	public int noOfObjects;
	public int objectGap;
	public int speedIncreaseFactor;
	public float speed;
	float initialSpeed;
	int obstracleIndex;
	int powerIndex;
	public Transform endPoint;
	public roadManager roadManagerL,roadManagerR;
	public UIManager uiManager;
    

   
    public static GameManager Instance{
		get{
			if (instance == null) {
				instance = GameObject.FindGameObjectWithTag("Player").AddComponent<GameManager> ();
			}
			return instance;
		}

	}
	void Awake(){
		if ((instance) && instance.GetInstanceID () != GetInstanceID ()) {
			DestroyImmediate (instance);
		}
		else{
			instance = this;
			//DontDestroyOnLoad(gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		initialSpeed = speed;
        obstracleIndex = 0;
		powerIndex = 0;
		makeObstracle ();
		makePower ();
		//SceneManager.LoadScene ("game");

	}
	void makeObstracle(){
		for (int i = 0; i < noOfObjects; i++) {
			obstracleList.Add (Instantiate (obstracle));
			obstracleList [i].SetActive (false);
			//obstracleList [i].transform.SetParent (instance.gameObject.transform);
		}
	}
	void makePower(){
		for (int i = 0; i < noOfObjects; i++) {
			powerList.Add (Instantiate (power));
			powerList [i].SetActive (false);
			//powerList [i].transform.SetParent (instance.gameObject.transform);
		}
	}
	//need to set active
	public GameObject getObstracle(){
		GameObject temp = obstracleList [obstracleIndex];
		obstracleIndex++;
		checkBoundary ();
		return temp;

	}
	//need to set active
	public GameObject getPower(){
		GameObject temp = powerList [powerIndex];
		powerIndex++;
		checkBoundary ();
		return temp;
	}
	void checkBoundary(){
		obstracleIndex = obstracleIndex % noOfObjects;
		powerIndex = powerIndex % noOfObjects;
	}
	public void respawnObjects(string message){
		if (string.Compare("left", message)==0) {
			roadManagerL.addObjects ();
		}
			else if(string.Compare("right", message)==0) {
			roadManagerR.addObjects ();
		}

	}
	public int getScore(){
		return uiManager.Score;
	}
	public void increaseScore(){
		uiManager.Score++;
	}
	public void gameOver(){
		speed = initialSpeed;
		collectAllObjects ();
		uiManager.gameOver ();
	}
	void collectAllObjects(){
		for (int i = 0; i < noOfObjects; i++) {
			obstracleList [i].SetActive (false);
			powerList [i].SetActive (false);
			powerIndex = 0;
			obstracleIndex = 0;
		}
		roadManagerL.makeScene ();
		roadManagerR.makeScene ();

	}
}
