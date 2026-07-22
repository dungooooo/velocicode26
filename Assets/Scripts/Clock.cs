using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public float timeLeft = 300; // Starting amount of time when the game starts
    
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime; // Decrease by one second over course of the game
        GetComponent<Text>().text = "Time: " + (int)timeLeft; // Display time to UI
    }
}
