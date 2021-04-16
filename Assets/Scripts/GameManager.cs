using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    // DETTA OBJEKTET FÖRSTÖRS ALDRIG UNDER HELA SPELET
    // Den kommer alltid finnas i bakgrunden och håller koll på spelinställningarna, antal spelare, vilka är imposters, vilka som lever, osv.
    string playerName = "TESTNAME";

    public GameObject playerTemplate;

    public GameObject selfPlayer;

    public List<GameObject> playerList = new List<GameObject>();

    List<Player> livingPlayers = null;  // Sätt lika med playerList när spelet starter
    List<Player> deadPlayers = new List<Player>(); // Fyller på under spelets gång

    int taskAmount; // Inställning som sätts i lobby:n
    int finishedTasks = 0; // Fylls på under spelets gång

    // GAME SETTINGS
    int killDistance = 0;
    int killCooldown = 0;
    int visionMod = 0;
    int startEmergencyMeetings = 2;

    public static GameManager Instance;

    void Start()
    {
        DontDestroyOnLoad(playerTemplate);
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public void CreateLobby()
    {
        SceneManager.LoadScene("Lobby");
    }


    public void StartGame()
    {
    }

    public void SpawnPlayers(Transform pos) // Only call in a map scene (ex. MapSkeld)
    {
        foreach (GameObject player in playerList)
        {

            Instantiate(player, pos);
        }
    }

    public void EndGame(bool impWin) // Ta spelarna till resultaten
    { 
        // TODO
    }
}
