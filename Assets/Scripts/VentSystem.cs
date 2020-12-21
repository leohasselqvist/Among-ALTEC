using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentSystem : MonoBehaviour
{
    [SerializeField] List<Vent> connectedVents;

    int CurrentVentID;

    private void SetupVent()
    {
        int index = 0;
        foreach (Vent vent in connectedVents)
        {
            vent.ID = index;
            vent.ventSystem = this;
            index++;
        }
    }

    public void CanEnterVentSystem(int Vent)
    {
        CurrentVentID = Vent;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
