using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
        public static GameManager Instance;
    public int maxHealthPointsCapacity = 100;
    public int maxPowerPointsCapacity = 20;
    public int maxEnginaryPointsCapacity = 2;
    public int xp;

        void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    
}
