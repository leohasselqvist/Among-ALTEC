using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public float MovementSpeed = 1;
    void Start()
    {
        
    }
    void Update()
    {
        var movement_h = Input.GetAxis("Horizontal");
        var movement_v = Input.GetAxis("Vertical");
        transform.position += new Vector3(movement_h, movement_v, 0) * Time.deltaTime * MovementSpeed;
        
    }
}
