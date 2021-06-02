using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject PÅ; //gameobjekt av kanppen uppe
    public GameObject AV; // gameobjekt av kanppen nere
    public bool klick; // bool
    public GameObject winText; // wintexten
    void Start()
    {
        PÅ.SetActive(klick); // startar med uppe läget av funktionen klick
            
    }

    private void OnMouseUp() // OnMouseUp startar om musen klickar innanför colidern
    {
        klick = !klick; // om kilcik inet är lika med klick
        PÅ.SetActive(klick); // sätt klick till

        StartCoroutine(Timer());
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.2F);
        Destroy(PÅ);
        winText.SetActive(true);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        Destroy(winText);
    }
}
