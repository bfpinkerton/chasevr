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
    Debug.Log(collision.transform.name);
	/*if(collision.transform.name == "HandColliderRight(Clone)"){
		Destroy(gameObject);
		Debug.Log("Sphere hit");
		Score.gameScore +=10;
	}*/

    if((collision.transform.name == "Player")||(collision.transform.name == "HeadCollider")||
        (collision.transform.name == "HandColliderLeft(Clone)")||(collision.transform.name == "HandColliderRight(Clone)")
    ){
		Destroy(gameObject);
		Debug.Log("Sphere hit");
		Score.gameScore +=10;
	}

    if(collision.transform.name == "Bullet_45mm_Bullet(Clone)"){
        Destroy(gameObject);
    }
}

}
