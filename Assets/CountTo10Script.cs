using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTo10Script : MonoBehaviour
{

    [SerializeField] int nextButton; //kollar vilken knapp som ska klickas
    [SerializeField] GameObject[] myObjects; // arrey av gameobjekts knapparna

    public GameObject winText; //wintext

    // Start is called before the first frame update
    void Start()
    {
        nextButton = 0; //börjar från element 0
    }

    private void OnEnable() //startar varje gång någon förändring av gameobjektet sker
    {
        nextButton = 0; //börjar från element 0
        for (int i = 0; i < myObjects.Length; i++) //tar första elementet plussa sedan på 1
        {
            myObjects[i].transform.SetSiblingIndex(Random.Range(0, 9)); //flyttar sedan elemntets heralki från ett radom värde 0 till 9
        }
    }

    public void ButtonOrder(int button)
    {
        if (button == nextButton) //ifall knappens värde är lika med nextbutton som förtst är 0
        {
            nextButton++; //plussa på 1 för att fortsätta bygga upp
            
        }
        else
        {
            nextButton = 0; //nollställer nextbutton
            OnEnable(); //startar OnEneble
        }

        if(button == 9) //när alla element blir 9
        {
            winText.SetActive(true); //wintext
            StartCoroutine(Timer()); //starta timer
        }
    }

    private IEnumerator Timer() // startas när dne kallas
    {
        yield return new WaitForSeconds(2); //vänta
        Destroy(gameObject); //förstör
        Destroy(winText); //förstör
    }
}
