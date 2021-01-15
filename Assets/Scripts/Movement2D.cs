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

    private Collider2D selectedTask;
    public Rigidbody2D rb;
    public bool timerOn = false;
    void Start()
    {
        
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
        var movement_h = Input.GetAxis("Horizontal") * baseSpeed * speedMod;
        var movement_v = Input.GetAxis("Vertical") * baseSpeed * speedMod;
        //transform.position += new Vector3(movement_h, movement_v, 0) * Time.deltaTime * baseSpeed * speedMod;*/

        rb.velocity = new Vector2(movement_h, movement_v);

        if (!Input.GetButtonDown("Fire1")) return;
        if (timerOn != false || !selectedTask) return;
        if (!selectedTask.CompareTag("Vent")) return;
        selectedTask.GetComponent<Vent>().Popup();
        StartCoroutine(timer());
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
}
