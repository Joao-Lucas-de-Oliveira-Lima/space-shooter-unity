using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BarsController : MonoBehaviour
{
    public Slider lifeBar;
    public Slider energyBar;
    public Slider shieldBar;

    // Life Controllers Functions

    public void setMaxLifeValue(int value){
        if(lifeBar == null) {return;}
        lifeBar.maxValue = value;
    }

    public void setLifeValue(int value){
        if(lifeBar == null) {return;}
        lifeBar.value = value;
    }

    // Energy Controllers Functions

    public void setMaxEnergyValue(int value){
        if(energyBar == null) {return;}
        energyBar.maxValue = value;
    }

    public void setEnergyValue(int value){
        if(energyBar == null) {return;}
        energyBar.value = value;
    }

    // Shields Controllers Functions

    public void setMaxShieldValue(int value){
        if(shieldBar == null) {return;}
        shieldBar.maxValue = value;
    }

    public void setShieldValue(int value){
        if(shieldBar == null) {return;}
        shieldBar.value = value;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
