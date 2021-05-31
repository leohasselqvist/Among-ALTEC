using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirror;

public class Player : NetworkBehaviour
{
    private List<GameObject> PlayerList = new List<GameObject>();

    //[SyncVar]  // SyncVar är variablar som är synkade över nätverket, sånt som andra spelare måste veta.
    public string playerName;
    [SerializeField]
    private float baseSpeed = 10;
    [SerializeField]
    private float speedMod = 1;

    float horizontalMove = 0;
    float verticalMove = 0;
    float totalMove = 0;
    float directionalMove = 0;

    public GameObject CameraPrefab;

    bool facingright = true;

    public Animator animator;

    private Collider2D selectedTask;

    public Rigidbody2D rb;
    bool isDead = false;
    bool isImposter;
    int emergencyMeetings;

    public GameObject playerPrefab;

    private void FixedUpdate()
    {

        if (!isLocalPlayer) return;

        float horizontal = Input.GetAxis("Horizontal");

        Flip(horizontal);
    }

    void Update()
    {
        if (!isLocalPlayer) return;
        //Ta fram värden på spelarens rörelse
        horizontalMove = Input.GetAxisRaw("Horizontal") * baseSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * baseSpeed;

        //Värde för spelarens rikting (vänster < 0 < höger)
        directionalMove = Input.GetAxis("Horizontal");

        //Kolla om spelaren rör sig eller inte
        totalMove = Mathf.Abs(horizontalMove) + Mathf.Abs(verticalMove);
        animator.SetFloat("Speed", Mathf.Abs(totalMove));

        var movement_h = Input.GetAxis("Horizontal") * baseSpeed * speedMod;
        var movement_v = Input.GetAxis("Vertical") * baseSpeed * speedMod;
        //transform.position += new Vector3(movement_h, movement_v, 0) * Time.deltaTime * baseSpeed * speedMod;*/

        rb.velocity = new Vector2(movement_h, movement_v);

        if (Input.GetButtonDown("Fire2"))
        {
            selectedTask.GetComponent<Task>().Popup();
        }
    }

    private void Death()
    {
        isDead = true;
        spawnEnemy();
        this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        animator.SetBool("Dead", true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Task: ENTER from " + other.name);
        if (other.name == "Task")
        {
            selectedTask = other;

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Task: EXIT");
        if (other.name == "Task")
        {
            selectedTask = null;
        }
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingright || horizontal < 0 && facingright)
        {
            facingright = !facingright;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

    public override void OnStartLocalPlayer()
    {
        Instantiate(CameraPrefab, transform);
        playerName = PersonalSettings.Instance.username;
        serverRegister(gameObject, playerName);
    }

    [Command]
    public void serverRegister(GameObject player, string newName)
    {
        // DET HÄR KÖR BARA PÅ SERVERN, MEN ALLA PARAMETERS KOMMER FRÅN CLIENT (CLIENT INFO -> HOST PLAYEROBJECT)

        player.transform.Find("Player Name").GetComponent<TextMeshPro>().text = newName;
        PlayerList.Add(player);
        updateNamesForPlayers(PlayerList);
        Debug.Log("add " + player.GetComponent<Player>().playerName + " to list");
    }

    [ClientRpc]
    public void updateNamesForPlayers(List<GameObject> playerList)
    {
        // DET HÄR KÖR BARA PÅ CLIENTS, MEN ALLA PARAMETERS KOMMER FRÅN SERVERN

        foreach (GameObject player in playerList)
        {
            Debug.Log("update name");
            player.transform.Find("Player Name").GetComponent<TextMeshPro>().text = player.GetComponent<Player>().playerName;  // APPLY NAMES TO NEW CONNECTS
        }
    }



    private void spawnEnemy()
    {
        GameObject a = Instantiate(playerPrefab) as GameObject;
        a.transform.position = this.transform.position;

    }
}
