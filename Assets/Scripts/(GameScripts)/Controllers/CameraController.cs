using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    [SerializeField] private Vector3 TargetOffset;
    [SerializeField] private float cameraMovementSpeed;
    [SerializeField] public Transform target;
    private OperationCenter opc;
    private GameObject cameraCenterPoint;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cameraCenterPoint = GameObject.Find("CameraCenterPoint");
        opc = GameObject.Find("OperationCenter").GetComponent<OperationCenter>();
    }
    void Update()
    {
        MoveCamera();
    }
    private void FixedUpdate()
    {
        if (Time.timeScale == 1f && target == null)
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        else if(target == null)
            target = GameObject.Find("OperationCenter").transform;
        cameraCenterPoint.transform.position = target.position;
    }
    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, cameraCenterPoint.transform.position + TargetOffset, cameraMovementSpeed * Time.deltaTime);
    }
}
