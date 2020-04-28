using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s2 : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMesh Score2;
	public int score;
	
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Score2")){
			score = PlayerPrefs.GetInt("Score2");
		}
		else{
			PlayerPrefs.SetInt("Score2",0);
			score = 0;
		}
    }

    // Update is called once per frame
    void Update()
    {
		score = PlayerPrefs.GetInt("Score2");
        Score2.text = score.ToString();
    }
}