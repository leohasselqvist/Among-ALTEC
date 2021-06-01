using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyPadTask : MonoBehaviour
{
    public Text _cardCode;

    public Text _inputCode;

    public GameObject winText;

    public int _codeLegth = 4;
    public float _codeResetTimeInSeconds = 0.5f;

    private bool _isResetting = false;

    private void OnEnable()
    {
        string code = string.Empty;

        for (int i = 0; i < _codeLegth; i++)
        {
            code += Random.Range(1, 10); 
        }

        _cardCode.text = code;

        _inputCode.text = string.Empty;


    }

    public void ButtonClick(int number)
    {
        if (_isResetting)
        {
            return;
        }
        _inputCode.text += number;

        if (_inputCode.text == _cardCode.text)
        {
            _inputCode.text = "Correct";

                winText.SetActive(true);
                StartCoroutine(Timer());
            
        }
        else if (_inputCode.text.Length >= _codeLegth)
        {
            _inputCode.text = "Du är sämst";
            StartCoroutine(RestCode());
        }

    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        Destroy(winText);
    }

    private IEnumerator RestCode()
    {
        yield return new WaitForSeconds(_codeResetTimeInSeconds);
        _inputCode.text = string.Empty;
        _isResetting = false;
    }
}
