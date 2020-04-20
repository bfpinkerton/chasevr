using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s5 : MonoBehaviour
{
	public TextMesh Score5;
	public int score;
	
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Score5")){
			score = PlayerPrefs.GetInt("Score5");
		}
		else{
			PlayerPrefs.SetInt("Score5",0);
			score = 0;
		}
    }

    // Update is called once per frame
    void Update()
    {
        Score5.text = score.ToString();
    }
}
