using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
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
				if(System.Char.IsLetter(Input.inputString[0])&& string.Equals(Input.inputString[0],'b')){
					SceneManager.LoadScene(1);
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