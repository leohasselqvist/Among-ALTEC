using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuEvents : MonoBehaviour
{
    // OBSELETE SCRIPT

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitGame() // this starts the actual game like killing and shit.
    {
        GameManager.Instance.StartGame();
    }
}
