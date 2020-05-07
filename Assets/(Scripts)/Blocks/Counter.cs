using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] pessimismBlocks;
        pessimismBlocks = GameObject.FindGameObjectsWithTag("PessimismBlock");
        if (pessimismBlocks.Length == 0)
        {
            Destroy(GameObject.Find("FirstPack"));
            Enemy.SetActive(true);
        }
    }
}
