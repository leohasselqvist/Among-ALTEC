﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    string playerName;
    int killDistance;
    int killCooldown;
    int visionMod;
    bool isDead;
    bool isImposter;
    int emergencyMeetings;

    public Player(string playerName, int killDistance, int killCooldown, int visionMod, bool isDead, bool isImposter, int emergencyMeetings)
    {
        this.playerName = playerName;
        this.killDistance = killDistance;
        this.killCooldown = killCooldown;
        this.visionMod = visionMod;
        this.isDead = isDead;
        this.isImposter = isImposter;
        this.emergencyMeetings = emergencyMeetings;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}