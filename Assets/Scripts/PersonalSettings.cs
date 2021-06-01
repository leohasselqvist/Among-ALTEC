using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PersonalSettings : MonoBehaviour
{
    public static PersonalSettings Instance;
    public string username = "babababa";

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }
}
