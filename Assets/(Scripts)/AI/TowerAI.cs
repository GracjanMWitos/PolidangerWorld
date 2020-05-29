using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour
{
    private PlayerControler playerPos;
    private CameraController cameraController;

    private void Start()
    {
        cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }
    void Update()
    {
        cameraController.LockAtObjectChange();

        Vector3 dir = cameraController.target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg -90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
