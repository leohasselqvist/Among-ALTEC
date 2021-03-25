using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentManager : MonoBehaviour
{
    List<GameObject> Arrows = new List<GameObject>();

    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "VentArrow")
            {
                child.GetComponent<SpriteRenderer>().enabled = false;

                Arrows.Add(child.gameObject);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showArrows(bool shown) 
    {
        foreach (GameObject arrow in Arrows) 
        {
            arrow.GetComponent<SpriteRenderer>().enabled = shown;
        }
    }
}
