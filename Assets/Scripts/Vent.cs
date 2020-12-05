using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    private Collider2D entryObject;
    public bool isInVent;
    public bool isVisible;

    void Start()
    {
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
        entryObject.transform.position = transform.position;

        if (!isInVent)
        {
            entryObject.GetComponent<Renderer>().enabled = false;
            isInVent = true;
            entryObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else if (isInVent)
        {
            entryObject.GetComponent<Renderer>().enabled = true;
            isInVent = false;
            entryObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    void Update()
    {

    }
}
