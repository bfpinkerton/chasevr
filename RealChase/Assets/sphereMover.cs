using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class sphereMover : MonoBehaviour
{
    NavMeshAgent nav;
    //public float timer;
    //public int newtarget;
    //public float speed;
    public Vector3 target;
    public int prevX;
    public int prevZ;
    bool start;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        //if(timer >= newtarget){
            //timer = 0;
        //}
    }

    void newTarget(Collider collision){
        bool updateStart;
        int currX, currZ;
        Vector3 nodeTarget = collision.GetComponent<NavNodes>().GetNext(start, prevX, prevZ, out updateStart, out currX, out currZ);
        start = updateStart;
        prevX = currX;
        prevZ = currZ;

        target = new Vector3(nodeTarget.x - 3.0f, gameObject.transform.position.y, 
                            nodeTarget.z- 29.3f);

        nav.SetDestination(target);
    }
    
	void OnCollisionEnter(Collision collision){
		if(collision.transform.name == "Player"){
			HealthCounter.healthCounter = HealthCounter.healthCounter - 1;
			Debug.Log("PlayerController.lives.ToString()");
			
		}
	}

    void OnTriggerEnter(Collider collision){
        if(collision.tag == "NavNode"){
            newTarget(collision);
        }
        if(collision.tag == "HandColliderRight(Clone)"){
			HealthCounter.healthCounter = HealthCounter.healthCounter - 1;
			
			
		}
    }
}
