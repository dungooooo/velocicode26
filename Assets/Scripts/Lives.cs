using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Lives : MonoBehaviour
{
	public int lives = 3;                   // The player's initial life count.


	private PlayerControl playerControl;    // Reference to the player control script.
	private int previousLives = 3;          // Te life count in the previous frame.
	private bool gameOver = false;
	GameObject music;						// Reference to the Main Theme music 

	void Awake()
	{
		// Setting up the reference.
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
		music = GameObject.Find("mainMusic");
	}


	void Update()
	{
		// Set the life text. on UI
		GetComponent<Text>().text = "Lives: " + lives;

		// Set the previous life count to this frame's life count.
		previousLives = lives;
		//If the life count reaches zero and the game isn't over yet...
		if (lives == 0 && !gameOver)
        {
			Die();
			gameOver = true;
		}
	}
	
	// Play Game Over music and call CoRoutine to restart game
	void Die()
    {
		music.SetActive(false);
		GetComponent<AudioSource>().Play();
		StartCoroutine(NewGame());
	}
	
	//Reload scene to restart the game.
	IEnumerator NewGame()
	{
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
	}
}
