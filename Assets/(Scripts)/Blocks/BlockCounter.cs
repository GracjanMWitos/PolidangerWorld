using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCounter : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    public int blockToDestroy;
    ScoreMenager scores;
    private void Start()
    {
        scores = GameObject.Find("Menagers").GetComponent<ScoreMenager>();
    }
    void Update()
    {
        
        if (scores.blockDestoried == blockToDestroy)
        {
            Destroy(this.gameObject);
            Enemy.SetActive(true);
            scores.blockDestoried = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {
            
        }
    }
}
