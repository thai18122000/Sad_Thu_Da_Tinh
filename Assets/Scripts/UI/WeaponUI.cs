using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponUI : MonoBehaviour{
    #region Declare Variable
    [SerializeField] private Image weaponIcon;
    [SerializeField] private TextMeshProUGUI currentAmmoText;
    [SerializeField] private TextMeshProUGUI storedAmmoText;
    #endregion

    public void SetAmmoValue(int currentAmmo, int storedAmmo){
        currentAmmoText.text = currentAmmo.ToString();
        storedAmmoText.text = storedAmmo.ToString();
    }

    public void SetWeaponIcon(Sprite icon){
        weaponIcon.sprite = icon;
    }
}
