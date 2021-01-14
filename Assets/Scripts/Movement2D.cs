using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
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

    public Rigidbody2D rb;

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
        
    }

    private void Flip(float horizontal)
    {

    }
}
