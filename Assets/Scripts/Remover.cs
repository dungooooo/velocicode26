using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Remover : MonoBehaviour
{
	private Lives lives;
	private PlayerControl originalPos;

	void Awake()
    {
		lives = GameObject.Find("Lives").GetComponent<Lives>();
		originalPos = GameObject.Find("PlayerControl").GetComponent<PlayerControl>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if (col.gameObject.tag == "Player")
		{
			GetComponent<AudioSource>().Play();
			// .. stop the camera tracking the player
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;

			// .. stop the Health Bar following the player
			//if (GameObject.FindGameObjectWithTag("HealthBar").activeSelf)
			//{
			//	GameObject.FindGameObjectWithTag("HealthBar").SetActive(false);
			//}

			// ... instantiate the splash where the player falls in.
			//Instantiate(splash, col.transform.position, transform.rotation);
			// ... destroy the player.
			//Destroy(col.gameObject);
			lives.lives -= 1;
			GameObject.FindGameObjectWithTag("Player").transform.position = originalPos.originalPos;

			// ... reload the level.
			//StartCoroutine("ReloadGame");
		}
		else
		{
			GetComponent<AudioSource>().Play();
			// ... instantiate the splash where the enemy falls in.
			//Instantiate(splash, col.transform.position, transform.rotation);

			// Destroy the enemy.
			Destroy(col.gameObject);
		}
	}

	IEnumerator ReloadGame()
	{
		// ... pause briefly
		yield return new WaitForSeconds(5);
		// ... and then reload the level.
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
	}
}
