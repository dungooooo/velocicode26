using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
	public int score = 0;                   // The player's score.


	private PlayerControl playerControl;    // Reference to the player control script.
	private int previousScore = 0;          // The score in the previous frame.
	private Lives lives;					// Reference to the Lives script 
	private bool addLife = false;

    void Awake()
    {
        // Setting up the reference.
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
		lives = GameObject.Find("Lives").GetComponent<Lives>();
	}



	void Update()
	{
		// Set the score text.
		GetComponent<Text>().text = "Score: " + score;

		// Set the previous score to this frame's score.
		previousScore = score;

		// Check if the score has reached 2,000 points; if so, increase the life count by 1
		if (score >= 2000 && !addLife)
        {
			GetComponent<AudioSource>().Play();
			lives.lives += 1;
			addLife = true;
        }
	}

}
