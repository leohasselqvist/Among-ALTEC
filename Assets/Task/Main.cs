using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    static public Main Instance; // för att switches script ska kunna andvända metoden SwitchChange

    public int switchCount; //int för hur många switches som är på
    public GameObject winText; //kopplas till wintext prefaben
    private int onCount = 0; //räknar det tilfälliga mängden switches, privet då inspectorn inte bvehöver den
    
    

    private void Awake() // för att sätta värdet på variablen Instance
    {
        Instance = this; // this refererar till classen Main som kopplas till bg gameobjektet
    }
    public void SwitchChange(int points) //triggar om någon kanpps status ändras
    {
        onCount = onCount + points; // för switch upp plussas det på 1
        

        if (onCount == switchCount) // om oncount är lika med mängden switches 
        {
            winText.SetActive(true); // aktiverar win
            StartCoroutine(Timer()); // startar Timer
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(2); // vänta 2 secunder
        Destroy(gameObject); //förstör gameobjekt
        Destroy(winText); //same
    }
    

}
