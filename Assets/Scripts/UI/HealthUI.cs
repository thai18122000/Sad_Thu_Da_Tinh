using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour{
    #region Declare Variable
    private int currentHealth_UI;
    private int maxHealth_UI;
    [SerializeField] private Image fill;
    [SerializeField] private TextMeshProUGUI currentHealthText;
    #endregion

    public void SetHealthValue(int currentHealth, int maxHealth){
        currentHealth_UI = currentHealth;
        maxHealth_UI = maxHealth;
        CaculateFillAmount();
        currentHealthText.text = currentHealth_UI.ToString();
    }

    public void CaculateFillAmount(){
        float fillAmount = (float)currentHealth_UI/maxHealth_UI;
        fill.fillAmount = fillAmount;
    }
}
