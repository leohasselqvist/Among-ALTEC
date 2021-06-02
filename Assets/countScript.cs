using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class countScript : MonoBehaviour
{
    public List<Button> button; // lista över buttons
    public List<Button> shuffledButtons; // shufflad lista av busstons
    int counter = 0; //counter över alla tal



    // Start is called before the first frame update
    public void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        counter = 0; //resettar om den fyllts på
        shuffledButtons = button.OrderBy(a => Random.Range(0, 100)).ToList(); // genererar random seeds från 0till 100 för knapparna
        for (int i=1; i<11; i++)
        {
            shuffledButtons[i - 1].GetComponentInChildren<Text>().text = 1.ToString(); // Sätter ett nummer på texten på kanpparna
            shuffledButtons[i - 1].interactable = true; // gör så att alla knappar går att trycka på
            shuffledButtons[i - 1].image.color = new Color32(177, 220, 233, 255); // start färgen
        }
    }

    public void pressButton(Button button) // startar vid klick på knappen
    {
        if (int.Parse(button.GetComponentInChildren<Text>().text) - 1 == counter) // checkar så att den knapp som trycks -1 är lika med cuntern. så att den trycks i rätt årdning
        {
            counter++; //plusar på 1 
            button.interactable = false; // disablar kanppen
            button.image.color = Color.green; // sätter knappen till grön
            if(counter == 10) //ifall alla knappar är tryckta
            {
                StartCoroutine(presentResult(true)); // pressent reslut från om man klarr adet
            }
        }
        else
        {
            StartCoroutine(presentResult(false)); // ifall det inte gick igenom startar present result för förlorat
        }
    }

    public IEnumerator presentResult(bool win)
    {
        if (!win) //lost
        {
            foreach(var button in shuffledButtons)
            {
                button.image.color = Color.red // ändar till röd färg
                button.interactable = false; // dissablar alla knappar
            }
        }
        yield return new WaitForSeconds(2f);
        StartGame();
    }
}
