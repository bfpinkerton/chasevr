using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class name_entry : MonoBehaviour
{
	public TextMesh Name;
	public string entry = "---";
	public string blank = "---";
	public int limit = 0;
    // Start is called before the first frame update
    void Start()
    {
        Name.text = "---";
    }

    // Update is called once per frame
    void Update()
    {
		Name.text = entry.ToUpper();
		if(Input.anyKey){
			if(Input.inputString.Length>0){
				Debug.Log(Input.inputString);
				if(System.Char.IsLetter(Input.inputString[0]) && limit <3){
					Debug.Log(limit.ToString());
					if(limit == 0){
						entry = Input.inputString[0] + entry.Substring(1);
						limit = limit + 1;
					}
					else if (limit == 1){
						entry = entry[0] + Input.inputString + entry[2];
						limit = limit + 1;
					}
					else if(limit == 2){
						entry = entry.Substring(0,2)+Input.inputString.Substring(0,1);
						
						limit = limit + 1;
					}
				}
				else if(string.Equals(Input.inputString[0],'\b') && limit>0){
					entry = entry.Substring(0,limit-1) + blank.Substring(limit-1);
					limit = limit - 1;
				}
				
			}
		}
		PlayerPrefs.SetString("entry", entry.ToUpper());
    }
	
	
}

