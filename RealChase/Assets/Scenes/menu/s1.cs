using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s1 : MonoBehaviour
{
	public TextMesh Score1;
	public int score;
	
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Score1")){
			score = PlayerPrefs.GetInt("Score1");
		}
		else{
			PlayerPrefs.SetInt("Score1",0);
			score = 0;
		}
    }

    // Update is called once per frame
    void Update()
    {
		score = PlayerPrefs.GetInt("Score1");
        Score1.text = score.ToString();
    }
}
