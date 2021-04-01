using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float baseSpeed = 10;
    [SerializeField]
    private float speedMod = 1;
    [SerializeField]
    private float delayTime = 1;

    float horizontalMove = 0;
    float verticalMove = 0;
    float totalMove = 0;
    float directionalMove = 0;

    bool facingright = true;

    public Animator animator;

    private Collider2D selectedTask;
    public Rigidbody2D rb;
    public bool timerOn = false;
    public Vent inVent;

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Flip(horizontal);
    }
    
    IEnumerator timer()
    {
        Debug.Log("Timer called");
        timerOn = true;
        yield return new WaitForSeconds(delayTime);
        timerOn = false;
        Debug.Log("Timer Over");
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
            if (timerOn != false || !selectedTask) return;
            if (!selectedTask.CompareTag("Vent")) return;
            selectedTask.GetComponent<Vent>().Popup();
            StartCoroutine(timer());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Task: ENTER from " + other.name);
        if (other.CompareTag("Vent") || other.name == "Task")
        {
            selectedTask = other;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Task: EXIT");
        if (other.CompareTag("Vent") || other.name == "Task")
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
}
