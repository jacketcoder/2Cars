using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
	public Text scoreText;
	public Text gameOverText;
	public GameObject playButton,replayButton;
	public  int Score;
    int bestScore;
    public Text bestScoreText;
    // Use this for initialization
	void Start () {
		
        bestScore = PlayerPrefs.GetInt("bestScore");
        bestScoreText.text= "Best:  " + Score;
        playPause ();

	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: "+Score;
        bestScore = PlayerPrefs.GetInt("bestScore");
        bestScoreText.text = "Best:  " + Score;
        if (Score >bestScore)
        {
            bestScoreText.text = "Best:  " + Score;
            PlayerPrefs.SetInt("bestScore", Score);
        }
	}
	public void Gameplay()
	{
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
