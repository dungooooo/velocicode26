using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBlock : MonoBehaviour
{
    private ParticleSystem particle; //Reference to the particle system. 
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        // Check to see if the collision was at the bottom edge of box and collided with the Player
        if (col.collider.bounds.max.y < transform.position.y
            && col.collider.bounds.min.x < transform.position.x + 0.5f
            && col.collider.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            StartCoroutine(Break());
        }
    }

    private IEnumerator Break()
    {
        particle.Play();
        sr.enabled = false;
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
