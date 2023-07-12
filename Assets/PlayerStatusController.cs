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
    public int maxShield = 400;
    public float recoverTime = 5f;
    public float recoverDelay = 1f;
    public int shieldIncreasePerDelay = 20;

    private int life;
    private int energy;
    private int shield;
    private float recoverTimer;
    private float delayTimer;

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
        recoverTimer = recoverTime;
        delayTimer = recoverDelay;
        
        barsControllers.setMaxLifeValue(maxLife);
        barsControllers.setMaxEnergyValue(maxEnergy);
        barsControllers.setMaxShieldValue(maxShield);  

        updateLifeUI();
        updateEnergyUI();
        updateShieldUI();
    }

    private void Update()
    {
        // Lógica de recuperação do escudo
        RecoverUpdate(Time.deltaTime);
    }

    private void RecoverUpdate(float deltaTime)
    {
        if (Shield >= maxShield)
        {
            // Se o escudo já está no máximo, interrompe a função
            return;
        }

        recoverTimer -= deltaTime;

        if (recoverTimer <= 0f)
        {
            delayTimer -= deltaTime;

            if (delayTimer <= 0f)
            {
                Shield += shieldIncreasePerDelay;
                delayTimer = recoverDelay;
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
                    StartCoroutine(ChangeSceneWithDelay(delayScene));
                }
                
                
            }
        }

        updateShieldUI();
        updateLifeUI();

        // Reinicia o timer de recuperação ao receber dano
        recoverTimer = recoverTime;
    }
    IEnumerator ChangeSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver"); // Substitua "NomeDaCena" pelo nome da cena que você deseja carregar
    }
}

