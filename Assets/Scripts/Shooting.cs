using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;  // Firepoint är slutet på pistolen, så skottet spawnar rätt.
    public GameObject bulletPrefab;
    public GameObject flashPrefab;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))  // om man trycker på mouse 1
		{
            Shoot();
		}
    }

    void Shoot()
	{
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);  // Spawna in skottet vid FirePoint (tom gameobject)  och så att den behåller dens global rotation
        GameObject flash = Instantiate(flashPrefab, firePoint.position, firePoint.rotation);  // Spawna in en flash effekt
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();  // Spara skottets rigidbody
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);  // Applicera en stor kraft på skottets rigidbody
        Destroy(flash, 0.05f);  // Ta bort flash efter 0.05 sekunder
    }
}
