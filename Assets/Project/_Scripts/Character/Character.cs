using System;
using Opsive.UltimateCharacterController.Traits;
using UnityEngine;

[RequireComponent(typeof(Singleton))]
[RequireComponent(typeof(CharacterHealth))]
public class Character : MonoBehaviour, IDamageable
{
    private CharacterHealth _health;

    public event Action<float> HealthValueChangedEvent;
    public event Action DeathEvent;
    
    private void Awake()
    {
        _health = GetComponent<CharacterHealth>();
    }
    
    public void DealDamage(float damage)
    {
        _health.Damage(damage);
        HealthValueChangedEvent?.Invoke(_health.Value);
        
        if (_health.Value <= 0)
            DeathEvent?.Invoke();
    }
}
