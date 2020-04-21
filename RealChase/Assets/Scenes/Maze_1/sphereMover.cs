  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class sphereMover : MonoBehaviour
{
    NavMeshAgent nav;
    public Vector3 target;
    public int prevX;
    public int prevZ;
    public int currX;
    public int currZ;
    public int personality;
    int[] timers;
    int[] lowtimers;
    bool start;
    bool huntActive;
    public float timer;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        start = true;
        huntActive = false;
        timers = new int[]{10,20,30,40};
        lowtimers = new int[timers.Length];
        lowtimers[0] = 0;
        for(int i = 0; i < timers.Length-1; i++){
            lowtimers[i+1] = timers[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 5 && !huntActive){
            huntActive = true;
        }
    }

    void newTarget(Collider collision){
        if(prevX == (int)collision.GetComponent<NavNodes>().ownPosition.x && prevZ == (int)collision.GetComponent<NavNodes>().ownPosition.z){
            return;
        }
        bool updateStart;
        Vector3 nodeTarget = collision.GetComponent<NavNodes>().GetNext(start, prevX, prevZ, personality, out updateStart, out currX, out currZ);
        if(nodeTarget.x == 0 && nodeTarget.y == 0 && nodeTarget.z == 0){
            return;
        }
        start = updateStart;
        prevX = currX;
        prevZ = currZ;

        target = new Vector3(nodeTarget.x - 3.0f, gameObject.transform.position.y,
                            nodeTarget.z- 29.3f);

        nav.SetDestination(target);
    }

    void HuntNext(Collider collision){
        if(prevX == (int)collision.GetComponent<NavNodes>().ownPosition.x && prevZ == (int)collision.GetComponent<NavNodes>().ownPosition.z){
            return;
        }

        bool hunt = false;
        if(personality % 2 == 0){
            hunt = true;
        }

        Vector3 nodeTarget = collision.GetComponent<NavNodes>().HuntNext(prevX, prevZ, personality, hunt, out currX, out currZ);
        prevX = currX;
        prevZ = currZ;

        target = new Vector3(nodeTarget.x - 3.0f, gameObject.transform.position.y, nodeTarget.z- 29.3f);

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
            int currTime = (int)timer % timers[timers.Length-1];
            if(currTime >= lowtimers[personality] && currTime <= timers[personality] && huntActive){
                HuntNext(collision);
            }
            else{
                newTarget(collision);
            }
        }
    }
}
