using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
	public Text scoreText;
	public Text gameOverText;
	public GameObject playButton,replayButton;
	public  int Score;
	// Use this for initialization
	void Start () {
		Score = 0;
		playPause ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score:"+Score;
	}
	public void Gameplay()
	{
		//Debug.Log ("here");
		Score = 0;
		Time.timeScale = 1;
		playButton.SetActive(false);
		replayButton.SetActive (false);
	}
	void playPause()
	{

		Time.timeScale = 0;

	}
	public void gameOver(){
		
		playPause();
		replayButton.SetActive (true);
	}
}
