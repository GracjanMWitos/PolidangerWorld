using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCSpotSwitch : MonoBehaviour
{

    [Header("OperationCenterSpots")]
    public bool isSwitched;
    public bool isTouching;
    [SerializeField] GameObject ActiveObject;
    [SerializeField] GameObject buttonImg;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTouching == true)
        {
            isSwitched = true;
            ActiveObject.SetActive(true);
        }
        if(!isTouching)
        {
            isSwitched = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isTouching = true;
            buttonImg.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isTouching = false;
            buttonImg.SetActive(false);
        }
    }
}
