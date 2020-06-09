using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    [SerializeField] private Vector3 TargetOffset;
    [SerializeField] private float cameraMovementSpeed;
    [SerializeField] public Transform target;
    [SerializeField] private Transform operationCenterPos;
    private PauseScript pause;
    private GameObject cameraCenterPoint;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cameraCenterPoint = GameObject.Find("CameraCenterPoint");
        pause = GameObject.Find("Menagers").GetComponent<PauseScript>();
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
        if (pause.characterMenuOn == false)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            cameraCenterPoint.transform.position = target.position;
        }
        if (pause.characterMenuOn)
        {
            target = GameObject.Find("OperationCenter").GetComponent<Transform>();
            cameraCenterPoint.transform.position = target.position;

        }
    }
}
