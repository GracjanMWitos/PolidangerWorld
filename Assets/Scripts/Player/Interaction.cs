using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool isClosePower;
    public int score;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PowerBlock"))
        {
            isClosePower = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PowerBlock") && Input.GetKeyDown(KeyCode.E))
        {
            isClosePower = false;
            score += 1;
        }
    }
}
