using System;
using UnityEngine;

public class PlayerProperties
{
    public Action<int> HealthChanged;
    public float ForceMultiply { get; private set; }
    public float Coeff { get; private set; }
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    public PlayerProperties(PlayerPropertiesSave save)
    {
        ForceMultiply = save.ForceMultiply;
        Coeff = save.Coeff;
        MaxHealth = save.MaxHealth;
        CurrentHealth = save.CurrentHealth;
    }
    public void ChangeHealth(int amount)
    {
        if (amount > 0)
        {
            CurrentHealth = Math.Min(MaxHealth, CurrentHealth + amount);
        }
        else
        {
            CurrentHealth = Math.Max(0, CurrentHealth - amount);
        }
        Debug.Log("Здоровья стало " + CurrentHealth);
        HealthChanged?.Invoke(CurrentHealth);
    }
}
