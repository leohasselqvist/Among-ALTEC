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
        isInVent = true;
        entryObject.transform.position = transform.position;

        if (isVisible == false)
        {
            entryObject.GetComponent<Renderer>().enabled = false;
            isVisible = true;
        }
        else if (isVisible)
        {
            entryObject.GetComponent<Renderer>().enabled = true;
            isVisible = false;
        }
    }
    void Update()
    {

    }
}
