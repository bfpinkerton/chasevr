using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthCounter : MonoBehaviour
{
    public Text healthCounterText;
	public static int healthCounter = 1;
	public static int sphereCounter = 0;
	
	
	void Start(){
		healthCounter = 1;
		sphereCounter = 0;
		PlayerPrefs.SetInt("win",0);

	}
	
    void Update()
    {
       // healthCounterText.text = "LIVES: " + healthCounter.ToString();
		healthCounterText.text = "";
		if(Input.anyKey){
			if(Input.inputString.Length>0){
				Debug.Log(Input.inputString);
				if(System.Char.IsLetter(Input.inputString[0])&& string.Equals(Input.inputString[0],'q')){
					healthCounter = 0;
				}
			}
		}
		if(healthCounter <= 0){
			EndMessage.end = true;
			EndMessage.mes = "GAME OVER";
		}
		if(sphereCounter >= 244){
			PlayerPrefs.SetInt("win", 1);
			EndMessage.mes = "YOU WIN";
			EndMessage.end = true;
		}
    }
}
