using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Item/Weapon")]
    
public class Weapon : Item{
    #region Declare Variable
    public GameObject weaponPosition;
    public GameObject weaponPrefab;
    public GameObject muzzleFlash;
    public int magazineSize;
    public int maxAmmo;
    public float fireRate;
    public bool autoMode;
    public float range;
    public WeaponType weaponType;
    public WeaponSlot weaponSlot;
    #endregion
}

public enum WeaponType{ Melee, Pistol, AR, Shotgun, Sniper}
public enum WeaponSlot{ Primary, Secondary, Melee}
