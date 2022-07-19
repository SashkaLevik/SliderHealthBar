using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _minHealth = 0;

    private float _currentHealth;

    public event UnityAction<float> HealthDamage;

    public float MaxHealth => _maxHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage) 
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
        HealthDamage?.Invoke(_currentHealth);
    }

    public void Heal(float heal)
    {
        _currentHealth += heal;
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
        HealthDamage?.Invoke(_currentHealth);
    }
}
