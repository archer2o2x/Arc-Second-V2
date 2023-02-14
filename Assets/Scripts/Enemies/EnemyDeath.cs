using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class EnemyDeath : MonoBehaviour
{
    private Health EnemyHealth;

    private void Start()
    {
        EnemyHealth = GetComponent<Health>();

        EnemyHealth.OnDeath.AddListener(ProcessDeath);
    }

    public void ProcessDeath()
    {
        Destroy(gameObject);
    }
}
