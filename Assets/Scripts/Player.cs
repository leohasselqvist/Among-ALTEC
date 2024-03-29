﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirror;

public class Player : MonoBehaviour
{
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
        float horizontal = Input.GetAxis("Horizontal");

        Flip(horizontal);
    }

    void Update()
    {
        //Ta fram värden på spelarens rörelse
        horizontalMove = Input.GetAxisRaw("Horizontal") * baseSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * baseSpeed;

        //Värde för spelarens rikting (vänster < 0 < höger)
        directionalMove = Input.GetAxis("Horizontal");
        Debug.Log("Direction value: " + directionalMove);

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
    public Player(string playerName, bool isDead, bool isImposter, int emergencyMeetings)
    {
        this.playerName = playerName;
        this.isDead = isDead;
        this.isImposter = isImposter;
        this.emergencyMeetings = emergencyMeetings;
    }

    Vector3 localscale;
    void Start()
    {
        //spawnEnemy();  man this bugged my code so much - from leo
        playerName = PersonalSettings.Instance.username;
        transform.Find("Player Name").GetComponent<TextMeshPro>().text = playerName;
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(playerPrefab) as GameObject;
        a.transform.position = this.transform.position;

    }
}
