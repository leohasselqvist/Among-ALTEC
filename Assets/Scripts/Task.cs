using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject taskPrefab; //pls link me to my task, om inte funkar testa public GameObject taskPrefab = null; 
    bool doingtask;

    private Collider2D entryObject;

    void Start()
    {

       
        Debug.Log("Task: Started");
    }

    private void OnTriggerEnter2D(Collider2D other) // om man går nära tasken länka collider
    {
        
        Debug.Log("Task: ENTER from " + other.name);

        entryObject = other;

        
    }

    private void OnTriggerExit2D(Collider2D other) // om man lämnar collidern stängs tasken
    {
        Debug.Log("Task: EXIT");
        entryObject = null;
    }

    // Update is called once per frame
    public void Popup()
    {
        Debug.Log("Task: POPUP!");

        Instantiate(taskPrefab, Vector3.zero, Quaternion.identity); // för att spana in på specefik plats new Vector3.(-10,0,0)

        //Check if player is doing task or not
        if (!doingtask)
        {
            //Freeze the player position
            
            doingtask = true;
            entryObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else if (doingtask)
        {
            //Unfreeze the player position
            
            doingtask = false;
            entryObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        //GameObject.Instantiate(taskPrefab);


        

    }

    void Update()
    {
        
    }
}
