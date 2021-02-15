using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentManager : MonoBehaviour
{

    Transform[] allChildren = GetComponentsInChildren<Transform>();
    List<GameObject> childObjects = new List<GameObject>();

    void Start()
    {
        foreach (Transform child in allChildren)
        {
            childObjects.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void showArrows() 
    { 
        
    }
}
