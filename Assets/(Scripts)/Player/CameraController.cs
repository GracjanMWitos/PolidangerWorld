using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    [SerializeField] private Vector3 TargetOffset;
    [SerializeField] private float cameraMovementSpeed;
    [SerializeField] private Vector2 target;
    private OperationCenter opc;
    private GameObject cameraCenterPoint;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        cameraCenterPoint = GameObject.Find("CameraCenterPoint");
        opc = GameObject.Find("OperationCenter").GetComponent<OperationCenter>();
    }
    void Update()
    {
        MoveCamera();
    }
    private void FixedUpdate()
    {
        LockAtObjectChange();
    }
    void MoveCamera()
    {

        transform.position = Vector3.Lerp(transform.position, cameraCenterPoint.transform.position - TargetOffset, cameraMovementSpeed * Time.deltaTime);
    }
    public void LockAtObjectChange()
    {
        if (!opc.charactersMenuStarted)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
            cameraCenterPoint.transform.position = target;
        }
        if (opc.charactersMenuStarted)
        {
            target = GameObject.Find("OperationCenter").GetComponent<Transform>().position;
            cameraCenterPoint.transform.position = target;

        }
    }
}
