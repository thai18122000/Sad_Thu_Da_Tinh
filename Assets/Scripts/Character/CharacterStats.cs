using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour{
    #region Declare Variable
    [SerializeField] protected int currentHealth;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected bool isDead;
    #endregion

    void Start(){
        InitVariables();
    }
    public virtual void HealthCheck(){
        if(currentHealth <= 0){
            currentHealth = 0;
            Die();
        }
        if(currentHealth >= maxHealth){
            currentHealth = maxHealth;
        }
    }

    public void Die(){
        isDead = true;
    }

    private void SetHealthTo(int healthToSet){
        currentHealth = healthToSet;
        HealthCheck();
    }

    public void TakeDamage(int damage){
        int healthAfterDamage = currentHealth - damage;
        SetHealthTo(healthAfterDamage);
    }

    public void Heal(int heal){
        int healthAfterHeal = currentHealth + heal;
        SetHealthTo(healthAfterHeal);
    }

    public void InitVariables(){
        maxHealth = 100;
        SetHealthTo(maxHealth);
        isDead = false;
    }
}
