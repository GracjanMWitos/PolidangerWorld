using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    [SerializeField] private Vector3 TargetOffset;
    [SerializeField] private float cameraMovementSpeed;
    [SerializeField] public Transform target;
    [SerializeField] private Vector2 operationCenterPos;
    [SerializeField] private PauseScript canvasActivity;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        canvasActivity = GameObject.Find("Menagers").GetComponent<PauseScript>();
    }

    void Update()
    {
        LockAtObjectChange();
        MoveCamera();
    }

    void MoveCamera()
    {

        transform.position = Vector3.Lerp(transform.position, target.position - TargetOffset, cameraMovementSpeed * Time.deltaTime);
    }
    public void LockAtObjectChange()
    {
        if (canvasActivity.characterMenuOn == false)
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (canvasActivity.characterMenuOn == true)
            target = GameObject.Find("OperationCenter").GetComponent<Transform>();
    }
}
