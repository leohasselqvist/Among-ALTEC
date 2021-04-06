﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    public bool isDead;
    public bool isImposter;
    public int emergencyMeetings;

    public GameObject playerPrefab;

    public Animator animator;

    public Player(string playerName, bool isDead, bool isImposter, int emergencyMeetings)
    {
        this.playerName = playerName;
        this.isDead = isDead;
        this.isImposter = isImposter;
        this.emergencyMeetings = emergencyMeetings;
    }

    void Start()
    {
        //spawnEnemy();  man this bugged my code so much - from leo
        
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(playerPrefab) as GameObject;
        a.transform.position = this.transform.position;

    }

    void Update()
    {
        if (isDead == true)
        {
            animator.SetBool("Dead", true);
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }

    }
}
