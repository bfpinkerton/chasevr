using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n4 : MonoBehaviour
{
    public TextMesh Name4;
	public string name;
	
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Name4")){
			name = PlayerPrefs.GetString("Name4");
		}
		else{
			PlayerPrefs.SetString("Name4","ABC");
			name = "ABC";
		}
    }

    // Update is called once per frame
    void Update()
    {
        Name4.text = name;
    }
}
