using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n2 : MonoBehaviour
{
   public TextMesh Name2;
	public string name;
	
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Name2")){
			name = PlayerPrefs.GetString("Name2");
		}
		else{
			PlayerPrefs.SetString("Name2","ABC");
			name = "ABC";
		}
    }

    // Update is called once per frame
    void Update()
    {
		name = PlayerPrefs.GetString("Name2");
        Name2.text = name;
    }
}