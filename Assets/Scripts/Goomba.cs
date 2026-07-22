using UnityEngine;
using System.Collections;

public class Goomba : MonoBehaviour
{
	public float moveSpeed = 2f;        // The speed the enemy moves at.

	private SpriteRenderer ren;         // Reference to the sprite renderer.
	private Transform frontCheck;       // Reference to the position of the gameobject used for checking if something is in front.
	private bool frontHits = false;
	private Score score;				// Reference to the Score script 
	private Animator animDie;

	void Awake()
	{
		// Setting up the references.
		ren = transform.GetComponent<SpriteRenderer>();
		frontCheck = transform.Find("frontCheck").transform;
		score = GameObject.Find("Score").GetComponent<Score>();
		animDie = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		// Check if the enemy has collided with something in front of it
		frontHits = Physics2D.Linecast(transform.position, frontCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		// If any of the colliders is a Ground object...
		if (frontHits)
		{
				// ... Flip the enemy and stop checking the other colliders.
			Flip();
		}
		// Set the enemy's velocity to moveSpeed in the x direction.
		GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

	}

	public void Flip()
	{
		// Multiply the x component of localScale by -1.
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		// If the enemy collides with a player from above, score is increased and the Goomba dies
		if (col.gameObject.tag == "Player")
		{
			score.score += 100;
			GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
			GetComponent<Collider2D>().enabled = false;
			GetComponent<AudioSource>().Play();
			moveSpeed = 0;
			animDie.SetTrigger("GoombaDie");
			Destroy(transform.root.gameObject, 1f);
		}
		// If the Goomba falls of the cliff, destroy the Goomba 
		else if (col.gameObject.tag == "killZone")
		{
			Destroy(transform.root.gameObject);
			moveSpeed = 0;
		}
		// If the Goomba collides with another Goomba, flip 
		else if (col.gameObject.tag == "Enemy")
		{
			Flip();
		}
	}
}
