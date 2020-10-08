using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float cursorMovementSpeed;
    [SerializeField] public bool teleportationIsAvaiable;
    [SerializeField] private Sprite avaiableTeleportationSprite;
    [SerializeField] private Sprite unavaiableTeleportationSprite;
    [SerializeField] private Transform markPos;
    void Start()
    {
        spriteRenderer.enabled = false;
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, markPos.position , cursorMovementSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spriteRenderer.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
            spriteRenderer.enabled = false;
    }
    void SpriteChange(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            SpriteChange(unavaiableTeleportationSprite);
            teleportationIsAvaiable = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            SpriteChange(avaiableTeleportationSprite);
            teleportationIsAvaiable = true;
        }
    
    }
}
