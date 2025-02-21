using UnityEngine;

public class potionBehaviour : MonoBehaviour
{
    public potionInfo thePotionInfo;
    potionDisplay potionDisplayScript;
    public GameObject UImanager;
    //public playerStats playerStatsScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SpriteRenderer>().color = GetPotionColor(thePotionInfo);
        potionDisplayScript = UImanager.GetComponent<potionDisplay>();
        //playerStatsScript = FindFirstObjectByType<playerStats>().GetComponent<playerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Color GetPotionColor(potionInfo stats)
    {
        return stats.potionColor;
    }

}
