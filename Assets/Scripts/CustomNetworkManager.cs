using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    // Start is called before the first frame update
    public override void OnStartServer()
    {
        //GameManager.Instance.selfPlayer = Instantiate(GameManager.Instance.playerTemplate);  // spawna in spelaren i lobby:n och spara den i en variabel
        //GameManager.Instance.playerList.Add(GameManager.Instance.selfPlayer);  // lägg till spelaren till en lista
    }

    // Update is called once per frame
    public override void OnStopServer()
    {
        Debug.Log("Server stopped!");
    }
    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log("Client connected");
    }
    public override void OnClientDisconnect(NetworkConnection conn)
    {
        Debug.Log("Client disconnected");
    }
}
