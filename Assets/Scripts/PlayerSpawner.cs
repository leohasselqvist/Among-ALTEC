using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {   
        GameManager.Instance.selfPlayer = Instantiate(GameManager.Instance.playerTemplate, GameManager.Instance.transform);  // spawna in spelaren i lobby:n och spara den i en variabel
        GameManager.Instance.playerList.Add(GameManager.Instance.selfPlayer);  // lägg till spelaren till en lista
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
