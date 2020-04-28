using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;

public class Instructions_button : MonoBehaviour
{
	public bool end;
	public int frames;
    public static Vector3 StartPosition;
	Player _instance;
	void Start(){
		end = false;
		frames = 0;
		_instance = FindObjectOfType<Player>();
		StartPosition = _instance.trackingOriginTransform.position;
	}
    void Update()
    {
		if(end){
			frames +=1;
		}
		
		if(frames == 60){
			SceneManager.LoadScene(2);
		}
    }
	
	void OnCollisionEnter(Collision collision){

		if((collision.transform.name == "Player")||(collision.transform.name == "HeadCollider")||
        (collision.transform.name == "HandColliderLeft(Clone)")||(collision.transform.name == "HandColliderRight(Clone)")){
			//end = true;
			_instance.trackingOriginTransform.position = StartPosition;
			SceneManager.LoadScene(2);
		}
		
	}
}
