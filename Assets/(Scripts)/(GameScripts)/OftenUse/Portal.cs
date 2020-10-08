using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private bool thisPortalEndsLevel;
    [SerializeField] private Transform secondPortal;
    [SerializeField] private GameObject player;
    [SerializeField] private PauseScript pause;
    [SerializeField] private int distanceToPortal;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pause = GameObject.Find("Menagers").GetComponent<PauseScript>();
    }
    void Update()
    {
        ObjectChange();
    }
    private void ObjectChange()
    {
        if (pause.characterMenuOn == false)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (pause.characterMenuOn)
        {
            player = null;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (thisPortalEndsLevel)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            if (!thisPortalEndsLevel)
            {
                Vector2 pos = new Vector2(secondPortal.position.x, secondPortal.position.y);
                player.transform.position = pos ;
            }


        }
    }
}
