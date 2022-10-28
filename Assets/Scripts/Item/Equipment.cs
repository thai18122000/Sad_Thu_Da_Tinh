using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour{
    #region Declare Variable
    // 0 = Primary weapon| 1 = Secondary weapon| 2 = Melee weapon
    [SerializeField] private GameObject[] weaponObjects;
    [SerializeField] public GameObject defaultMeleeWeapon;
    [HideInInspector] public Transform currentWeaponBarrel;
    public Transform cam, weaponHolderR;    
    private PlayerHUD hud;
    private Animator anim;
    public float dropForwardForce, dropUpwardForce;
        #region 1 đống biến phải dùng do sự ngoo ngốc chưa biết tối ưu code :(
        public GameObject tempWeapon;
        public GameObject previousWeapon = null;
        public GameObject newWeapon;
        public int previousWeaponSlot;
        public int newWeaponSlot;
        #endregion
    [HideInInspector] public bool isDrop = false;
    #endregion

    private void Start(){
        GetReferences();
        InitVariables();

        InstantiateWeapon();     
    }

    private void Update(){
        // Get weapon slot 0
        SwapToSlot(0, KeyCode.Alpha1);
        // Get weapon slot 1
        SwapToSlot(1, KeyCode.Alpha2);
        // Get weapon slot 2
        SwapToSlot(2, KeyCode.Alpha3);

        // Drop Weapon
        if(Input.GetKeyDown(KeyCode.Q) && newWeaponSlot != 2){            
            ChangeWeapon(defaultMeleeWeapon);
            ChangeSlot(2);
            UnEquipWeapon();
            RemoveWeapon(previousWeaponSlot);
            tempWeapon = previousWeapon;
            isDrop = true;
            EquipWeapon(defaultMeleeWeapon);
        }
    }

    private void InitVariables(){
        weaponObjects = new GameObject[3]; 
        newWeapon = defaultMeleeWeapon;
        newWeaponSlot = 2;
    }
    private void GetReferences(){
        hud = GetComponent<PlayerHUD>();
        anim = GetComponentInChildren<Animator>();
    }
    public void InstantiateWeapon(){
        weaponObjects[newWeaponSlot] = newWeapon;  
        EquipWeapon(newWeapon); 
        SetWeaponOnHand(newWeapon);
    }
    
    public void AddWeapon(GameObject newWeaponObject){  
        ChangeWeapon(newWeaponObject);
        ChangeSlot(GetWeaponSlot(newWeaponObject));
        UnEquipWeapon();  
        // Debug.Log("previous weapon: "+ previousWeapon + " Time:" + Time.time);
        // Debug.Log("current weapon: "+ newWeapon + " Time:" + Time.time);        

        //Drop weapon ở slot của new weapon nếu có, đấy là tempWeapon :v
        if(GetWeaponObject(newWeaponSlot) != null){ 
            tempWeapon = GetWeaponObject(newWeaponSlot);          
            isDrop = true;
        }   

        EquipWeapon(newWeaponObject);
        SetWeaponOnHand(newWeaponObject);            
        weaponObjects[newWeaponSlot] = newWeaponObject;       
    }    
    public void EquipWeapon(GameObject weaponObject){
        WeaponDetail weaponDetail = GetWeaponDetail(weaponObject);   
            
        anim.SetInteger("WeaponType", (int)weaponDetail.weapon.weaponType);   
        hud.UpdateWeapon(weaponDetail.weapon.itemIcon, weaponDetail.currentAmmo, weaponDetail.storedAmmo);     
    }   
    public void UnEquipWeapon(){
        anim.SetTrigger("UnEquip");        
    }
    public void DropWeapon(GameObject weaponToDrop, bool isDrop){
        if(isDrop == true){
            weaponToDrop.transform.parent = null;
            weaponToDrop.SetActive(true);

            // Make Rigidbody not kinematic and BoxCollider normal
            Rigidbody rb = weaponToDrop.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            weaponToDrop.GetComponent<BoxCollider>().enabled = true;            

            // Gun carries momentum of player
            rb.velocity = GetComponent<Rigidbody>().velocity;

            //AddForce
            rb.AddForce(cam.forward * dropForwardForce, ForceMode.Impulse);
            rb.AddForce(cam.up * dropUpwardForce, ForceMode.Impulse);

            // Add random rotation
            float random = Random.Range(-1f, 1f);
            rb.AddTorque(new Vector3(random, random, random) * 10);
            
            // Debug.Log("Drop time: "+ Time.time);
        }         
    }
    public void SwapToSlot(int slot, KeyCode key){
        if(Input.GetKeyDown(key) && newWeaponSlot != slot  && GetWeaponObject(slot) != null){
            UnEquipWeapon();
            EquipWeapon(GetWeaponObject(slot));

            ChangeWeapon(GetWeaponObject(slot));
            ChangeSlot(slot);
        }
    }

    #region  Built-in Function
    public GameObject GetWeaponObject(int index){
        return weaponObjects[index];
    }
    public void RemoveWeapon(int index){
        weaponObjects[index] = null;
    }
    public void SetWeaponOnHand(GameObject weaponToSet){
        Weapon weapon = GetWeapon(weaponToSet);

        weaponToSet.transform.position = weapon.weaponPosition.transform.position;
        weaponToSet.transform.rotation = weapon.weaponPosition.transform.rotation;
        weaponToSet.transform.SetParent(weaponHolderR, false);// Set false to advoid keeping world position    
        weaponToSet.GetComponent<BoxCollider>().enabled = false;// Set false to advoid raycast
        Rigidbody rb = weaponToSet.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = false;
    }
    public WeaponDetail GetWeaponDetail(GameObject gameObject){
        return gameObject.GetComponent<WeaponDetail>();
    }
    public Weapon GetWeapon(GameObject gameObject){
        return gameObject.GetComponent<WeaponDetail>().weapon;
    }
    public int GetWeaponSlot(GameObject gameObject){
        return (int)GetWeapon(gameObject).weaponSlot;
    }
    public void ChangeWeapon(GameObject weapon){
        previousWeapon = newWeapon;
        newWeapon = weapon;
    }
    public void ChangeSlot(int slot){
        previousWeaponSlot = newWeaponSlot;
        newWeaponSlot = slot;
    }
    #endregion
}
