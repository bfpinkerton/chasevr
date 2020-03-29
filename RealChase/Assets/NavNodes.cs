using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavNodes : MonoBehaviour
{
    public NavNodes[] neighbors;
    public Vector3 ownPosition;
    // Start is called before the first frame update
    void Start()
    {
        ownPosition = new Vector3(Mathf.Round((float)transform.position.x + 2.57f),
                                transform.position.y,
                                Mathf.Round((float)transform.position.z +29.4f));
    }

    // Update is called once per frame
    void Update()
    {}

    public Vector3 GetDirection(NavNodes next){
        int x = 0;
        if(ownPosition.x > next.ownPosition.x){
            x = -1;
        }
        else if(ownPosition.x < next.ownPosition.x){
            x = 1;
        }
        int z = 0;
        if(ownPosition.z > next.ownPosition.z){
            z = -1;
        }
        else if(ownPosition.z < next.ownPosition.z){
            z = 1;
        }
        Vector3 direction = new Vector3(x, 0, z);
        return direction;
    }

    public Vector3 GetNext(){
        System.Random rnd = new System.Random();
        int nextIndex = rnd.Next(0,neighbors.Length);
        return neighbors[nextIndex].ownPosition;
    }

    void OnTriggerEnter(Collider collision){
        //Debug.Log(collision.tag);
    }
}
