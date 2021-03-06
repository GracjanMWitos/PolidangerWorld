﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMenager : MonoBehaviour
{

    [Header("Minigun")]
    [SerializeField] public float minigun_fireRate;
    [SerializeField] private Rigidbody2D minigunBullet;
    [Header("Shotgun")]
    [SerializeField] private float shotgun_fireRate;
    [SerializeField] private Rigidbody2D shotgunBullet;
    private InputKey input;
    private void Start()
    {
        input = this.gameObject.GetComponent<InputKey>();
    }
    void Shoting(float fireRate, Transform barrel1, Transform barrel2, Transform barrel3, bool leftWeapon, bool rightWeapon)
    {
        float timer = 3;
        float timeBetweenShot = 1 / fireRate;
        if (timer > 0) timer -= Time.deltaTime;
        if (leftWeapon)
        {
            if (input.leftWeaponShoting && timer <= 0)
            {
                timer += 5;
                //audioSource.PlayOneShot(gunShot);
                Rigidbody2D bulletShot1 = Instantiate(minigunBullet, barrel1.position, barrel1.rotation);
                
                
            }
            if (Input.GetKeyUp(KeyCode.Mouse0) && timer <= 0) timer = timeBetweenShot;
        }
        if (rightWeapon)
        {
            if (input.rightWeaponShoting && timer <= 0)
            {
                //audioSource.PlayOneShot(gunShot);
                Rigidbody2D bulletShot1 = Instantiate(minigunBullet, barrel1.position, barrel1.rotation);
                timer += 5;
            }
            if (Input.GetKeyUp(KeyCode.Mouse1) && timer <= 0) timer = timeBetweenShot;
        }
    }
    public void Minigun(Transform barrel, bool leftWeapon, bool rightWeapon)
    {
        Shoting(minigun_fireRate, null, null, null, leftWeapon, rightWeapon);
    }
}
