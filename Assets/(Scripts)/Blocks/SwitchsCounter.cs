using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SwitchsCounter : MonoBehaviour
{
    private ScoreMenager score;
    [SerializeField] ushort switchesToOpen;
    [SerializeField] private bool toActiveObject;
    [SerializeField] private bool toDisactiveObject;
    [SerializeField] private GameObject go;
    void Start()
    {
        score = GameObject.Find("Menagers").GetComponent<ScoreMenager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(score.switchesTurnedOn == switchesToOpen)
        {
            if (toActiveObject)
                go.SetActive(true);
            else if (toDisactiveObject)
                go.SetActive(false);
            else Destroy(go);
        }
    }
}
