using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Score score; // Reference to the Score script
    public SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = true;
    }

    void Awake()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player enters the coin's trigger zone, play coin noise, add score, and destroy the coin
        if (other.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            score.score += 100;
            rend.enabled = false;
            Destroy(transform.root.gameObject, 1f);
        }
    }
}
