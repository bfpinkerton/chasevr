using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n1 : MonoBehaviour
{
    public TextMesh Name1;
	public string name;
	
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Name1")){
			name = PlayerPrefs.GetString("Name1");
		}
		else{
			PlayerPrefs.SetString("Name1","ABC");
			name = "ABC";
		}
    }

    // Update is called once per frame
    void Update()
    {
		name = PlayerPrefs.GetString("Name1");
        Name1.text = name;
    }
}
