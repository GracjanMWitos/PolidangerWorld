using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public bool isTouching;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == ("Player"))
        {
            isTouching = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == ("Player"))
        {
            isTouching = false;
        }
    }
}