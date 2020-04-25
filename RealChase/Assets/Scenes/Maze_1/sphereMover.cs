  
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
    MeshRenderer mesh;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        nav = GetComponent<NavMeshAgent>();
        start = true;
        huntActive = false;

        //Arrays to adjust at what time each personality will chase the player
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
        //Enemies do not start chasing until 5 seconds have passed
        if(timer >= 5 && !huntActive){
            huntActive = true;
        }
    }

    void newTarget(Collider collision){
        //Prevent enemies from hitting the same nav node in back to back frames
        if(prevX == (int)collision.GetComponent<NavNodes>().ownPosition.x && prevZ == (int)collision.GetComponent<NavNodes>().ownPosition.z){
            return;
        }

        bool updateStart;
        //NavNode function that returns the next target
        Vector3 nodeTarget = collision.GetComponent<NavNodes>().GetNext(start, prevX, prevZ, personality, out updateStart, out currX, out currZ);

        //Prevents some outofrange exceptions that were occurring when a nav node is hit in back to back frames
        if(nodeTarget.x == 0 && nodeTarget.y == 0 && nodeTarget.z == 0){
            return;
        }

        //Values updated after a new target is chosen
        start = updateStart;
        prevX = currX;
        prevZ = currZ;

        //Nav nodes and enemies have different global positions but these transformations fix that
        target = new Vector3(nodeTarget.x - 3.0f, gameObject.transform.position.y,
                            nodeTarget.z- 29.3f);
        nav.SetDestination(target);
    }

    void HuntNext(Collider collision){
        if(prevX == (int)collision.GetComponent<NavNodes>().ownPosition.x && prevZ == (int)collision.GetComponent<NavNodes>().ownPosition.z){
            return;
        }

        //Call HuntNext function which returns closest nav node to current player's position
        Vector3 nodeTarget = collision.GetComponent<NavNodes>().HuntNext(prevX, prevZ, personality, out currX, out currZ);
        prevX = currX;
        prevZ = currZ;

        target = new Vector3(nodeTarget.x - 3.0f, gameObject.transform.position.y, nodeTarget.z- 29.3f);

        nav.SetDestination(target);
    }

	void OnCollisionEnter(Collision collision){
        Debug.Log(collision.transform.name);
		if(collision.transform.name == "Player"){
			HealthCounter.healthCounter = HealthCounter.healthCounter - 1;
			Debug.Log("PlayerController.lives.ToString()");

		}
        if(collision.transform.name == "Bullet_45mm_Bullet(Clone)"){
                gameObject.SetActive(false);
                //Destroy(gameObject);
	    }
	}

    void OnTriggerEnter(Collider collision){
        if(collision.tag == "NavNode"){
            //Use modulus to decide when each personality should hunt
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
