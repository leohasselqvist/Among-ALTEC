using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject taskPrefab; //pls link me to my task, om inte funkar testa public GameObject taskPrefab = null; 


    void Start()
    {

       
        Debug.Log("Task: Started");
    }

    private void OnTriggerEnter2D(Collider2D other) // om man går nära tasken länka collider
    {
        
        Debug.Log("Task: ENTER from " + other.name);
        
    }

    private void OnTriggerExit2D(Collider2D other) // om man lämnar collidern stängs tasken
    {
        Debug.Log("Task: EXIT");
    }

    // Update is called once per frame
    public void Popup()
    {
        Debug.Log("Task: POPUP!");

        GameObject.Instantiate(taskPrefab);

        Instantiate(taskPrefab, new Vector3(0, 0, -10), Quaternion.identity); //om inte funkar testa transform.position

    }

    void Update()
    {
        
    }
}
