using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    public Collider2D entryObject;
    public bool isInVent;

    //[SerializeField]
    //private List<Vent> connectedVents;

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

        //Put player position to vent position
        entryObject.transform.position = transform.position;

        //Check if player is going into vent or out of vent
        if (!isInVent)
        {
            //Freeze the player position
            entryObject.GetComponent<Renderer>().enabled = false;
            isInVent = true;
            entryObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
            showArrows(true);
        }
        else if (isInVent)
        {
            //Unfreeze the player position
            entryObject.GetComponent<Renderer>().enabled = true;
            isInVent = false;
            entryObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            showArrows(false);
        }
    }

    public void showArrows(bool shown) 
    {
        transform.parent.GetComponent<VentManager>().showArrows(shown);
    }
    void Update()
    {

    }
}
