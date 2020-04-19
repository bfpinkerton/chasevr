using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthCounter : MonoBehaviour
{
    public Text healthCounterText;
	public static int healthCounter = 3;
	public static int sphereCounter = 0;
	
	
	void Start(){
		healthCounter = 3;
		sphereCounter = 0;
		PlayerPrefs.SetInt("win",0);

	}
	
    void Update()
    {
		Debug.Log(sphereCounter);
        healthCounterText.text = "Lives: " + healthCounter.ToString();
		
		if(healthCounter <= 0){
			SceneManager.LoadScene(3);
		}
		if(sphereCounter >= 244){
			PlayerPrefs.SetInt("win", 1);
			SceneManager.LoadScene(3);
		}
    }
}
