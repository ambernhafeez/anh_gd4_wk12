using UnityEngine;

public class potionBehaviour : MonoBehaviour
{
    public potionInfo thePotionInfo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SpriteRenderer>().color = GetPotionColor(thePotionInfo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Color GetPotionColor(potionInfo stats)
    {
        return stats.potionColor;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("collided with player");

            // display card
        }
    }
}
