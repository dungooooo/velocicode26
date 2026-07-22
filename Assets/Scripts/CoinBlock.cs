using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlock : MonoBehaviour
{
    private Animator spriteAnim;
    public bool isOn;
    private GameObject child;
    public Sprite disabled;
    private Score score; // Reference to the Score script
    AudioSource CoinBlockAudio;

    void Awake()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    void Start()
    {
        child = transform.GetChild(0).gameObject;
        spriteAnim = child.GetComponent<Animator>();
        CoinBlockAudio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // If the bottom of the coin block collides with the player, perform certain actions then disable to block so it can't be hit again
        if (col.collider.bounds.max.y < transform.position.y
            && col.collider.bounds.min.x < transform.position.x + 0.5f
            && col.collider.tag == "Player")
        {
            spriteAnim.Play("coinblock_hit");
            score.score += 200;
            child.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            CoinBlockAudio.Play();
            child.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = disabled;
            GetComponent<Animator>().enabled = false;
            GetComponent<CoinBlock>().enabled = false;
        }
    }
}