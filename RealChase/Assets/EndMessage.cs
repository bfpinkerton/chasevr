using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMessage : MonoBehaviour
{
	public Text message;
	public static string mes;
	public static bool end;
	
	public int frames;
	
    void Start()
    {
       end = false; 
	   frames = 0;
	   mes = "";
    }

    // Update is called once per frame
    void Update()
    {
        message.text = mes;
		if(end){
			
			frames +=1;
		}
		
		if(frames == 120){
			Debug.Log("ending will frames");
			SceneManager.LoadScene(3);
		}
    }
}
