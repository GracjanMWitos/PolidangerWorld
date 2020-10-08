using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSpace : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Destroy(GameObject.FindGameObjectWithTag("PlayerBullet"));
        }
        if (collision.CompareTag("Bullet"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Bullet"));
        }
    }
}
