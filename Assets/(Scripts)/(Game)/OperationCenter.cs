using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationCenter : MonoBehaviour
{

    [Header("Other")]
    [SerializeField] GameObject e_button;
    bool playerIsClose;
    [Header("Spots")]
    [SerializeField] GameObject playerGO;
    [SerializeField] OCSpotSwitch spot;
    [SerializeField] Transform spotPos;

    [Header("Mech nr.1")]
    public bool mechNr1Selected;
    [SerializeField] GameObject Mech_1;

    [Header("Mech nr.2")]
    public bool mechNr2Selected;
    [SerializeField] GameObject Mech_2;

    [Header("Mech nr.3")]
    public bool mechNr3Selected;
    [SerializeField] GameObject Mech_3;

    [Header("CanvasOptions")]
    public bool canvasActive;
    [SerializeField] Canvas charactersMenu;
    
    private Vector2 playerToBlockVector;
    private void Start()
    {

    }
    void Update()
    {
        if (spot.isSwitched == true && spot.isTouching == true)
        {
            transform.position = spotPos.transform.position;
        }
        CharactersMenu();
        MechSelection();
    }
    void MechSelection()
    {

    }
    public void MainCharacterReturn()
    {
        playerGO.SetActive(true);
        charactersMenu.gameObject.SetActive(false);
        canvasActive = false;
    }
    public void CharactersMenu()
    {
        if(playerIsClose && Input.GetKeyDown(KeyCode.E))
        {
            canvasActive = true;
            playerGO.SetActive(false);
            charactersMenu.gameObject.SetActive(true);
        }
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
;           e_button.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            e_button.SetActive(false);
        }
    }
}
