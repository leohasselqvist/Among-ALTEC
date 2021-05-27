using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject PÅ;
    public GameObject AV;
    public bool klick;
    public GameObject winText;
    void Start()
    {
        PÅ.SetActive(klick);
            
    }

    private void OnMouseUp()
    {
        klick = !klick;
        PÅ.SetActive(klick);

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
