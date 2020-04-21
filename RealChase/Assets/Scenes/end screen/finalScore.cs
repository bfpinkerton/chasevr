using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class finalScore : MonoBehaviour
{
	public int finalScoreValue;
    public TextMesh FinalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        finalScoreValue = PlayerPrefs.GetInt("active_score");
    }

    // Update is called once per frame
    void Update()
    {
		FinalScoreText.text = finalScoreValue.ToString();
    }
	
	
}
