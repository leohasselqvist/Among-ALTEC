using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public GameObject hitEffect;
	public GameObject bloodEffect;
	public int dmg;
	public void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject effect;
		GameObject player = collision.gameObject;
		switch (player.tag)
		{
			
			case "Player":  // Om skottet träffar en spelare
				effect = Instantiate(bloodEffect, transform.position, Random.rotation);  // SPAWN BLOOD
				Destroy(effect, 20f);  // förstör effekten för att undvika lagg, men den lämnar lite blood splatter
				player.GetComponent<Player>().hp -= dmg;
				if (player.GetComponent<Player>().hp <= 0)
				{
					player.GetComponent<Player>().Death();
				}
				break;
			case "Imposter":  // Om skottet träffar en imposter  (vette fan om vi ska använda denna taggen men lika gärna få systemet inne)
				effect = Instantiate(bloodEffect, transform.position, Random.rotation);  // Samma skit som spelare, men imposter har en annan tag så detta får finnas här
				Destroy(effect, 20f);
				player.GetComponent<Player>().hp -= dmg;
				if (player.GetComponent<Player>().hp <= 0)
				{
					player.GetComponent<Player>().Death();
				}
				break;
			default: // Om objektet träffar inte en spelare
				effect = Instantiate(hitEffect, transform.position, Random.rotation);  // Basic ricochet effekt
				Destroy(effect, 0.06f);  // förstör väldigt snabbt annars stannar ljuset kvar för längre.
				break;
		}
		Destroy(gameObject);  // förstör skottet.
	}
}
