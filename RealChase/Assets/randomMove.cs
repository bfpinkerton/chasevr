using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class randomMove : MonoBehaviour
{
    NavMeshAgent nav;
    public float timer;
    public int newtarget;
    public float speed;
    public Vector3 target;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //newTarget();
        if(timer >= newtarget){
            //newTarget();
            timer = 0;
        }
    }

    void newTarget(Collider collision){
        //float myX = gameObject.transform.position.x;
        //float myZ = gameObject.transform.position.z;

        Vector3 nodeTarget = collision.GetComponent<NavNodes>().GetNext();

        //float xPos = myX + target.x;
        //float zPos = myZ + target.z;

        target = new Vector3(nodeTarget.x, gameObject.transform.position.y, 
                            nodeTarget.z);

        nav.SetDestination(target);
    }
    
	void OnCollisionEnter(Collision collision){
		if(collision.transform.name == "Player"){
			HealthCounter.healthCounter = HealthCounter.healthCounter - 1;
			Debug.Log("PlayerController.lives.ToString()");
			
		}
	}

    void OnTriggerEnter(Collider collision){
        //if(collision.tag == "NavNode"){
            //Debug.Log(collision.GetComponent<NavNodes>().GetPosition());
            //Debug.Log(transform.position);
        //}
        if(collision.tag == "NavNode"){
            newTarget(collision);
        }
        //target = collision.GetComponent<NavNodes>().GetNext();
        //newTarget();
    }
}
