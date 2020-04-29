using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class Teleport : MonoBehaviour
{
    public GameObject destination;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.root);

        Transform player = other.transform.root;
        if (player.name == "Player")
        {
			Player _instance = FindObjectOfType<Player>();
            player.GetComponent<CharacterController>().enabled = false;
			_instance.trackingOriginTransform.position = destination.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
        }

        Debug.Log("teleported");
    }
}
