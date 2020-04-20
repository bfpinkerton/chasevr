using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public Text scoreText;
	public static int gameScore = 0;

    // Update is called once per frame
	
	void Start(){
		PlayerPrefs.SetInt("active_score", 0);
		gameScore = 0;
	}
	
    void Update()
    {
       scoreText.text = gameScore.ToString();
	   PlayerPrefs.SetInt("active_score", gameScore);
    }
}
