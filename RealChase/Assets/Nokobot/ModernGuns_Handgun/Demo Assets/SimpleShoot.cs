﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SimpleShoot : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAction;
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;

    private Interactable interactable;
    public float shotPower = 100f;
    public int bulletNumber = 3;
    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        interactable = GetComponent<Interactable>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<Animator>().SetTrigger("Fire");
        }

        if(interactable.attachedToHand != null){
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;

            if(fireAction[source].stateDown && bulletNumber > 0){
                GetComponent<Animator>().SetTrigger("Fire");
                bulletNumber--;
            }
        }
    }

    void Shoot()
    {
        //  GameObject bullet;
        //  bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        // bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

        GameObject tempFlash;
       Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
       tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

       // Destroy(tempFlash, 0.5f);
        //  Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);
       
    }

    void CasingRelease()
    {
         GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }


}
