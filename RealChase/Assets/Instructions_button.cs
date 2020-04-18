using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class Instructions_button : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision other){
		Debug.Log(other.transform.name);
		if(other.transform.name == "Player"){
			SceneManager.LoadScene(2);
		}
		
	}
}
