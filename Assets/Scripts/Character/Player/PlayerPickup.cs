using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour{
    #region Declare Variable
    [SerializeField] private float pickupRange;
    [SerializeField] private LayerMask pickupLayer;
    private Camera cam;
    private Equipment equipment;
    #endregion

    void Start()
    {
        GetReferences();
    }
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, pickupRange, pickupLayer)){   
                hit.transform.gameObject.SetActive(false);
                equipment.AddWeapon(hit.transform.gameObject);
            }
        }
    }

    private void GetReferences(){
        cam = GetComponentInChildren<Camera>();
        equipment = GetComponent<Equipment>();
    }
}
