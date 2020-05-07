using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool gameIsPaused;
     void Start()
    {
        gameIsPaused = false;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            gameIsPaused = true;
            Time.timeScale = 0f;
        }
        if (Input.GetKey(KeyCode.Escape) && gameIsPaused == true)
        {
            gameIsPaused = false;
            Time.timeScale = 1f;
        }
    }
}
