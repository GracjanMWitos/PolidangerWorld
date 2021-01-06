using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    GameManager playerStatistics;
    private void Start()
    {
       playerStatistics  = GameObject.Find("Managers").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            Destroy(gameObject);
            playerStatistics.xp += 1 * playerStatistics.level *playerStatistics.xp_multipilier;
        }
    }
}
