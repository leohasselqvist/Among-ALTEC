using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    Vector3 startpunkt;
    // Start is called before the first frame update
    void Start()
    {
        startpunkt = transform.parent.position;
    }

    private void OnMouseDrag()
    {
        //musens position
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        //flytta sladden
        transform.position = newPosition;

        //ändra riktning på änden av sladden
        Vector3 plats = newPosition - startpunkt;
        transform.right = plats * transform.lossyScale.x;
    }
}
