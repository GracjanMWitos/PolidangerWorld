using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowLenght : MonoBehaviour
{
    GameObject cameraCenter;
    float y;
        void Start()
    {
        cameraCenter = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        y = Vector2.Distance(cameraCenter.transform.position, Camera.main.WorldToScreenPoint(Input.mousePosition));
        transform.position = new Vector2 (0,y);
        transform.localScale = new Vector3 (1,y * 2,1);
    }
}
