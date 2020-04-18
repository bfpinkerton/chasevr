using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class finalScore : MonoBehaviour
{
    public TextMesh FinalScoreText;
	public int finalScoreValue;
	
	public bool is_high_score;
    // Start is called before the first frame update
    void Start()
    {
        finalScoreValue = PlayerPrefs.GetInt("active_score");
		if(finalScoreValue > PlayerPrefs.GetInt("score5")){
			is_high_score = true;
		}
		else{
			is_high_score = false;
		}
		Debug.Log(is_high_score);
    }

    // Update is called once per frame
    void Update()
    {
		FinalScoreText.text = finalScoreValue.ToString();
        
    }
}
