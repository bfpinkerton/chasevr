using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s3 : MonoBehaviour
{
   public TextMesh Score3;
	public int score;
	
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Score3")){
			score = PlayerPrefs.GetInt("Score3");
		}
		else{
			PlayerPrefs.SetInt("Score3",0);
			score = 0;
		}
    }

    // Update is called once per frame
    void Update()
    {
		score = PlayerPrefs.GetInt("Score3");
        Score3.text = score.ToString();
    }
}
