using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;

public class Instructions_button : MonoBehaviour
{
	void Start(){
		
	}
    void Update()
    {		
		if(Input.anyKey){
			if(Input.inputString.Length>0){
				Debug.Log(Input.inputString);
				if(System.Char.IsLetter(Input.inputString[0])&& string.Equals(Input.inputString[0],'i')){
					SceneManager.LoadScene(2);
				}
			}
		}
    }
	
//	void OnCollisionEnter(Collision collision){
//
	//	if((collision.transform.name == "Player")||(collision.transform.name == "HeadCollider")||
      //  (collision.transform.name == "HandColliderLeft(Clone)")||(collision.transform.name == "HandColliderRight(Clone)")){
		//	//end = true;
		//	_instance.trackingOriginTransform.position = StartPosition;
		//	SceneManager.LoadScene(2);
		//}
		
	//}
}
