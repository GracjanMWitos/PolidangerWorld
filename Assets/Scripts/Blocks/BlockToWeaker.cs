using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockToWeaker : MonoBehaviour
{
    [SerializeField] private int blockHealth = 0;
    public Sprite sprite1;
    public Sprite sprite2;

    void Update()
    {
        if(blockHealth == 1)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
        else if (blockHealth == 2)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball") && blockHealth == 2)
            Destroy(gameObject);
        else if (collision.collider.CompareTag("Ball"))
        {
            blockHealth += 1;
        }
    }
}
