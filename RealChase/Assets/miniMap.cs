using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMap : MonoBehaviour
{
    public Camera MapCamera;

    void Start()
    {
        MapCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            MapCamera.enabled = !MapCamera.enabled;
        }
    }
}
