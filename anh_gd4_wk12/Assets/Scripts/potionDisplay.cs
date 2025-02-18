using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class potionDisplay : MonoBehaviour
{

    public GameObject potionCard;

    public TMP_Text _potionName, _potionDescription, _isBoon;
    public Image artwork;

    public Color _potionColor;


    public void ShowPotionCard(potionInfo stats)
    {
        potionCard.SetActive(true);
        _potionName.text = "A potion of " + stats.potionName;
        _potionDescription.text = stats.potionDescription;
        artwork.sprite = stats.potionSprite;
        artwork.sprite.GetComponent<SpriteRenderer>().color = stats.potionColor;
        
        if (stats.isBoon)
        {
            _isBoon.text = "You have a good feeling about this potion.";
        }
        else 
        {
            _isBoon.text = "The scent of this potion invokes a sense of unease.";
        }
        
    }
}

