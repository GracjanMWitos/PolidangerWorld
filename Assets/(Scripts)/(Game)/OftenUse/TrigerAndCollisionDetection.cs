using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerAndCollisionDetection : MonoBehaviour
{
    [Header("Trigering")]
    public bool isTrigering = false;
    [SerializeField] string trg_objectName;
    [SerializeField] GameObject objectToTrigering;

    [Header("Colliding")]
    public bool isCollideing = false;
    [SerializeField] string col_objectName;
    [SerializeField] GameObject objectToColliding;

    private void Start()
    {
        objectToTrigering = GameObject.Find(trg_objectName);
        objectToColliding = GameObject.Find(col_objectName);
    }
    private void OnTriggerEnter2D(Collider2D collision){if (collision.gameObject == objectToTrigering) isTrigering = true;}
    private void OnTriggerExit2D(Collider2D collision) { if (collision.gameObject == objectToTrigering) isTrigering = false ; }
    private void OnCollisionEnter2D(Collision2D collision){ if (collision.gameObject == objectToTrigering) isCollideing = true;}
    private void OnCollisionExit2D(Collision2D collision) { if (collision.gameObject == objectToTrigering) isCollideing = false; }
}
