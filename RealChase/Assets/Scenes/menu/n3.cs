using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n3 : MonoBehaviour
{
    public TextMesh Name3;
	public string name;
	
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Name3")){
			name = PlayerPrefs.GetString("Name3");
		}
		else{
			PlayerPrefs.SetString("Name3","ABC");
			name = "ABC";
		}
    }

    // Update is called once per frame
    void Update()
    {
		name = PlayerPrefs.GetString("Name3");
        Name3.text = name;
    }
}
