using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pellet_behavior : MonoBehaviour
{
	private bool hit;
    // Start is called before the first frame update
    void Start()
    {
		hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision collision){
   
		if((collision.transform.name == "Player")||(collision.transform.name == "HeadCollider")||
			(collision.transform.name == "HandColliderLeft(Clone)")||(collision.transform.name == "HandColliderRight(Clone)")){
			if(!hit){
			hit = true;
			Destroy(gameObject);
			Debug.Log("Sphere hit");
			Score.gameScore +=10;
			HealthCounter.sphereCounter +=1;
			}
		}
		if(collision.transform.name == "Bullet_45mm_Bullet(Clone)"){
			if(!hit){
				hit = true;
				Destroy(gameObject);
				HealthCounter.sphereCounter +=1;
			}
		}
	}

}
