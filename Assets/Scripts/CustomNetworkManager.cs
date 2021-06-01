using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    public static CustomNetworkManager Instance;
    public GameObject joinHUD;

    public List<GameObject> playerList = new List<GameObject>();

    // Start is called before the first frame update
    public override void OnStartServer()
    {
        Debug.Log("server started");
        Instantiate(joinHUD, new Vector3(0, 0, 0), Quaternion.identity);  // Spawna in HUD
    }


    // Update is called once per frame
    public override void Awake()
    {
        Instance = this;
    }
    public override void OnStopServer()
    {
        Debug.Log("Server stopped!");
    }
    public override void OnClientConnect(NetworkConnection conn)
    {
        
    }
    public override void OnClientDisconnect(NetworkConnection conn)
    {
        Debug.Log("Client disconnected");
    }
}
