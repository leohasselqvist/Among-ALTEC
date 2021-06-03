using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera cam;
    private Rigidbody2D rb;
    private Vector2 mousePos;
    public float scaleModifier = 1;

    // Start is called before the first frame update
    void Start()
    {
        
        //cam = transform.parent.transform.Find("PlayerCamera").GetComponent<Camera>();  // Hämta kamera från spelar objektet.
        rb = transform.parent.GetComponent<Player>().rb;  // Hämta rigidbody från parent eftersom man behöver den för att fixa rotation
    }

    // Update is called once per frame
    void Update()   
    {
        mousePos = Input.mousePosition - cam.WorldToScreenPoint(transform.position);  // Updaterar musens position varje frame (från kamerans perspektiv)
    }

    private void FixedUpdate()
    {
        var angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;  // Använd Atan2 (Atan men utan division) för att bilda en vinkel från en koordinatssystem, och omvandla den från Radianer till Grader
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);  // Sedan använd unity's Quaternions system och omvandla vinkeln till Quaternions.
    }
}   
