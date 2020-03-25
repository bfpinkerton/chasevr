using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class live : MonoBehaviour
{
	public Text liveText;
	public static int healthCounter = 3;

    // Update is called once per frame
    void Update()
    {
       liveText.text= Score.gameScore.ToString();
    
    }
}
