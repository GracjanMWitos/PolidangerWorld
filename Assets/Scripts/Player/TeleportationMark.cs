using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationMark : MonoBehaviour
{
    private void Update()
    {
        Vector3 offset = new Vector3(0, 0, 10);
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }
}
