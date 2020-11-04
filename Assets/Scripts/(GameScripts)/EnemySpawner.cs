using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("WaveStatistics")]
    [SerializeField] GameObject notStarted;
    [SerializeField] GameObject started;
    [SerializeField] GameObject completed;
    private bool waveStarted;
    private bool waveComplete;
    [SerializeField] ushort enemyNumberToSpawn;
    [Header("Configuration")]
    [SerializeField] private GameObject objectsToActive;
    [SerializeField] private GameObject gate;
    [SerializeField] private GameObject enemy;
    [SerializeField] Transform[] enemySpots;
    private ScoreMenager scoreMenager;
    [Header("Timer")]
    [SerializeField] private float timer;
    [SerializeField] private float timeBtwSpawns;
    
    void Start()
    {
        scoreMenager = GameObject.Find("Menagers").GetComponent<ScoreMenager>();

        timer = timeBtwSpawns;
    }
    void Update()
    {
        EnemySpawning();
        TowerActive();
    }
    void EnemySpawning()
    {
        int randomPos = Random.Range(0, enemySpots.Length);
        if (waveStarted)
        {
            scoreMenager.enemyLeft = enemyNumberToSpawn;
            if (enemyNumberToSpawn > 0)
                if (timer <= 0)
                {
                    Instantiate(enemy, new Vector2(enemySpots[randomPos].position.x + 82, enemySpots[randomPos].position.y + 9), Quaternion.identity);
                    timer = timeBtwSpawns;
                    enemyNumberToSpawn -= 1;
                }
            if (timer > 0)
                timer -= Time.deltaTime;

            if (scoreMenager.enemyLeft == 0)
            {
                waveComplete = true;
                gate.SetActive(false);
            }
        }
    }
    void TowerActive()
    {
        if (waveStarted)
        {
                objectsToActive.SetActive(true);
        }
        if (waveComplete)
        {
                objectsToActive.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "OperationCenter")
        {
            Destroy(notStarted);
            started.SetActive(true);
            waveStarted = true;
        }
    }
}
