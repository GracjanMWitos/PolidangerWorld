using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("WaveStatistics")]
    [SerializeField] GameObject NotStarted;
    [SerializeField] GameObject Started;
    [SerializeField] GameObject Completed;
    private bool waveStarted;
    public bool waveComplete;
    [SerializeField] ushort enemyNumberToSpawn;
    [Header("Configuration")]
    [SerializeField] string gate_name;
    private GameObject gate;
    [SerializeField] TrigerAndCollisionDetection trigger;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform[] enemySpots;
    public ScoreMenager scoreMenager;
    [Header("Timer")]
    [SerializeField] private float timer;
    [SerializeField] float timeBtwSpawns;
    
    void Start()
    {
        timer = timeBtwSpawns;
        scoreMenager.enemyLeft = enemyNumberToSpawn;
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
        if (waveComplete == true)
        {
            Completed.SetActive(true);
            gate.SetActive(true);
        }
    }
    void EnemySpawning()
    {
        int randomPos = Random.Range(0, enemySpots.Length);
        if (waveStarted)
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

            if (scoreMenager.enemyLeft == 0)
            {
                waveComplete = true;
                gate.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "OperationCenter")
        {
            NotStarted.SetActive(false);
            Started.SetActive(true);
            waveStarted = true;
        }
    }
}
