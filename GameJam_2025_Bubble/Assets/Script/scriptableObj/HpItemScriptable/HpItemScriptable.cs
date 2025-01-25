using UnityEngine;

[CreateAssetMenu(fileName = "HealItem", menuName = "ScriptableObjects/HealItem")]
public class HpItemScriptable : ScriptableObject
{
    public string Name;
    public float HpPoint;
}
