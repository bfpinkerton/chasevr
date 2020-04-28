using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public SteamVR_Action_Vector2 input;
    public float speed = 1;
    private CharacterController characterController;
    public static Vector3 PlayerPosition;
	public static Vector3 StartPosition;
	GameObject PlayerObj;
	public GameObject destination;
	public bool hit;
	public int counter;
	public float timer;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
		StartPosition = Player.instance.trackingOriginTransform.position;
		Debug.Log(StartPosition);
		PlayerPrefs.SetInt("reset",0);
		counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;
		Vector3 direction;
		if(PlayerPrefs.GetInt("reset") == 1&&counter > 0){
			Debug.Log("reset" + counter);
			Player.instance.trackingOriginTransform.position = StartPosition;
			counter = counter - 1;
			if (counter == 0){
				PlayerPrefs.SetInt("reset",0);
			}
		}
		
		else{
			direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
        
			transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(direction,Vector3.up);
			characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction,Vector3.up)-new Vector3(0,9.81f,0)*Time.deltaTime);
			PlayerPosition = transform.position;
		}
    }
	void OnTriggerEnter(Collider other){
		//Debug.Log(other.tag);
		if((other.tag == "Enemy") &&  (PlayerPrefs.GetInt("reset") == 0) && (timer>3)){
			PlayerPrefs.SetInt("reset",1);
			HealthCounter.healthCounter = HealthCounter.healthCounter - 1;
			counter = 5;
			timer = 0;
		}
	}
	
	void OnCollisionEnter(Collision collision){	
	}

}
