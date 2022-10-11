using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats{
    #region Declare Variable
    private PlayerHUD hud;
    #endregion
    
    void Start(){
        GetReferences();
        InitVariables();
    }

    private void GetReferences(){
        hud = GetComponent<PlayerHUD>();
    }

    public override void HealthCheck(){
        base.HealthCheck();
        hud.UpdateHealth(currentHealth, maxHealth);
    }

    public void Update(){
        if(Input.GetKeyDown(KeyCode.T)){
            TakeDamage(10);
        }
    }
}
