using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    [SerializeField] private Vector3 TargetOffset;
    [SerializeField] private float cameraMovementSpeed;
    [SerializeField] private Transform target;


    void Start()
    {

        
    }

    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, target.position - TargetOffset, cameraMovementSpeed * Time.deltaTime);
    }
}
