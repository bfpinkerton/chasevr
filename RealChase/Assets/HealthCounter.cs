using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    public Text healthCounterText;
	public static int healthCounter = 3;
	
    void Update()
    {
        healthCounterText.text = "Lives: " + healthCounter.ToString();
    }
}
