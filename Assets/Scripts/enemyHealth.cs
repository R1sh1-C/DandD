using System;
using UnityEngine;

public class enemyHealth
{
    public event Action onDied;
    public event Action<float, float> OnHealthChanged;

    public float CurrentHealth {get; private set;}
    public float MaxHealth {get; private set;} 
    public enemyHealth(float Mhealth)
    {
        CurrentHealth = Mhealth;
        MaxHealth = Mhealth;
    }

    public void damage(int damageTaken)
    {
        CurrentHealth = MathF.Max(0, CurrentHealth - damageTaken);
        OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);
        if(CurrentHealth <= 0)
        {
            onDied?.Invoke();
        }
    }

}
