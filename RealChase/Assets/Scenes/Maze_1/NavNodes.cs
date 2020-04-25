using System.Collections;
using System.Collections.Generic;
using System;
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
    {

    }

    public Vector3 GetNext(bool start, int prevX, int prevZ, int enemyPerson, out bool update, out int currX, out int currZ){
        currX = (int)ownPosition.x;
        currZ = (int)ownPosition.z;

        if(!start){
            update = false;
            int total = 0;
            // Build a target options array while excluding previous nav node
            NavNodes[] options = new NavNodes[neighbors.Length-1];
            int[] opts = new int[options.Length];

            int j = 0;
            for(int i = 0; i < neighbors.Length; i++){
                //Exclude the nav node the neemy just came from
                if((int)neighbors[i].ownPosition.x != prevX || (int)neighbors[i].ownPosition.z != prevZ){
                    if(j >= neighbors.Length - 1){
                        //Sometimes the enemy hits a nav node multiple times in back to back frames and outofrange exceptions occurred
                        Vector3 triggered = new Vector3(0,0,0);
                        return triggered;
                    }
                    //Call personality function to see what the weighting for this option is
                    total += personality(enemyPerson, neighbors[i], currX, currZ);
                    opts[j] = total;
                    options[j] = neighbors[i];
                    j += 1;
                }
            }
            
            //Pick a random next neighbor while taking into account the personality weighting
            System.Random rndo = new System.Random();
            int nextIndexI = rndo.Next(0,total);
             for(int i = 0; i < opts.Length; i++){
                if(opts[i] > nextIndexI){
                    return options[i].ownPosition;
                }
            }
            return options[0].ownPosition;
        }
        update = false;

        //Pick a random next neighbor without preference weighting
        System.Random rnd = new System.Random();
        int nextIndex = rnd.Next(0,neighbors.Length);
        return neighbors[nextIndex].ownPosition;
    }

    public Vector3 HuntNext(int prevX, int prevZ, int personality, out int currX, out int currZ){
        //Get the next position that gets you closest to the player
        currX = (int)ownPosition.x;
        currZ = (int)ownPosition.z;
        return Euclidean((int)PlayerController.PlayerPosition.x + 3, (int)PlayerController.PlayerPosition.z + 30, prevX, prevZ);
    }

    public int personality(int enemy, NavNodes neighbor, int currX, int currZ){
        int total = 0;
        //Each personality prefers a different corner to patrol
        // 0 prefers top right, 1 prefers top left, 2 prefers bottome left, 3 prefers bottom right
        switch(enemy){
            case 0:
                if((int)neighbor.ownPosition.x > currX || (int)neighbor.ownPosition.z > currZ){
                    total += 20;
                }
                else{
                    total += 2;
                }
            break;
            case 1:
                if((int)neighbor.ownPosition.x < currX || (int)neighbor.ownPosition.z > currZ){
                    total += 20;
                }
                else{
                    total += 2;
                }
            break;
            case 2:
            if((int)neighbor.ownPosition.x < currX || (int)neighbor.ownPosition.z < currZ){
                    total += 20;
                }
                else{
                    total += 2;
                }
            break;
            case 3:
            if((int)neighbor.ownPosition.x > currX || (int)neighbor.ownPosition.z < currZ){
                    total += 20;
                }
                else{
                    total += 2;
                }
            break;
            default:
            break;
        }
        return total;
    }

    Vector3 Euclidean(int playerX, int playerZ, int prevX, int prevZ){

        double min = 1000000000;
        int minindex = 0;
        // Go through the neighbors of the current nav node and choose the one that gets you closest to the player
        for(int i = 0; i < neighbors.Length; i++){
            if(prevX != (int)neighbors[i].ownPosition.x || prevZ != (int)neighbors[i].ownPosition.z){
                double eucl = CalcEuclidean(playerX, playerZ, (int)neighbors[i].ownPosition.x, (int)neighbors[i].ownPosition.z);
                if(eucl < min){
                    min = eucl;
                    minindex = i;
                }
            }
        }
        return neighbors[minindex].ownPosition;
    }

    double CalcEuclidean(int x1, int z1, int x2, int z2){
        return Math.Sqrt(Math.Pow((x1 - x2),2) + Math.Pow((z1 - z2),2));
    }

    void OnTriggerEnter(Collider collision){
        //Debug.Log(collision.tag);
    }
}