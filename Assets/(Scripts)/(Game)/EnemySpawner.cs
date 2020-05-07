using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("WaveStatistics")]
    [SerializeField] GameObject NotStarted;
    [SerializeField] GameObject Started;
    [SerializeField] GameObject Completed;
    public bool waveComplete;
    public int enemyLeft;
    [SerializeField] int enemyNumberToSpawn;
    [Header("Configuration")]
    [SerializeField] string gate_name;
    private GameObject gate;
    [SerializeField] TrigerAndCollisionDetection trigger;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform[] enemySpots;
    [Header("Timer")]
    [SerializeField] private float timer;
    [SerializeField] int timeBtwSpawns;
    
    void Start()
    {
        timer = timeBtwSpawns;
        enemyLeft = enemyNumberToSpawn;
        gate = GameObject.Find(gate_name);
    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawning();
        StateChange();
    }
    void StateChange()
    {


        if (trigger.isTrigering)
        {
            NotStarted.SetActive(false);
            Started.SetActive(true);
        }
        if (waveComplete == true)
        {
            Completed.SetActive(true);
        }
    }
    void EnemySpawning()
    {
        int randomPos = Random.Range(0, enemySpots.Length);
        if (trigger.isTrigering == true)
        {

            if (enemyNumberToSpawn > 0)
                if (timer <= 0)
                {
                    Instantiate(enemy, new Vector2(enemySpots[randomPos].position.x + 82, enemySpots[randomPos].position.y + 9), Quaternion.identity);
                    timer = timeBtwSpawns;
                    enemyNumberToSpawn -= 1;
                }
            if (timer > 0)
                timer -= Time.deltaTime;

            if (enemyLeft == 0)
            {
                waveComplete = true;
            }
        }
    }
    
}
