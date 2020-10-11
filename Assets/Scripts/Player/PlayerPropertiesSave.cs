using UnityEngine;
[CreateAssetMenu(fileName = "new player save", menuName = "Player save")]
public class PlayerPropertiesSave : ScriptableObject
{
    [SerializeField]
    float forceMultiply;
    [SerializeField]
    float coeff;
    [SerializeField]
    int maxHealth;
    [SerializeField]
    int currentHealth;
    public float ForceMultiply => forceMultiply;
    public float Coeff => coeff;
    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;
}
