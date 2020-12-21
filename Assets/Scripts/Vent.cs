﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    private Collider2D entryObject;
    public bool isInVent;
    public int ID;
    public VentSystem ventSystem;

    Animator VentAnimator;

    void Start()
    {
        VentAnimator = gameObject.GetComponent<Animator>();
        Debug.Log("Task: Started");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Task: ENTER from " + other.name);
        entryObject = other;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Task: EXIT");
        entryObject = null;
    }

    // Update is called once per frame
    public void Popup()
    {
        Debug.Log("Task: POPUP!");

        //Put player position to vent position
        entryObject.transform.position = transform.position;

        //Check if player is going into vent or out of vent
        if (!isInVent)
        {

            ventSystem.CanEnterVentSystem(ID);

            //Freeze the player position
            entryObject.GetComponent<Renderer>().enabled = false;
            isInVent = true;
            entryObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

            VentAnimator.SetTrigger("Vent_Animation");
        }
        else if (isInVent)
        {
            //Unfreeze the player position
            entryObject.GetComponent<Renderer>().enabled = true;
            isInVent = false;
            entryObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            VentAnimator.SetTrigger("Vent_Animation");
        }
    }
    void Update()
    {

    }
}
