using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject {
    #region Declare Variable
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;
    #endregion

    public virtual void Use(){
               
    }
}
