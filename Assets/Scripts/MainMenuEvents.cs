using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLobby() //Switch scene to the lobby scene
    {
        SceneManager.LoadScene("Lobby");
    }

    public void JoinGame() //Switch scene to the input IP scene (or GameCode if we can write servers)
    {
        SceneManager.LoadScene("Lobby"); // TEMP, REPLACE WITH IP INPUT SCENE LATER
    }

    public void InitGame() // this starts the actual game like killing and shit.
    {
        SceneManager.LoadScene("MapSkeld");  // Start Skeld Map
    }
}
