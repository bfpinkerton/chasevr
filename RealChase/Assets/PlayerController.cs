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
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
		StartPosition = transform.position;
		Debug.Log(StartPosition);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
        //transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(direction,Vector3.up);
        characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction,Vector3.up));
        PlayerPosition = transform.position;
    }
	void OnTriggerEnter(Collider other){
		//Debug.Log(other.tag);
		if(other.tag == "Enemy"){
			HealthCounter.healthCounter = HealthCounter.healthCounter - 1;
			
		}
	}
	void OnCollisionEnter(Collision collision){	
	}

}
