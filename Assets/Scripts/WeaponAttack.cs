using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour{
    #region Declare Variable
    private Camera cam;
    private Equipment equipment;
    private float lastShootTime = 0;
    #endregion

    private void Start(){
        GetReferences();
    }

    private void Update(){
        if(Input.GetKey(KeyCode.Mouse0)){
            Attack();
        }
    }

    private void GetReferences(){
        cam = GetComponentInChildren<Camera>();
        equipment = GetComponent<Equipment>();
    }

    private void RayCastAttack(Weapon currentWeapon){
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2));
        RaycastHit hit;
        float currentWeaponRange = currentWeapon.range;
        if(Physics.Raycast(ray, out hit, currentWeaponRange)){
            // Debug.Log(hit.transform.name);
        }
        if(currentWeapon.muzzleFlash != null){
            Instantiate(currentWeapon.muzzleFlash, equipment.currentWeaponBarrel);
        }
    }

    private void Attack(){
        GameObject currentWeaponObject = equipment.GetWeaponObject(equipment.newWeaponSlot);
        Weapon currentWeapon = currentWeaponObject.GetComponent<WeaponDetail>().weapon;
        if(currentWeapon.muzzleFlash != null){
            equipment.currentWeaponBarrel = currentWeaponObject.transform.GetChild(0);
        }        
        if(Time.time > lastShootTime + currentWeapon.fireRate){
            // Debug.Log("Shoot");
            lastShootTime = Time.time;

            RayCastAttack(currentWeapon);
        }
    }

}
