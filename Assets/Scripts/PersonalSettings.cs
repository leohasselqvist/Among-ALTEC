using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Mirror;

public class PersonalSettings : NetworkBehaviour
{
    public static PersonalSettings Instance;

    [SyncVar]
    public string username = "leo is best";

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }
}
