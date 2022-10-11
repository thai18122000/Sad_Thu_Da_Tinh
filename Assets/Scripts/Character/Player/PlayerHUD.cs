using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUD : MonoBehaviour{
    #region Declare Variable
    [SerializeField] public HealthUI healthUI;
    [SerializeField] public WeaponUI weaponUI;
    #endregion

    public void UpdateHealth(int currentHealth, int maxHealth){
        healthUI.SetHealthValue(currentHealth, maxHealth);
    }

    public void UpdateWeapon(Sprite icon, int currentAmmo, int storedAmmo){
        weaponUI.SetAmmoValue(currentAmmo, storedAmmo);
        weaponUI.SetWeaponIcon(icon);
    }
}
