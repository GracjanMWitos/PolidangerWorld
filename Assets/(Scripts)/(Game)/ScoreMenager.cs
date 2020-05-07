using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMenager : MonoBehaviour
{
    public int score;
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    public void RiseScore()
    {
        score += 1;
    }
}
