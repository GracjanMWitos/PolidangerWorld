using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechController : MonoBehaviour
{
    [SerializeField] private bool playerIsClose;
    [SerializeField] public bool playerEnterVehical;
    [SerializeField] GameObject actionButton;
    [SerializeField] PlayerControler playerControler;
    [SerializeField] private float timer;
    
    private void Start()
    {
        actionButton.SetActive(false);
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (playerIsClose == true && Input.GetKey(KeyCode.E))
        {
            playerEnterVehical = true;
        }
        if(playerEnterVehical == true && Input.GetKeyDown(KeyCode.E))
        {
            playerEnterVehical = false;

        }
        if (playerEnterVehical == true)
        {
            transform.position = playerControler.transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            actionButton.SetActive(true);
            playerIsClose = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            actionButton.SetActive(false);
            playerIsClose = false;
        }
    }
}
