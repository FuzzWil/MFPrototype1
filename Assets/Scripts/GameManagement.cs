using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Timeline;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor to the center of the screen
        Cursor.visible = false; // Hides the cursor
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // When the Escape key is pressed, unlock the cursor and make it visible
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f; // Pauses the game by setting the time scale to zero
            Debug.Log("Game paused. Press Escape to resume.");
        }
        else if (Input.GetMouseButtonDown(0))
        {
            // Pressing the left mouse button resumes the game
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f; // Resets the time scale to normal speed
            Debug.Log("Game resumed. Press Escape to pause.");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            // When the R key is pressed, reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            // When the Q key is pressed, quit the application
            Application.Quit();
        }
    }
}
