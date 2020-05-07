using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [SerializeField] Interaction p_interaction;

    public float clearedLevels;
    public Canvas pauseCanvas;
    [SerializeField] EnemySpawner enemySpawner;

    private ScoreMenager scoreMenager;
    [Header("Scores")]
    public int scoreCurrently;
    [Header("Gates")]
    [SerializeField] GameObject gate1 = null;
    public int scoreNeed1;
    [SerializeField] GameObject gate2 = null;
    public int scoreNeed2;
    [SerializeField] GameObject gate3 = null;
    public int scoreNeed3;
    [SerializeField] GameObject gate4 = null;
    public int scoreNeed4;
    [SerializeField] GameObject gate5 = null;
    public int scoreNeed5;

    void Start()
    {
        scoreCurrently = 0;
    }
    private void Update()
    {
        scoreCurrently = p_interaction.score;
        if (scoreCurrently == scoreNeed1)
        {
            gate1.SetActive(false);
        }
        if (scoreCurrently == scoreNeed2)
        {
            gate2.SetActive(false);
        }
        if (enemySpawner.waveComplete == true)
        {
            gate3.SetActive(false);
        }
        /*if (scoreCurrently == scoreNeed4)
        {
            gate4.SetActive(false);
        }
        if (scoreCurrently == scoreNeed5)
        {
            //gate5.SetActive(false);
        }*/
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        clearedLevels += 1;
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
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseCanvas.gameObject.SetActive(false);
    }

}
