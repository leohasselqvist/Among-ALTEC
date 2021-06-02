using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Camera cam;
    private Rigidbody2D rb;
    private Vector2 mousePos;
    public float scaleModifier = 1;

    // Start is called before the first frame update
    void Start()
    {
        
        cam = transform.parent.transform.Find("Main Camera").GetComponent<Camera>();  // Hämta kamera från spelar objektet. TODO: FIX FOR NETWORKING WHEN MERGE
        rb = transform.parent.GetComponent<Player>().rb;  // Hämta rigidbody från parent eftersom man behöver den för att fixa rotation
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition - cam.WorldToScreenPoint(transform.position);  // Updaterar musens position varje frame (från kamerans perspektiv
        //cam.gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, -transform.parent.transform.rotation);
    }

	private void FixedUpdate()
	{
        var angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        float scaleFlip = 1*scaleModifier;
        if (transform.parent.localScale.x > 0)  // hela den här If statementen är en otroligt överkomplicerad lösning men vafan det är det enda som funkar jag orkar inget mer stäm inte mig :(
		{
            scaleFlip = 1*scaleModifier;
		}
        else
		{
            scaleFlip = -1*scaleModifier;
		}

        transform.localScale = new Vector3(scaleFlip, Mathf.Abs(scaleFlip), transform.localScale.z);  // Applicera scaleflip till pistolen
    }
}
