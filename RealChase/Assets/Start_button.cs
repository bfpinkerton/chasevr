﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_button : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
		
    }
	
	void OnCollisionEnter(Collision other){
		Debug.Log(other.transform.name);
		if(other.transform.name == "Player"){
			//change_scene();
			SceneManager.LoadScene(0);
		}
		
	}
	
	//IEnumerator change_scene(){
//		yield return new WaitForSeconds(1);
	//	SceneManager.LoadScene(0);
//	}
}