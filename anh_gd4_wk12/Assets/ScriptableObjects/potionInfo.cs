using UnityEngine;

[CreateAssetMenu(fileName = "potionInfo", menuName = "Scriptable Objects/potionInfo")]
public class potionInfo : ScriptableObject
{
    public string potionName;
    public string potionDescription;

    public Sprite potionSprite;
    public Color potionColor;

    public bool isBoon;
}
