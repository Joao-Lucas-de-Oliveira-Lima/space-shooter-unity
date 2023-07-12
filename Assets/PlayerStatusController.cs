using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStateController : MonoBehaviour
{
    
    public BarsController barsControllers;

    public int maxLife = 400;
    public int maxEnergy = 400;
    public int maxShield = 500;

    public float shieldRecoverTime = 5f;
    public float shieldRecoverDelay = 1f;
    public int shieldRecoverAmount = 20;

    public float energyRecoverDelay = 8f;
    public int energyRecoverAmount = 100;

    private int life;
    private int energy;
    private int shield;

    private float shieldRecoverTimer;
    private float shieldDelayTimer;
    private float energyDelayTimer;

    public float delayScene = 1.0f;
    public bool defeatedPlayer = false;

    // Propriedades públicas para acesso aos valores
    public int Life
    {
        get { return life; }
        set { life = Mathf.Clamp(value, 0, maxLife); }
    }

    public int Energy
    {
        get { return energy; }
        set { energy = Mathf.Clamp(value, 0, maxEnergy); }
    }

    public int Shield
    {
        get { return shield; }
        set { shield = Mathf.Clamp(value, 0, maxShield); }
    }

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

    private void Start()
    {
        // Inicializa os valores com 400
        life = maxLife;
        energy = maxEnergy;
        shield = maxShield;
        shieldRecoverTimer = shieldRecoverTime;
        shieldDelayTimer = shieldRecoverDelay;
        energyDelayTimer = energyRecoverDelay;
        
        barsControllers.setMaxLifeValue(maxLife);
        barsControllers.setMaxEnergyValue(maxEnergy);
        barsControllers.setMaxShieldValue(maxShield);  

        updateLifeUI();
        updateEnergyUI();
        updateShieldUI();
    }

    private void Update()
    {
        // Lógica de recuperação do escudo e energia
        shieldRecoverUpdate(Time.deltaTime);
        EnergyRecoverUpdate(Time.deltaTime);
    }

    private void shieldRecoverUpdate(float deltaTime)
    {
        if (Shield >= maxShield)
        {
            // Se o escudo já está no máximo, interrompe a função
            return;
        }

        shieldRecoverTimer -= deltaTime;

        if (shieldRecoverTimer <= 0f)
        {
            shieldDelayTimer -= deltaTime;

            if (shieldDelayTimer <= 0f)
            {
                Shield += shieldRecoverAmount;
                shieldDelayTimer = shieldRecoverDelay;
            }
        }

        // Garante que o escudo não ultrapasse o valor máximo
        Shield = (Shield > maxShield) ? maxShield : Shield;
        updateShieldUI();
    }

    public void takeDamage(int damage)
    {
        if (shield > 0)
        {
            Shield = (damage <= shield) ? shield - damage : 0;
            Life -= (damage > shield) ? damage - shield : 0;
        }
        else
        {
            Life -= damage;
            if( Life <= 0 && !defeatedPlayer)
            {
                defeatedPlayer = true;
                if (defeatedPlayer)
                {
                    Instantiate(Resources.Load("Effects/ExplosionAnimation") as GameObject, this.transform.position, Quaternion.identity);
                    AudioController.PlaySound("Explosion");
                    Destroy(this.gameObject);
                    
                }
                
                
            }
        }

        updateShieldUI();
        updateLifeUI();

        // Reinicia o timer de recuperação ao receber dano
        shieldRecoverTimer = shieldRecoverTime;
    }

     public void useEnergy(int valor){
        if(valor > energy){ return ;}
        Energy -= valor;
        updateEnergyUI();
    }

    private void EnergyRecoverUpdate(float deltaTime)
    {
        if (Energy >= maxEnergy)
        {
            // Se a energia já está no máximo, interrompe a função
            return;
        }

        energyDelayTimer -= deltaTime;

        if (energyDelayTimer <= 0f)
        {
            Energy += energyRecoverAmount;
            energyDelayTimer = energyRecoverDelay;
        }
         // Garante que a energia não ultrapasse o valor máximo
        Energy = (Energy > maxEnergy) ? maxEnergy : Energy;
        updateEnergyUI();
    }
    
}

