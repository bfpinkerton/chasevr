using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s4 : MonoBehaviour
{
    public TextMesh Score4;
	public int score;
	
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Score4")){
			score = PlayerPrefs.GetInt("Score4");
		}
		else{
			PlayerPrefs.SetInt("Score4",0);
			score = 0;
		}
    }

    // Update is called once per frame
    void Update()
    {
        Score4.text = score.ToString();
    }
}
