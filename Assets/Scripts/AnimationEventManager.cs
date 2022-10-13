using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour{
    #region Declare Variable
    private Equipment equipment;
    #endregion

    private void Start(){
        GetReferences();
    }

    private void GetReferences(){
        equipment = GetComponentInParent<Equipment>();
    }

    //Call in Model Animation events
    public void DisableWeapon(){
        Debug.Log("wp Disable: "+ equipment.previousWeapon.name + " Time: " +Time.time);
        equipment.previousWeapon.SetActive(false);
        equipment.DropWeapon(equipment.tempWeapon, equipment.isDrop);
        equipment.isDrop = false;
    }

    //Call in Model Animation events
    public void EnableWeapon(){
        Debug.Log("wp Enable: "+ equipment.newWeapon.name + " Time: " +Time.time);
        equipment.newWeapon.SetActive(true);
    }
}
