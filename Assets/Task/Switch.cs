using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject up; // kopplas till prefaben av nakppen uppot
    public GameObject on; // kopplas till prefaben av lampan på
    public bool isOn; // Boolen som kontrolerar lampan
    public bool isUp; // Boolen som kontrolerar kanppen
    // Start is called before the first frame update
    void Start()
    {
        on.SetActive(isOn); //för att senare kunna ge olika kanppar ett upp elkler ner värde
        up.SetActive(isUp); //same

        if (isOn) // ifall lamporna är igång
        {
            Main.Instance.SwitchChange(1); // räkna switchen som är igång, och kallar på Main variablen Instance SwitchChange
        }
    }
    private void OnMouseUp() //triggar när musen rör collidern
    {
        isUp = !isUp; //för att invertera så att om den är false blir den true
        isOn = !isOn; //same

        on.SetActive(isOn); //om ison triggas så sätts on aktit
        up.SetActive(isUp); //same

        if (isOn) // om lamporna är på
        {
            Main.Instance.SwitchChange(1); // plussar på ett om den är igång
        }
        else
        {
            Main.Instance.SwitchChange(-1); // subtaherar 1 om den är av
        }
    }
}
