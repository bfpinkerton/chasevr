using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMap : MonoBehaviour
{
    public Camera MapCamera;
    public GameObject player;
    private GameObject movement;

    void Start()
    {
        MapCamera.enabled = false;
        movement = player.transform.GetChild(0).gameObject;
        if (!movement.activeSelf)
            movement = player.transform.GetChild(1).gameObject;
        Debug.Log(movement);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            MapCamera.enabled = !MapCamera.enabled;
            movement.SetActive(!movement.activeSelf);
            //player.transform.GetComponent<CharacterController>().enabled = false;
        }
    }
}
