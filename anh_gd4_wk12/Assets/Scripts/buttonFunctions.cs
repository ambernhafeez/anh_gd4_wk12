using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonFunctions : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject gameOverScreen;
    public GameObject cardOverlay;
    public GameObject winOverlay;

    GameObject uiDisplayed;
    Button aButton;
    Button bButton;
    public playerStats PlayerStatsScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // first display start menu
        uiDisplayed = startMenu;
        SetUIActive();

        PlayerStatsScript = FindFirstObjectByType<playerStats>().GetComponent<playerStats>();

        GetCurrentButtons();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCurrentButtons()
    {
        // find all the buttons in the public uiDisplayed gameobject
        Button[] buttons = uiDisplayed.GetComponentsInChildren<Button>(true);

        // assign a and b buttons
        foreach (Button button in buttons)
        {
            if (button.gameObject.name == "aButton")
            {
                Debug.Log("assigned a button");
                aButton = button;
            }
            else if (button.gameObject.name == "bButton")
            {
                bButton = button;
            }
        }
    }

    // assigned to the menu buttons
    public void ResumeGame()
    {
        Time.timeScale = 1;
        uiDisplayed.SetActive(false);
    }

    // execute onClick events assigned to the aButton if a UI overlay which pauses the game is displayed
    public void Aselect()
    {
        if (Time.timeScale == 0)
        {
            aButton.onClick.Invoke();
        }
    }

    public void Bselect()
    {
        if (Time.timeScale == 0)
        {
            bButton.onClick.Invoke();
        }
    }

    // function which is checks current scriptable object and it is used
    // use button will always change player stats based on current scriptable object
    public void ChangePlayerStats()
    {
        potionInfo currentPotion = PlayerStatsScript.thePotionInfo;
        Debug.Log(currentPotion.name);
        PlayerStatsScript.HealthChange(currentPotion.healthChange);
        PlayerStatsScript.StaminaChange(currentPotion.staminaChange);
        PlayerStatsScript.CountPotions();
        Destroy(PlayerStatsScript.potionObject);
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        //uiDisplayed.SetActive(false);
    }

    public void SetUIActive()
    {
        uiDisplayed.SetActive(true);
        Time.timeScale = 0;
    }

    public void ChangeCurrentUI(GameObject uiOverlay)
    {
        uiDisplayed = uiOverlay;
        GetCurrentButtons();
        SetUIActive();
    }
    
    public void ActivateMenu()
    {
        RestartGame();
    }

}
