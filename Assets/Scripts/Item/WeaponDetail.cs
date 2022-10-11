using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDetail : MonoBehaviour{
    #region Declare Variable
    [SerializeField] public Weapon weapon;
    public int currentAmmo;  
    public int storedAmmo;   
    #endregion

    public void Start(){
        InitVariables();
    }

    public void InitVariables(){
        currentAmmo = weapon.magazineSize;
        storedAmmo = weapon.maxAmmo;
    } 
}
