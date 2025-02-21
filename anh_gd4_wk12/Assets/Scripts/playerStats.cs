using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerStats : MonoBehaviour
{

    public float health = 10.0f;
    public float stamina = 10.0f;
    public int potionCount = 0;

    public bool gameOver = false;

    public Image healthBar;
    public Image staminaBar;
    public TMP_Text potionCountText;

    float healthMax = 20f;
    float staminaMax = 20f;

    public potionInfo thePotionInfo;
    public potionDisplay potionDisplayScript;
    public GameObject potionObject;

    public playerAttack playerAttackScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.fillAmount = health/healthMax;
        staminaBar.fillAmount = stamina/staminaMax;
        potionDisplayScript = FindFirstObjectByType<potionDisplay>().GetComponent<potionDisplay>();
        playerAttackScript = GetComponentInChildren<playerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealthChange(float healthChange)
    {
        if (health > 0)
        {
            health += healthChange;
            healthBar.fillAmount = health/healthMax;
        }
        else
        {
            gameOver = true;
            Debug.Log("Game Over!!");
        }
        
    }

    public void StaminaChange(float staminaChange)
    {
        if (stamina >= 0)
        {
            stamina += staminaChange;
            staminaBar.fillAmount = stamina/staminaMax;
        }
        else
        {
            gameOver = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<potionBehaviour>() != null && playerAttackScript.attackBox.enabled == false)
        {
            potionBehaviour potionBehaviourScript = other.GetComponent<potionBehaviour>();

            potionObject = other.gameObject; 

            thePotionInfo = potionBehaviourScript.thePotionInfo;

            Debug.Log("collided with potion");

            // display card
            potionDisplayScript.ShowPotionCard(thePotionInfo);
            // pause game
            Time.timeScale = 0;

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<enemyController>() != null)
        {
            HealthChange(-5);
        }
    }

    public void CountPotions()
    {
        potionCount ++;
        potionCountText.text = "" + potionCount;
    }

}
