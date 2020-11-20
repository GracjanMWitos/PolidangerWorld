using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Portal : MonoBehaviour
{
    [SerializeField] private bool thisPortalIsChangingLevel;
    [SerializeField] private bool thisPortalIsStartingLevel;
    [SerializeField] private string nextSceneName;
    [SerializeField] private GameObject secondPortal;
    [SerializeField] private GameObject player;
    [SerializeField] private PauseScript pause;
    private LevelManager levelManager;
    [SerializeField] private Animator anim;
    public float timer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pause = GameObject.Find("Managers").GetComponent<PauseScript>();
        levelManager = GameObject.Find("Managers").GetComponent<LevelManager>();
        if (thisPortalIsChangingLevel)
        {
            anim.enabled = false;
        }
    }
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (pause.characterMenuOn == false) player = GameObject.FindGameObjectWithTag("Player");
        if (pause.characterMenuOn) player = null; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (thisPortalIsChangingLevel)
                levelManager.SelectLevel(nextSceneName);

            if (!thisPortalIsChangingLevel && !thisPortalIsStartingLevel && timer <= 0) 
            {
                Vector2 pos = new Vector2(secondPortal.transform.position.x, secondPortal.transform.position.y);
                player.transform.position = pos ;
                secondPortal.GetComponent<Portal>().timer = 0.3f;
            }
        }
    }
}
