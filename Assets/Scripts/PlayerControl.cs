using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;         // For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;               // Condition for whether the player should jump.


	public float moveForce = 365f;          // Amount of force added to move the player left and right.
	public float maxSpeed = 8f;             // The fastest the player can travel in the x axis.
	public float jumpForce = 820f;         // Amount of force added when the player jumps.

	private Transform groundCheck;          // A position marking where to check if the player is grounded.
	private bool grounded = false;          // Whether or not the player is grounded.
	private bool killEnemy = false;			// A bool value to ensure the enemy isn't already actively being killed
	private Animator anim;                  // Reference to the player's animator component.
	public Vector2 originalPos;				// A vector to store the position that Mario starts at
	private Lives lives;					// Reference to the Lives script
	public AudioClip[] sounds;				// An array of sound clips that occur upon certain events
	GameObject music;						// Reference to the Mario Main Theme song 


	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
		originalPos = gameObject.transform.position;
		lives = GameObject.Find("Lives").GetComponent<Lives>();
		music = GameObject.Find("mainMusic");

	}


	void Update()
	{
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		// If the jump button is pressed and the player is grounded then the player should jump.
		if (Input.GetButtonDown("Jump") && grounded)
		{
			GetComponent<AudioSource>().clip = sounds[0];
			GetComponent<AudioSource>().Play(); // Play Jump Noise
			jump = true;
		}
	}


	void FixedUpdate()
	{
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");

		// The Speed animator parameter is set to the absolute value of the horizontal input.
		anim.SetFloat("Speed", Mathf.Abs(h));

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
			// ... add a force to the player.
			GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

		// If the player's horizontal velocity is greater than the maxSpeed...
		if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		// If the input is moving the player right and the player is facing left...
		if (h > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (h < 0 && facingRight)
			// ... flip the player.
			Flip();

		// If the player should jump...
		if (jump)
		{
			// Set the Jump animator trigger parameter.
			anim.SetTrigger("Jump");

			// Add a vertical force to the player.
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));

			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
	}


	void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		killEnemy = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Enemies"));
		
		// If the colliding gameobject is an Enemy and collision wasn't on the enemy's head, Mario dies...
		if (col.gameObject.tag == "Enemy" && killEnemy == false)
		{
			StartCoroutine(Die());
		}
		// Otherwise, bounce off the enemy's head
		if (col.gameObject.tag == "Enemy" && killEnemy == true)
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 500f));
		}
	}

	void OnTriggerEnter2D(Collider2D other)
    {
		// Check if Mario has reached the end of the level and touched the flagpole 
		if (other.tag == "Flag")
        {
			gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
			anim.Play("SlideDownFlag");
			music.SetActive(false);
			GetComponent<AudioSource>().clip = sounds[3];
			GetComponent<AudioSource>().Play();
		}
		// Check if Mario has fallen off the platform. 
		if (other.tag == "killZone")
        {
			gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
			StartCoroutine(Die());
		}

	}

	IEnumerator Die()
	{
		music.SetActive(false);
		GetComponent<AudioSource>().clip = sounds[1];
		GetComponent<AudioSource>().Play();
		// ... pause briefly
		anim.Play("Die");
		yield return new WaitForSeconds(3);
		// ... and then restart Mario at the starting position. 
		lives.lives -= 1;
		gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
		gameObject.transform.position = originalPos;
		gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
		anim.Play("Idle");
		music.SetActive(true);
	}

}