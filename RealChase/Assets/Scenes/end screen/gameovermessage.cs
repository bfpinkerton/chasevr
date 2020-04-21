using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameovermessage : MonoBehaviour
{
	public TextMesh message;
    // Start is called before the first frame update
    void Start()
    {
		if (PlayerPrefs.GetInt("win") == 1){
			message.text = "YOU WIN";
			PlayerPrefs.SetInt("win", 0);
	   }
	   else{
		   message.text = "GAME OVER";
	   }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
