﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    [Header("Basic Weapon")]
    public int damage;
    public float armorPiercing; // between 0 and 1, 1 means full piercing, 0 means no armor piercing - implement later
    public GameObject model; //grafic Model of the weapon
    //later min nad max Damage
    public bool oneHanded = true; //for later bow and crossbow are 2 handed , one handed allow a shield equipped // double daggers will be 2 handed as one weapon

    void DrawWeapon()
    {

    }

    void HideWeapon()
    {

    }

}
