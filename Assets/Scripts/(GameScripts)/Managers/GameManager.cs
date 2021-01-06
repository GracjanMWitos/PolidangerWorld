using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int maxHealthPointsCapacity = 100;
    public int maxPowerPointsCapacity = 20;
    public int maxEnginaryPointsCapacity = 2;
    public int xp = 1;
    public int xp_multipilier;
    public int level = 1;

    public static GameManager Instance;
    public short enemyLeft;
    private Text xp_text;
    public GameObject[] objectsThatPausingGame;
        void Awake()
        {
        
        objectsThatPausingGame = GameObject.FindGameObjectsWithTag("UI");
        foreach (GameObject obj in objectsThatPausingGame)
            obj.SetActive(false);
        if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        xp_text = GameObject.Find("XPText").GetComponent<Text>();
        }
    private void Update()
    {
        xp_text.text = "XP " + xp;
        foreach (GameObject objectToPauseGame in objectsThatPausingGame)
        {
            if (objectToPauseGame.activeInHierarchy)
            {
                Time.timeScale = 0.1f;
            }
        }
    }
}