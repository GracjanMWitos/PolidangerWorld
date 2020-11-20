using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestruction : MonoBehaviour
{
    ScoreMenager scores;
    private void Start()
    {
        scores = GameObject.Find("Managers").GetComponent<ScoreMenager>();
    }
    public void OnCollisionEnter2D(Collision2D block)
    {
        if (block.collider.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            scores.blockDestoried += 1;
        }
    }
}
