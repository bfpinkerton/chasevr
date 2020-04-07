using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject destination;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.root);

        Transform player = other.transform.root;
        if (player.name == "Player")
        {
            Transform camera = player.GetChild(1).GetChild(0);
            //Debug.Log(player.GetChild(1).GetChild(0));
            player.GetComponent<CharacterController>().enabled = false;
            camera.position = destination.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
        }

        Debug.Log("teleported");
    }
}
