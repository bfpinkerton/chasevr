using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n5 : MonoBehaviour
{
   public TextMesh Name5;
	public string name;
	
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Name5")){
			name = PlayerPrefs.GetString("Name5");
		}
		else{
			PlayerPrefs.SetString("Name5","ABC");
			name = "ABC";
		}
    }

    // Update is called once per frame
    void Update()
    {
		name = PlayerPrefs.GetString("Name5");
        Name5.text = name;
    }
}
