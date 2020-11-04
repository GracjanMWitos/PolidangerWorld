using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCSpotSwitch : MonoBehaviour
{
    private bool _IsTouching;
    private Transform _OCTransform;
    [SerializeField] private Transform _Spot;
    private Animator _Anim;

    private void Awake()
    { 
        _Anim = GetComponent<Animator>();
        _OCTransform = GameObject.Find("OperationCenter").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        if(_IsTouching && Input.GetKeyDown(KeyCode.E))
        {
            _Anim.SetTrigger("IsInteracted");
            _OCTransform.position = _Spot.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _IsTouching = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _IsTouching = false;
        }
    }
}
