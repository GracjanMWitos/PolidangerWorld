using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {



    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("You quited a game");
        Application.Quit();
    }
    public void SelectLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    [System.Obsolete]
    public void ReplayLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

}
