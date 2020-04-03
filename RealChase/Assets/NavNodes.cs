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

    public Vector3 GetNext(bool start, int prevX, int prevZ, out bool update, out int currX, out int currZ){
        currX = (int)ownPosition.x;
        currZ = (int)ownPosition.z;
        if(!start){
            NavNodes[] options = new NavNodes[neighbors.Length-1];
            int j = 0;
            for(int i = 0; i < neighbors.Length; i++){
                if((int)neighbors[i].ownPosition.x != prevX || (int)neighbors[i].ownPosition.z != prevZ){
                    options[j] = neighbors[i];
                    j += 1;
                }
            }
            
            update = false;
            System.Random rndo = new System.Random();
            int nextIndexI = rndo.Next(0,options.Length);
            return options[nextIndexI].ownPosition;
        }

        update = false;
        System.Random rnd = new System.Random();
        int nextIndex = rnd.Next(0,neighbors.Length);
        return neighbors[nextIndex].ownPosition;
    }

    void OnTriggerEnter(Collider collision){
        //Debug.Log(collision.tag);
    }
}
