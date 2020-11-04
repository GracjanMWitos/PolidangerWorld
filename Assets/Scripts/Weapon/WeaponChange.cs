using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    [Header("WeaponPosition")]
    [SerializeField] private bool leftHeadWeapon;
    [SerializeField] private bool rightHeadWeapon;
    [SerializeField] private bool SpecialWeapon;
    [Header("Weapons")]
    [SerializeField] private bool minigun;
    [SerializeField] private bool shotgun;
    [SerializeField] private bool uzi;
    [Header("Barrels")]
    [SerializeField] private Transform barrel1 = null;
    [SerializeField] private Transform barrel2 = null;
    [SerializeField] private Transform barrel3 = null;
    private WeaponMenager weaponMenager;
    private float timer;
    void Start()
    {
        weaponMenager = GameObject.Find("Menagers").GetComponent<WeaponMenager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (SpecialWeapon)
        {

        }
        else if (leftHeadWeapon)
        {
            if (minigun)
            {
                weaponMenager.Minigun(timer, barrel1,barrel2,barrel3,leftHeadWeapon,rightHeadWeapon);
            }
        }
        else if (rightHeadWeapon)
        {
            if (minigun)
            {
                weaponMenager.Minigun(timer, barrel1, barrel2, barrel3, leftHeadWeapon, rightHeadWeapon);
            }
        }
    }
}
