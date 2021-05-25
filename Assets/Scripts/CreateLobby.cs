using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateLobby : Button
{
    private string username;
    // Start is called before the first frame update
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        username = transform.parent.Find("InputField").GetComponent<InputField>().text;
        PersonalSettings.Instance.username = username;
        SceneManager.LoadScene("Lobby");
    }
}
