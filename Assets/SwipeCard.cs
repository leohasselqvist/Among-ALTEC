using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeCard : MonoBehaviour
{
    private Vector3 mousePosition; // position av musen
    private Rigidbody2D rb; //ridget body
    private Vector2 direction; //riktning
    private float moveSpeed = 800f; //hastighet

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //får in ridgetbody comoneten som kopplas på kortet
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) //ifall man trycker innfaör ridgetbody med vänste musknapp
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //vet faktiskt inte rikitgt vad camera grejen gör, blev tipsad från internet
            direction = (mousePosition - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed); //hastighten är basicly x och y kordinaten multiplicerat med hastighten
        }
        else
        {
            rb.velocity = Vector2.zero; //anars så fryser kortet på plats
        }
    }

    
}
