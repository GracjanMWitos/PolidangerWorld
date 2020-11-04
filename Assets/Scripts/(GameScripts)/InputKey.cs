using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKey : MonoBehaviour
{
    public bool leftWeaponShoting;
    public bool rightWeaponShoting;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) leftWeaponShoting = true;
        if (Input.GetKeyUp(KeyCode.Mouse0)) leftWeaponShoting = false;
        if (Input.GetKey(KeyCode.Mouse1)) rightWeaponShoting = true;
        if (Input.GetKeyUp(KeyCode.Mouse1)) rightWeaponShoting = false;
    }
}
