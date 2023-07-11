using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public BarsController barsControllers;
    // Start is called before the first frame update

    public int maxLife = 120;
    public int maxEnergy = 200;
    public int maxShield = 120;

    public int life = 60;
    public int energy = 50;
    public int shield = 50;

    public void SetBarsControllers(BarsController barsControllers)
    {
        this.barsControllers = barsControllers;
    }

    public void updateLifeUI(){
        barsControllers.setLifeValue(life);
    }

    public void updateEnergyUI(){
        barsControllers.setEnergyValue(energy);
    }

    public void updateShieldUI(){
        barsControllers.setShieldValue(shield);   
    }

    void Start()
    {
        barsControllers.setMaxLifeValue(maxLife);
        barsControllers.setMaxEnergyValue(maxEnergy);
        barsControllers.setMaxShieldValue(maxShield);  

        updateLifeUI();
        updateEnergyUI();
        updateShieldUI();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
