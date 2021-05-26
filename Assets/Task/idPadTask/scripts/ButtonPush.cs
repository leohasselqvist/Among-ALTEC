using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ButtonPush : MonoBehaviour
{
    public static event Action<string> ButtonPressed = delegate { };
    private int devider;
    private string buttonName, buttonValue;
    void Start()
    {
        buttonName = gameObject.name;
        devider = buttonName.IndexOf("_");
        buttonValue = buttonName.Substring(0, devider);

        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClickted);
    }

    private void ButtonClickted()
    {
        ButtonPressed(buttonValue);
    }
}
