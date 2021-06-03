using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyPadTask : MonoBehaviour
{
    public Text _cardCode; //koden på kortet

    public Text _inputCode; //koden som stoppas in

    public GameObject winText; //wintext

    public int _codeLegth = 4; //int på hur lång koden ska vara
    public float _codeResetTimeInSeconds = 0.5f; // tiden efter att den sista knappen är intryckt

    private bool _isResetting = false; //reseting är falskt

    private void OnEnable() //onEneble startas vare gång  gameobjekt enablas
    {
        string code = string.Empty; //ny tom kod

        for (int i = 0; i < _codeLegth; i++) //generera en ny kod
        {
            code += Random.Range(1, 10); //koden kan ha värdet mellan 1, 10
        }

        _cardCode.text = code; //kortet får nu denna kod

        _inputCode.text = string.Empty; //inputkoden är nu tom


    }

    public void ButtonClick(int number) //när knappar trycks
    {
        if (_isResetting) //ifall längden är nådd
        {
            return; //återvänf
        }
        _inputCode.text += number;

        if (_inputCode.text == _cardCode.text) //ifall inputkoden matchar kortkoden
        {
            _inputCode.text = "Correct"; //dispay coorct

                winText.SetActive(true); //wintext
                StartCoroutine(Timer()); //starta timer
            
        }
        else if (_inputCode.text.Length >= _codeLegth) //om inputkodens längd är större än koden eller något helt annat
        {
            _inputCode.text = "Du är sämst"; //display fail
            StartCoroutine(RestCode()); //starta resetcode
        }

    }

    private IEnumerator Timer() // startas när dne kallas
    {
        yield return new WaitForSeconds(2); //vänta
        Destroy(gameObject); //förstör
        Destroy(winText); //förstör
    }

    private IEnumerator RestCode() //startar när kallas
    {
        yield return new WaitForSeconds(_codeResetTimeInSeconds); //vänta enligt coderesettimeinsecods
        _inputCode.text = string.Empty; //töm input
        _isResetting = false; //resting återställs till falskt
    }
}
