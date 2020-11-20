using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;
[System.Serializable]
public struct SpawnsData
{
    public string spawn_name;
    public bool isUsing;
    public Transform spawnTransform;
    public GameObject towerGO;
}

public class EnemySpawner : MonoBehaviour
{
    [Header("WaveStatistics")]
    Animator animator;
    private bool waveStarted = true;
    private bool waveComplete;
    [SerializeField] public List<SpawnsData> spawnsList = new List<SpawnsData>();
    [SerializeField] ushort enemiesToSpawn;
    [SerializeField] ushort towersToSpawn;
    [Header("Configuration")]
    [SerializeField] private GameObject objectsToActive;
    [SerializeField] private GameObject gate;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform[] enemy_Spawns;
    private ScoreMenager scoreMenager;
    [Header("Time")]
    [SerializeField] private float timer;
    [SerializeField] private float timeBtwSpawns;

    void Start()
    {
        scoreMenager = GameObject.Find("Managers").GetComponent<ScoreMenager>();
        animator = GetComponent<Animator>();
        timer = timeBtwSpawns;
        SpawnsAdding();
        foreach (SpawnsData spawn in spawnsList)
        {
            if (spawn.isUsing == true)
                spawn.towerGO.SetActive(true);
        }
    }
    void Update()
    {
        InvokeRepeating("EnemySpawning", timeBtwSpawns, timeBtwSpawns);
    }
    void EnemySpawning()
    {
        scoreMenager.enemyLeft = enemiesToSpawn;

        if (enemiesToSpawn > 0)
        {
            int randomPos = Random.Range(0, enemy_Spawns.Length);
            Instantiate(enemy, -new Vector2(transform.position.x - enemy_Spawns[randomPos].position.x, transform.position.y - enemy_Spawns[randomPos].position.y), Quaternion.identity);
            timer = timeBtwSpawns;
            enemiesToSpawn -= 1;
        }
        //else spawnsList.Clear();
    }
    void SpawnsAdding()
    {
        int j = Random.Range(0, enemy_Spawns.Length);
        int h = Random.Range(0, enemy_Spawns.Length);
        for (int i = 0; i < enemy_Spawns.Length; i++)
        {
            
            SpawnsData spawnData = new SpawnsData();
            {
                spawnData.spawn_name = "spawn_" + i;
                spawnData.spawnTransform = enemy_Spawns[i];
                foreach (Transform child in enemy_Spawns[i].transform)
                {
                    if (child.name == "Tower")
                    {
                        
                        spawnData.towerGO = child.gameObject;
                        if (i == j || i==h)
                        {
                            spawnData.isUsing = true;
                        }
                        else
                        {
                            spawnData.isUsing = false;
                        }
                    }
                }
                spawnsList.Add(spawnData);
            }
        }
    }
}


