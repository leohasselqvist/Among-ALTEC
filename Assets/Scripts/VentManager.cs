using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentManager : MonoBehaviour
{
    private List<GameObject> connectedVents = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Vent child in transform)
		{
            connectedVents.Add(child.gameObject);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
