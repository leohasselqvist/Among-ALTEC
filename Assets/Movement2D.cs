using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float baseSpeed = 10;
    [SerializeField]
    private float speedMod = 1;
    void Start()
    {
        
    }
    void Update()
    {
        var movement_h = Input.GetAxis("Horizontal");
        var movement_v = Input.GetAxis("Vertical");
        transform.position += new Vector3(movement_h, movement_v, 0) * Time.deltaTime * baseSpeed * speedMod;
        
    }
}
