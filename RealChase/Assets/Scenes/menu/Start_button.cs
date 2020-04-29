using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_button : MonoBehaviour
{
	public bool end;
	public int frames;
    
	void Start(){
		end = false;
		frames = 0;
	}
    void Update()
    {
		if(Input.anyKey){
			if(Input.inputString.Length>0){
				Debug.Log(Input.inputString);
				if(System.Char.IsLetter(Input.inputString[0])&& string.Equals(Input.inputString[0],'s')){
					SceneManager.LoadScene(1);
				}
			}
		}
		if(Input.anyKey){
			if(Input.inputString.Length>0){
				Debug.Log(Input.inputString);
				if(System.Char.IsLetter(Input.inputString[0])&& string.Equals(Input.inputString[0],'r')){
					PlayerPrefs.SetInt("Score1",0);
					PlayerPrefs.SetInt("Score2",0);
					PlayerPrefs.SetInt("Score3",0);
					PlayerPrefs.SetInt("Score4",0);
					PlayerPrefs.SetInt("Score5",0);
					
					PlayerPrefs.SetString("Name1","ABC");
					PlayerPrefs.SetString("Name2","ABC");
					PlayerPrefs.SetString("Name3","ABC");
					PlayerPrefs.SetString("Name4","ABC");
					PlayerPrefs.SetString("Name5","ABC");
				}
			}
		}
    }
	
	void OnCollisionEnter(Collision collision){

		if((collision.transform.name == "Player")||(collision.transform.name == "HeadCollider")||
        (collision.transform.name == "HandColliderLeft(Clone)")||(collision.transform.name == "HandColliderRight(Clone)")){
			end = true;
		}
		
	}
}