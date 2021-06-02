﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float baseSpeed = 10;
    [SerializeField]
    private float speedMod = 1;

    public Slider slider;

    [SerializeField]
    private float hp = 100;

    float horizontalMove = 0;
    float verticalMove = 0;
    float totalMove = 0;
    float directionalMove = 0;

    bool facingright = true;

    public Animator animator;

    private Collider2D selectedTask;

    public Rigidbody2D rb;

    string playerName;
    bool isDead = false;

    [SerializeField]
    bool isImposter;

    int emergencyMeetings;

    public GameObject playerPrefab;
    public GameObject CameraPrefab;

    private void FixedUpdate()
    {
        //"Setter" för horizontal för "Flip" funktion

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

        GameObject.Find("Healthbar").GetComponent<Slider>().value = hp;
    }

    private void Death()
    {
        //Spawnar lik, Sätter Opacity, sätter variabler till "true"
        //Kollar om spelaren är impostoe, avslutar spelet

        isDead = true;
        spawnEnemy();
        this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        animator.SetBool("Dead", true); 
        if (isImposter == true)
        {
            EndGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Kollar om man är i närheten av task, sätter selectedTask till task

        Debug.Log("Task: ENTER from " + other.name);
        if (other.name == "Task")
        {
            selectedTask = other;

        }

    }
    public void EndGame()
    {
        //Scrip for ending the game and returning to main menu
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Kollar om man går ut från en task, sätter selectedTask till null

        Debug.Log("Task: EXIT");
        if (other.name == "Task")
        {
            selectedTask = null;
        }
    }

    private void Flip(float horizontal)
    {
        //Flippar spriten om man går höger/vänster

        if (horizontal > 0 && !facingright || horizontal < 0 && facingright)  // Om vågrät movement är motsatsen till förra riktningen
        {
            facingright = !facingright;  // Flippa facingright (så om den var true så blir den false, om den var false blir den true)

            GetComponent<SpriteRenderer>().flipX = !facingright;  // Sätt den bool:en till flipX attributen i SpriteRenderer (riktningen var spegelvänd så fick invertera facingright)
        }
    }
    public Player(string playerName, bool isDead, bool isImposter, int emergencyMeetings)
    {
        //constructor för klassen "player"

        this.playerName = playerName;
        this.isDead = isDead;
        this.isImposter = isImposter;
        this.emergencyMeetings = emergencyMeetings;
    }

    Vector3 localscale;
    void Start()
    {
        //"Setter" för healthbar, ändrar variabler om man är impostor

        GameObject.Find("Healthbar").GetComponent<Slider>().value = hp;
        localscale = transform.localScale;

        if (isImposter == true)
        {
            hp = 500;
            speedMod += 2;

        }
    }

    private void spawnEnemy()
    {
        //Funktion för att spawna sprite på död spelare

        GameObject a = Instantiate(playerPrefab) as GameObject;
        a.transform.position = this.transform.position;

    }
}
