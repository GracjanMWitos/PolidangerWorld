using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {



    public void LoadNextLevel()
    {
        Debug.Log("Trafiłeś do " + SceneManager.GetActiveScene().buildIndex + 1 + " levela");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("You quited a game");
        Application.Quit();
    }
    public void SelectLevel(string sceneName) => SceneManager.LoadScene(sceneName);
    public void ReturnToLobby() => SceneManager.LoadScene(1);

    [System.Obsolete]
    public void ReplayLevel() => Application.LoadLevel(Application.loadedLevel);

}
