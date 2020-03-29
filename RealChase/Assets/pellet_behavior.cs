using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pellet_behavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision collision){
	if(collision.transform.name == "Player"){
		Destroy(gameObject);
		//Debug.Log("Sphere hit");
		Score.gameScore +=10;
	}
}

}
