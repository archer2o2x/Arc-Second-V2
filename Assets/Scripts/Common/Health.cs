using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float MaxHealth;
    private float CurrHealth;

    public UnityEvent OnDeath;

    private void Start()
    {
        Reset();
    }

    /// <summary>
    /// Resets the entities health back to full.
    /// </summary>
    public void Reset()
    {
        CurrHealth = MaxHealth;
    }

    /// <summary>
    /// Hurts the entity.
    /// </summary>
    /// <param name="amount">Amount to hurt the entity by.</param>
    public void Hurt(float amount)
    {
        CurrHealth = Mathf.Clamp(CurrHealth - amount, 0, MaxHealth);

        if (IsDead()) OnDeath.Invoke();

        // Debug.Log("hurt " + gameObject.name + " for " + amount.ToString() + " damage.");
    }

    /// <summary>
    /// Heals the entity.
    /// </summary>
    /// <param name="amount">Amount to heal the entity by.</param>
    public void Heal(float amount)
    {
        CurrHealth = Mathf.Clamp(CurrHealth + amount, 0, MaxHealth);
    }

    /// <summary>
    /// Checks if the entity is dead.
    /// </summary>
    /// <returns>Is the entity dead?</returns>
    public bool IsDead()
    {
        return CurrHealth <= 0;
    }

    /// <summary>
    /// Checks if the entity is at full health.
    /// </summary>
    /// <returns>Is the entity at full health?</returns>
    public bool IsFull()
    {
        return CurrHealth >= MaxHealth;
    }

    /// <summary>
    /// Gets the health of the entity.
    /// </summary>
    /// <returns>The health of the entity, normalized to 0 - 1.</returns>
    public float GetHealth()
    {
        return CurrHealth / MaxHealth;
    }
}
