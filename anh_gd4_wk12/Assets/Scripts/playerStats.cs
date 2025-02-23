using System;
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
    public buttonFunctions buttonScript;

    public GameObject gameOverUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 10;
        stamina = 10;
        potionCount = 0;
        gameOver = false;
        
        healthBar.fillAmount = health/healthMax;
        staminaBar.fillAmount = stamina/staminaMax;
        potionDisplayScript = FindFirstObjectByType<potionDisplay>().GetComponent<potionDisplay>();
        playerAttackScript = GetComponentInChildren<playerAttack>();
        buttonScript = FindFirstObjectByType<buttonFunctions>().GetComponent<buttonFunctions>();

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
            GameOverBehaviour();
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
            Debug.Log("Game Over!!");
            GameOverBehaviour();
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
            buttonScript.ChangeCurrentUI(buttonScript.cardOverlay);
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

        if (potionCount >= 16)
        {
            buttonScript.ChangeCurrentUI(buttonScript.winOverlay);
        } 
    }

    public void GameOverBehaviour()
    {
        // go into gameoverscreenmanager and call the SetUIActive function inside the buttonFunctions.cs script
        Debug.Log("gameover function called");

        buttonScript.ChangeCurrentUI(buttonScript.gameOverScreen);
    }
}
